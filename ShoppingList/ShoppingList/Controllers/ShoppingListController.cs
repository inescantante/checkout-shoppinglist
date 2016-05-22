using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ShoppingList.Filters;
using ShoppingList.Models;
using ShoppingList.Services;

namespace ShoppingList.Controllers
{
    [ShoppingListApiAuthentication]
    public class ShoppingListController : ApiController
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        // GET api/shoppinglist
        [HttpGet]
        [AllowAnonymous]
        public ItemList Get()
        {
            var items = _shoppingListService.GetList();
            if (items != null)
            {
                var itemList = items as List<Item> ?? items.ToList();
                if (itemList.Any())
                    return new ItemList {Items = itemList}; //Request.CreateResponse(HttpStatusCode.OK, itemList);
            }
            throw new HttpException();
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No items found");
        }

        // GET api/shoppinglist/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var item = _shoppingListService.GetItem(id);
            if (item != null)
                return Request.CreateResponse(HttpStatusCode.OK, item);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No item found for this id");
        }

        // POST api/shoppinglist/
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Item item)
        {
            var result = _shoppingListService.CreateItem(item);
            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK, item);
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Item not created");
        }

        // PUT api/product/{id}
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Item item)
        {
            if (id > 0)
            {
                var responseok = _shoppingListService.UpdateItem(id, item);
                return Request.CreateResponse(HttpStatusCode.OK, responseok);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Item not found");
        }

        // DELETE api/product/{id}
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (id > 0)
            {
                var responseok = _shoppingListService.DeleteItem(id);
                return Request.CreateResponse(HttpStatusCode.OK, responseok);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Item not found");
        }
    }
}