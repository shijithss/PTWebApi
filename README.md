Approach to solve the practical test
1)	Build microservice using CQRS, DDD, Clean Architecture, Aggregate, MediatR, EF and Postgresql
2)	The microservice has Domain driven design approach and create aggregate root for User. Todos and Posts are aggregation under this aggregate root.
3)	Use EF Code First approach to create DB objects. Dummyjson APIs for User, Todo, Posts are imported using repository.
4)	Controller for Web API has http methods for Create and Get operations. Create actions will import the tables based on the model defined and save this to DB.
5)	ReadDB has tables to read the Get queries. Used Viewmodel to customize data based on the requirements for data.
Microservice Design
Use API Gateway to microservice
Microservice design on CQRS. Repository pattern not applied.
Use MediatR for Notification and decouple the Command and Query layer. Eventual consistency and Event driven design achieved using MediatR. Query DB is updated using MediatR notifications.
Followed DDD approach to design domain
External service from DummyJson implemented as repository in the Infrastructure layer.
DB Design
Create Write database and Read database based on CQRS approach
Create tables in the DB using EF migrations Code First approach.
Migrations generated and applied separately for Command DB and Query DB.

Deployment Approach
Deploy to AWS using Jenkins CI/CD pipeline
Dockerize the service and use registry to store the images.
Use the Postgresql docker image to deploy in AWS EC2
UnitTesting approach
Xunit used for UnitTest
Microsoft.EntityFrameworkCore.InMemory for DB Context in memory
Mock Mediatr
Use Automapper PersonProfile and DummyJson repository from the service directly



Steps to create the project
1)	Created Web API project with .Net 6.0 framework. Apply docker support for containerization.
2)	Have 3 projects under this solution. 
Microservices\Products.Microservice
Gateway.WebAPI
UnitTest.WebAPI
3)	Configure Ocelot Gateway in Gateway.WebAPI. Use ocelot json to define the microservice mappings.
4)	Install the following packages in the microservices project Products.Microservice
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
Install-Package MediatR
Install-Package MediatR.Extensions.Microsoft.DependencyInjection
Install-Package Automapper.Dxtensions.Microsoft.DependencyInjection

5)	Add the ApplicationDBContext class and Interface for Command and Query database. Define the connections strings in Appsettings.json
6)	Under Domain folder create entities for User, Post and Todo
7)	Configure the Migrations assembly and execute the below commands
		Add-Migration InitialCommand -Context ApplicationCommandDBContext -OutputDir Infrastructure\Migrations\CommandDB
		
		Update-Database -Context ApplicationCommandDBContext 
		
		Add-Migration InitialQuery -Context ApplicationQueryDBContext -OutputDir Infrastructure\Migrations\QueryDB
		
		Update-Database -Context ApplicationQueryDBContext
8)	Configure the MediatR assembly in startup.cs
9)	Configure AutoMapper and Define Mappings in UserProfile
10)	Define the models for user, post and todo under application layer
11)	Define repository for DummyJson in the infrastructure layer
12)	Add the commands and Queries for CQRS




