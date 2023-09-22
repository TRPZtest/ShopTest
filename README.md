# ShopTest
Hello!
To run application just use Run Development launch profile.

This ASP application uses Azure Sql Db with seeded data so it works without local Db.
You can explore it using connection string in appsettings.Development.json

If you want to run it on your db just change Connection string in appsettings.Development.json
and run this command from project root folder:  dotnet ef database update.

Repository contains ShopTest.postman_collection.json file wich you can import to Postman as requests collection to test this API.
