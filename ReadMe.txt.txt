Overview: Contact management system has been developed using ASP.NET Core MVC (razor views) as front end, .NET Web Api Core as middleware, Entity Framework Core as data access layer and SQL Server as backend. Validations have also been implemented on UI layer.

There are 3 items required for hosting the application successfully.

1) Web.CMS - web project containing all UI elements.
2) API.CMS - Web api project containing middleware functionality and database access layer.
3) Contact Mgmt DB scripts - Database scripts that will create Contact and Status table and populate Status table with master data values.

Steps to host web and API application:

1) Open SQL Server management studio and create database named ContactDB.
2) Run the attached script file to create database tables and master data in the ContactDB database.
3) Run the Api.CMS project using Visual Studio. Note the port on which it is running.
4) If the port no. is 57562, there is no need to change the port in appSettings.json file of Web.CMS project.
5) If the port no. is different, please update the port number accordingly in appSettings.json file of Web.CMS project.
   No compilation is required even if port change is done.
6) Once API.CMS project is deployed successfully, run the Web.CMS project.S

Contact Management screen walkthrough :
1) On running the Web.CMS project, the 'Create Contact' will be displayed. 
2) Enter required details on the screen and it should create a contact and take user to the Index screen.
3) The Index screen lists all contacts stored in the database. The grid shown has "View/Edit" and "Delete" links.
4) On clicking "View/Edit" link, the user will be taken to 'Edit Contact' screen and will be able to update all fields on screen.
5) On clicking "Delete" screen, the user will be asked if he/she wants to delete a record ? If 'OK' is clicked, the record will be deleted and user will be redirected to the Index screen. To create another contact user will have to type in 
"http://localhost:<port no.>/Contact/Create" url in the browser.
