# BuyTheBookStore-Clean

<h1>Buy The Book Store Api </h1>

In order to run the project successfully please follow these steps : 

<ol>
 <li>  Project runs on PostgreSQL server. It configured according to file in the BuyTheBookStoreAPI/appsettings.json.
Modify the "ConnectionStrings" attribute as shown below:
<ol>
 <li>
  "ConnectionStrings": {
 "DefaultConnection": "User ID=<b>{POSTGRE_USERNAME}</b>;Password=<b>{DATABASE_PASSWORD}</b>; Server=<b>{HOSTNAME/ADDRESS}</b>;Port=<b>{PORT_NUMBER}</b>; Database=<b>{DATABASE_NAME}</b>;"
  },
</li>
  </ol>
  </li>
  
  <li>
 Open Package Manager Console and run these steps in order :
 <ul>
  <li> write <b>add-migration {migration_name}</b></li>
  <li> write <b>update-database</b></li>
 </ul>
  </li>

  <li>
 After second step executed successfully, go to BuyTheBookStore\BuyTheBookStoreAPI directory in terminal and write following command : 
   <b>dotnet run</b>
</ol>
</li>
 
  
