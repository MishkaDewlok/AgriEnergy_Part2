# AgriEnergy Connect - ReadMe File - ST10219921

**Introduction:** <br/>
The Agri-Energy Connect Web App is a web-based application designed to help manage information about farmers and their products. It includes features for farmers to add and manage their products and for employees to manage farmer profiles and view/filter products. The system ensures secure access through role-based authentication and provides a responsive, user-friendly interface.

**Features:** <br/>
General: <br/>
Secure login functionality with authentication mechanisms.

**For Farmers:** <br/>
Add new products with details like name, category, and production date.
View their own product listings.

**For Employees:** <br/>
Add new farmer profiles with essential details.
View and filter a comprehensive list of products from any farmer based on criteria such as date range and product type.

**Extra information:** <br/>
This is a web app created using MVC (Model-View_Controller) in Visual Studio using C#. It is connected to a database created in SSMS called AgriEnergy. The database is connected to the app using environment variables setup. 

**Installation and Setup:** <br/>
Prerequisites:
Visual Studio 2019
SSMS
Stable Internet Connection 

**Steps to access the program:** <br/>
1. Clone this repository
2. Access the code folder once cloned.
3. Open the .sln file in Visual Studio IDE
4. On the top of the screen there will be a green run arrow, with the project title "AgriEnergy" next to it. Click this button to run the app.
5. The program will now begin to build and run.
6. The app will now open in a localhost port on the desktops local web browser and open on the home page.

**Database setup:** <br/>
1. Open SSMS
2. Connect to the server
3. Create a database called "AgriEnergy". Use the statement CREATE DATABASE AgriEnergy, then execute the statement.
4. Switch the database to AgriEnergy.
5. Create the following tables. Use the below scripts. Then execute the scripts.  <br/>
   
Create table Farmers(
farmerID int identity (1,1) primary key not null,
farmerUserName varchar(75) not null,
farmerPassword varchar(75) not null
); <br/>


Create table Employees(
employeeID int identity (1,1) primary key not null,
employeeUserName varchar(75) not null,
employeePassword varchar(75) not null
); <br/>

Create table Products(
productID int identity (1,1) primary key not null,
productPrice decimal (10,2) not null,
productQuantity integer not null,
productCategory varchar(150) not null,
productionDate DateTime not null,
farmerID int FOREIGN KEY (farmerID) REFERENCES Farmers(farmerID)
); <br/>

6. Insert the following data. Then execute the scripts. <br/>
 -- Inserting data into the Farmers table
INSERT INTO Farmers (farmerUserName, farmerPassword) VALUES ('farmer1', '1234');
INSERT INTO Farmers (farmerUserName, farmerPassword) VALUES ('mary_agr', 'secure456');
INSERT INTO Farmers (farmerUserName, farmerPassword) VALUES ('alex_ranch', 'qwerty789');
INSERT INTO Farmers (farmerUserName, farmerPassword) VALUES ('lucas_cult', 'asdfgh123');
INSERT INTO Farmers (farmerUserName, farmerPassword) VALUES ('emily_grow', 'zxcvbn456'); <br/>

-- Inserting data into the Employees table
INSERT INTO Employees (employeeUserName, employeePassword) VALUES ('emp1', '1234');
INSERT INTO Employees (employeeUserName, employeePassword) VALUES ('sarah_work', 'work456');
INSERT INTO Employees (employeeUserName, employeePassword) VALUES ('dave_help', 'help789');
INSERT INTO Employees (employeeUserName, employeePassword) VALUES ('nina_staff', 'staff123');
INSERT INTO Employees (employeeUserName, employeePassword) VALUES ('jake_team', 'team456'); <br/>

-- Inserting data into the Products table
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (19.99, 100, 'Vegetables', '2024-01-01', 1);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (29.99, 200, 'Fruits', '2024-01-05', 2);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (9.99, 50, 'Herbs', '2024-01-10', 3);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (15.99, 150, 'Grains', '2024-01-15', 4);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (25.99, 80, 'Dairy', '2024-01-20', 5);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (12.99, 120, 'Meat', '2024-01-25', 1);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (17.99, 90, 'Poultry', '2024-01-30', 2);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (8.99, 60, 'Fish', '2024-02-01', 3);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (13.99, 110, 'Eggs', '2024-02-05', 4);
INSERT INTO Products (productPrice, productQuantity, productCategory, productionDate, farmerID) VALUES (21.99, 70, 'Honey', '2024-02-10', 5); <br/>

**Usage Guide:** <br/>
**For Farmers:** <br/>

1. You will be greeted with an interactive and colourful Home page of the web app with information about the app. Click on the "FarmerLogin" tab to now login with your credentials.
2. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 28" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/cdeb7943-06f2-4285-94ec-50068512ff08">
3. Once clicked, you will see two boxes for Username and Password. In the white box, enter your credentials and press Login.
4. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 37" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/4aef1b28-4eb9-44e5-a6b3-b6effc954de2">
5. If your credentials are correct, you will be redirected to the Products Index screen to view your products or to add a new product.
6. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 44" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/e923a7e2-d377-418c-811d-ddcd0a930fc8">
7. If you wish to add a new product, click on the "Create New".
8. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 48" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/a6a32dcc-3f45-49fa-8b05-238184519486">
9. You will be redirected to add the information of the product details. Once completed, click "Submit". The new product will now be displayed on the Products Index screen.

**For employees:** <br/>
1. You will be greeted with an interactive and colourful Home page of the web app with information about the app. Click on the "EmployeeLogin" tab to now login with your credentials.
2. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 28" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/b1eb339c-2f81-4faf-b2e3-fe43c90b3fc7">
3. Once clicked, you will see two boxes for Username and Password. In the white box, enter your credentials and press Login.
4. <img width="1440" alt="Screenshot 2024-05-31 at 23 57 03" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/<img width="1440" alt="Screenshot 2024-05-31 at 23 57 16" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/8bc4933f-aac1-4f85-a7ad-d82bfccf71ae">
104732895/d43c88ea-a3b1-40f2-89bb-0b66d3e28dc4">
5. If your credentials are correct, you will be redirected to the Farmers Index screen to view a list of all the existing farmers with their usernames and passwords.
6. <img width="1440" alt="Screenshot 2024-05-31 at 23 57 10" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/4aec72be-c889-4bc8-8eb9-e82f2889e819">
7. To add a new farmer, click "Create New."
8. ![Uploading Screenshot 2024-05-31 at 23.57.16.png…]()
9. You will be redirected to add the information of the new farmers details. Once completed, click "Submit". The new farmer will now be displayed on the Farmers Index screen.
10. You can also choose to search for a farmer by their ID, and filter the products they have added by the ProductCategory and StartDate and End date. To do this, click on the "Filter" tab on the ribbon above.
11. You will be redirected to the screen to search and filter based on your criteria. The result will be displayed below.
<img width="1440" alt="Screenshot 2024-05-31 at 23 57 23" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/c3ed3ee3-d5a9-418a-a78a-bbe7002c43f7">

**Final comments:** <br/>
Thank you for using the Agri-Energy webapp!
The developer, Mishka, ST10219921, is open to receiving feedback and improvements as well as comments. Be sure to let us know!
