# order-info-api

This project has an appSetting.json file. In that file, we have a ConnectionString key and token. This token is required to connect to remote customer service. 


For database connection, you can add a connection string in the below areas.

- appSettings.json => ConnectionStrings => MMTConnectionString 
- OrderInfo.DataAccess => Concrete => EntityFramework => Contexts


To connect to remote API, you can add token key and API URL without the method name(/GetUserDetails) in the below area. 
 
- appSettings.json => CustomerSettings => ApiBaseUrl
- appSettings.json => CustomerSettings => ApiCode

