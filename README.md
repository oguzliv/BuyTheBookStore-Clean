# BuyTheBookStore-Clean

<h1>Buy The Book Store Api </h1>

In order to run the project successfully please follow these steps : 

<ol>
 <li>  Project runs on PostgreSQL server. It configured according to file in the BuyTheBookStoreAPI/appsettings.json.
Modify the "ConnectionStrings" attribute as shown below.
<div>
  "ConnectionStrings": {
    "DefaultConnection": "User ID={POSTGRE_USERNAME};Password={DATABASE_PASSWORD}*; Server={HOSTNAME/ADDRESS};Port={PORT_NUMBER}; Database={DATABASE_NAME};"
  },
</div>
  </li>
  
  <li>
 Open Package Manager Console and run these steps in order :
 <ul>
  <li> write add-migration {migration_name}</li>
  <li> write update-database</li>
 </ul>
  </li>

  <li>
 After second step executed successfully, go to BuyTheBookStore\BuyTheBookStoreAPI directory in terminal and write following command : 
 dotnet run
</ol>
</li>
 
  
