# BuyTheBookStore-Clean

<h1>Buy The Book Store Api </h1>

In order to run the project successfully please follow these steps : 

1. Project runs on PostgreSQL server. It configured according to file in the BuyTheBookStoreAPI/appsettings.json.
Modify the "ConnectionStrings" attribute as shown below.

  "ConnectionStrings": {
    "DefaultConnection": "User ID={POSTGRE_USERNAME};Password={DATABASE_PASSWORD}*; Server={HOSTNAME/ADDRESS};Port={PORT_NUMBER}; Database={DATABASE_NAME};"
  },
  
  
2. Open Package Manager Console and run these steps in order :
 a. write add-migration {migration_name}
 b. write update-database

3. After second step executed successfully, go to BuyTheBookStore\BuyTheBookStoreAPI directory in terminal and write following command : 
 dotnet run
 
  
