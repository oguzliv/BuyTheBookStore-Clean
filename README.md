# BuyTheBookStore-Clean

<h1>Buy The Book Store Api </h1>

In order to run the project successfully please follow these steps : 

<ol>
 <li> 1. Project runs on PostgreSQL server. It configured according to file in the BuyTheBookStoreAPI/appsettings.json.
Modify the "ConnectionStrings" attribute as shown below.
<di>
  "ConnectionStrings": {
    "DefaultConnection": "User ID={POSTGRE_USERNAME};Password={DATABASE_PASSWORD}*; Server={HOSTNAME/ADDRESS};Port={PORT_NUMBER}; Database={DATABASE_NAME};"
  },
</div>
  </li>
  
  <li>
2. Open Package Manager Console and run these steps in order :
 <ul>
  <li>a. write add-migration {migration_name}</li>
  <li>b. write update-database</li>
 </ul>
  </li>

  <li>
3. After second step executed successfully, go to BuyTheBookStore\BuyTheBookStoreAPI directory in terminal and write following command : 
 dotnet run
</ol>
</li>
 
  
