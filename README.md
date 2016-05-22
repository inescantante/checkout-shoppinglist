# checkout-shoppinglist
Checkout.com shopping list exercise

## Requirements
The repository has two different solutions:
- ShoppingList: service endpoint.
- checkout-net-library-master: checkout library modified to interact with the shopping list endpoint.

The Shopping list solution was created with visual studio 2015 and has the following frameworks/libraries:
- .Net Framework 4.6
- Database file (App_Data/ShoppingListDb.mdf) to hold the items list and consumers list for the API
- Entity Framework 6
- Unity for dependency injection

## Authentication
Since the API is going to be consumed through a friendly route, Basic authentication was implemented using a custom filter.
Two configurations were added to support the shopping list API:
```
    <add key="Checkout.ConsumerName" value="" />
    <add key="Checkout.Environment" value="ShoppingList" />
```

## Shopping List API endpoints:
- GET api/shoppinglist
- GET api/shoppinglist/{id}
- POST api/shoppinglist/
- PUT api/shoppinglist/{id}
- DELETE api/shoppinglist/{id}

