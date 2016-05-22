using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ShoppingList.Models;
using ShoppingList.Services;

namespace ShoppingList.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ShoppingListApiAuthentication : AuthorizationFilterAttribute
    {
        public ShoppingListApiAuthentication()
        {
        }

        private readonly bool _isActive = true;

        public ShoppingListApiAuthentication(bool isActive)
        {
            _isActive = isActive;
        }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (!_isActive) return;

            var identity = GetBasicAuthorizationHeader(filterContext);
            if (identity == null)
            {
                UnauthorizedRequest(filterContext);
                return;
            }
            var genericPrincipal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = genericPrincipal;
            if (!OnAuthorizeConsumer(identity.UserName, identity.ApiSecret, filterContext))
            {
                UnauthorizedRequest(filterContext);
                return;
            }
            base.OnAuthorization(filterContext);
        }

        public ConsumerIdentity GetBasicAuthorizationHeader(HttpActionContext filterContext)
        {
            string authHeaderValue = null;
            var authRequest = filterContext.Request.Headers.Authorization;
            if (authRequest != null && authRequest.Scheme == AuthenticationSchemes.Basic.ToString())
                authHeaderValue = authRequest.Parameter;
            if (string.IsNullOrEmpty(authHeaderValue))
                return null;
            authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));

            var credentials = authHeaderValue.Split(':');
            return credentials.Length < 2 ? null : new ConsumerIdentity(credentials[0], credentials[1]);
        }

        protected bool OnAuthorizeConsumer(string username, string apiSecret, HttpActionContext actionContext)
        {
            var provider = actionContext.ControllerContext.Configuration
                               .DependencyResolver.GetService(typeof(IConsumerService)) as IConsumerService;
            if (provider != null)
            {
                var consumer = provider.Authenticate(username, apiSecret);
                if (consumer != null)
                {
                    var consumerIdentity = Thread.CurrentPrincipal.Identity as ConsumerIdentity;
                    if (consumerIdentity != null)
                    {
                        consumerIdentity.Id = consumer.Id;
                    }
                    return true;
                }
            }
            return false;
        }

        private static void UnauthorizedRequest(HttpActionContext filterContext)
        {
            var dnsHost = filterContext.Request.RequestUri.DnsSafeHost;
            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            filterContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
        }

    }
}