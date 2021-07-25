# order-info-api

This project has an appSetting.json file. In that file, we have a ConnectionString key and token. This token is required to connect to remote customer service. 


For database connection, you can add a connection string in the below areas.

- appSettings.json => ConnectionStrings => MMTConnectionString 
- OrderInfo.DataAccess => Concrete => EntityFramework => Contexts


To connect to remote API, you can add token key and API URL without the method name(/GetUserDetails) in the below area. 
 
- appSettings.json => CustomerSettings => ApiBaseUrl
- appSettings.json => CustomerSettings => ApiCode

# Additional Details ?

According to the determinant rule of the business unit, we can use a Memory cache or distributed cache instead of getting user details from remote service in query.

In the database design section, we can create a query that will include customer, order and order item information specific to this query.

Instead of using the Entity Framework Core ORM tool, we can have a much more efficient query by writing a direct query with Dapper.

As an aspect;
Exception log direction,
verification direction,
performance aspect,
transaction scope direction etc.

We can use AutoMapper for mapping DB objects to view objects.

Also, security(authorization and authentication) and docker etc. 