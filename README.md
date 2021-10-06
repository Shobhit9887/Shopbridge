 ![image](https://user-images.githubusercontent.com/44239978/136167008-2851d158-faab-423f-9597-58cc0cdb1ae5.png)

 
5th October, 2021\
Author: Shobhit Saxena\
Shobhit.saxena54@gmail.com


Overview:
“Shopbridge” is an e-commerce application. This documentation is for a module that lets the Product Admin of the organization to perform the followings tasks with ease:

1. Adding a new Product to the inventory.
2. Listing the Products from the inventory.
3. Edit an existing Product in the inventory.
4. Delete a Product from the inventory.

The application is integration with an MVC 5 module to enhance the experience of the user for simplicity and ease. The backend is made in .NET Core and Entity Framework that implements a REST APIs bundle for the above-mentioned task. 

The inventory is stored in MSSQL RDBMS that connects seamlessly to the underlying backend to the application. The forms are fully validated from client side as well as the server side. All the response status codes are programmed to point towards the correct direction.

The application includes Exception Handling for most of the unforeseen exceptions that can cause the application to stop or even break. It is also integrated with Unit Tests for the backend API calls for pre-build validations using NUNIT testing engine.





Table of Contents
1	Technologies Used\
2	Backend	\
3	Database Management System	\
4	MVC 5	\
5	Unit Testing	



1	Technologies Used

a.	Backend is developed in ASP.NET Core as REST APIs.
b.	ORM used is Entity Framework Core.
c.	DBMS used is MSSQL
d.	MVC 5 for the basic forms and views.
e.	Unit test engine: NUnit

2	Backend

It is developed in ASP.NET Core using entity framework. I chose ASP.NET Core because I have most of the professional experience in this technology and I find it really developer friendly as well as scalable for the future references.
The project includes the following 5 API calls asynchronously:
a.	To get all the products.\
b.	To get one product by id.\
c.	Add a new product.\
d.	Edit an existing product.\
e.	Delete a product from the inventory.

All these calls are equipped with exception handing and appropriate status codes. Database models are mapped with Entity Framework for direct access to .NET Objects. 

3	Database Management System

Database used is MSSQL, I chose MSSQL because I hadn’t worked on it in the past, and I saw an opportunity of learning a new skill.

There is only 1 table which has been converted to migration script as well for a seamless database creation.
The table includes these fields of the given type:

ProductId			GUID\
ProductNumber			int\
Name				varchar\
Description			varchar\
Price				float\
Quantity			float\
4	MVC 5

Although in the assignment, the frontend was not asked, but being a Full Stack Developer I saw an opportunity to make the project along with learning a new thing for my skill set.
Why MVC?
I chose MVC because it has a seamless connection mechanism to a .NET application. MVC controllers are pre-equipped with the required imports and the views are generated by the model classes automatically which makes it much faster and easier to integrate front-end into the system.
There are these 2 views in our MVC module:
a.	Index – This is the view where the user gets landed. It includes a very simple UI with a list of all the products that exist in the inventory.
 
 ![image](https://user-images.githubusercontent.com/44239978/136166354-8f2c6f00-159b-440a-b859-790fabbe3be8.png)

 
b.	Add/Edit view – User can add or edit a product in the inventory using this view. It contains a form that takes all the required fields with all the validations on the fields.
 
 ![image](https://user-images.githubusercontent.com/44239978/136166439-2ec9ec64-1996-4544-9853-628ebaca7239.png)

![image](https://user-images.githubusercontent.com/44239978/136166468-c8198e51-453e-43f9-b95d-e071321a7d41.png)

 

5	Unit Testing

I had not implemented unit testing before. With this assignment, I got an opportunity to learn about it and surely did.
This module is based on NUnit testing engine. It tests all the api functions that are required for the application to run. There are some things that needed to be kept in mind:
a.	Unit test are independent of the external sources. That means, database calls are not made in unit testing. Our application needs a database call for every task. In this case, I made an In-Memory database for Unit Testing.
b.	A function can return on multiple points, so the unit tests are to be made for every return path.

The result:
 
 ![image](https://user-images.githubusercontent.com/44239978/136166498-ee93681a-e56c-4843-8768-3aa7e55e3ead.png)



6	Conclusion

This application can perform all the given tasks with ease and returns meaningful exceptions if anything goes wrong. 
The API calls are asynchronous and exception handling is implemented. 
I am looking forward to working for such kind of applications and improve my knowledge even more for better future and best of my effort to where ever I work.
