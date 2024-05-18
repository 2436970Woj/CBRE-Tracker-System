Blazor Server Application Template

# Introduction 
This is a .NET 7 Blazor Server Application template developed using a clean architectural pattern/approach incorporating various projects and open source libaries.  

Blazor Server apps run on the server where they enjoy the support of full .NET Core runtime. 
All the processing is done on the server and UI/DOM changes are transmitted back to the client over the SignalR connection. 
As .NET code is already running on the server, we don’t need to create APIs for the front end. 
You can directly access services, databases, etc., and do anything you want to do on traditional server-side technology.

This solution uses Dapper which is a light weight micro ORM (Object-Relational Mapping) used in .NET to perform CRUD operations. This has been built from a database first perspective. 

Clean architecture was first introduced by Robert C. Martin (also known as Uncle Bob) in 2012 and it emphasises the separation of concerns and the independence of different layers 
within a system using a Domain-driven design. It promotes a modular and highly maintainable codebase by enforcing clear boundaries and dependencies between components. 
In this architecture, the business logic is kept separate from the infrastructure and presentation layers, which allows developers to build scalable, testable, 
and maintainable software.


# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:

1.	Installation process

Clone from Master branch as a starting point for new projects. Be mindful of the latests .NET version and Nuget package updates. 


2.	Software dependencies - Nuget Packages
3.	Latest releases
4.	API references

# Build and Test
TODO: Describe and show how to build your code and run the tests. 

# Contribute
There are numerious architectural design patterns which can be used when developing an application and this template represents just one of those approaches and 
my interpretation of clean architecture.

Writing code is a continual learning experience and code can always be improved/enhanced.

If you find any errors in the code or have a better approach then please let me know. It is always good to share knowledge and learn from each other thanks. 

