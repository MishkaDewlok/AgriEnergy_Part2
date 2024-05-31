# AgriEnergy Connect - ReadMe File - ST10219921

Introduction:
The Agri-Energy Connect Web App is a web-based application designed to help manage information about farmers and their products. It includes features for farmers to add and manage their products and for employees to manage farmer profiles and view/filter products. The system ensures secure access through role-based authentication and provides a responsive, user-friendly interface.

Features:
General:
Secure login functionality with authentication mechanisms.

For Farmers:
Add new products with details like name, category, and production date.
View their own product listings.

For Employees:
Add new farmer profiles with essential details.
View and filter a comprehensive list of products from any farmer based on criteria such as date range and product type.

Extra information:
This is a web app created using MVC (Model-View_Controller) in Visual Studio using C#. It is connected to a database created in SSMS called AgriEnergy. The database is connected to the app using environment variables setup. 

Installation and Setup:
Prerequisites:
Visual Studio 2019
SSMS
Stable Internet Connection 

Steps to access the program:
1. Clone this repository
2. Access the code folder once cloned.
3. Open the .sln file in Visual Studio IDE
4. On the top of the screen there will be a green run arrow, with the project title "AgriEnergy" next to it. Click this button to run the app.
5. The program will now begin to build and run.
6. The app will now open in a localhost port on the desktops local web browser and open on the home page.

Usage Guide:
For Farmers:

1. You will be greeted with an interactive and colourful Home page of the web app with information about the app. Click on the "FarmerLogin" tab to now login with your credentials.
2. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 28" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/cdeb7943-06f2-4285-94ec-50068512ff08">
3. Once clicked, you will see two boxes for Username and Password. In the white box, enter your credentials and press Login.
4. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 37" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/4aef1b28-4eb9-44e5-a6b3-b6effc954de2">
5. If your credentials are correct, you will be redirected to the Products Index screen to view your products or to add a new product.
6. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 44" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/e923a7e2-d377-418c-811d-ddcd0a930fc8">
7. If you wish to add a new product, click on the "Create New".
8. <img width="1440" alt="Screenshot 2024-05-31 at 23 56 48" src="https://github.com/MishkaDewlok/AgriEnergy_Part2/assets/104732895/a6a32dcc-3f45-49fa-8b05-238184519486">
9. You will be redirected to add the information of the product details. Once completed, click "Submit". The new product will now be displayed on the Products Index screen.

For employees:
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

Final comments:
Thank you for using the Agri-Energy webapp!
The developer, Mishka, ST10219921, is open to receiving feedback and improvements as well as comments. Be sure to let us know!
