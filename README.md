Approach to solve the practical test
1)	Build microservice using CQRS, DDD, Clean Architecture, Aggregate, MediatR, EF, Postgresql, Jenkins and Docker

2)	The microservice has Domain driven design approach and create aggregate root for User. Todos and Posts are aggregation under this aggregate root.

3)	Use EF Code First approach to create DB objects. Segregated and created Command DB and Read DB considering SOLID principle and loose coupling with the scope of scaling the performance for Read Operations. 

4) Dummyjson APIs for User, Todo, Posts are imported using repository in Infrastructure layer.

5)	Controller for Web API has http methods for Create and Get operations. Create actions will import the tables based on the model defined and save this to CommandDB. Mediatr Notifications publish events asynchronously to create the Query records in the Query Database.

5)	ReadDB has projections/tables to read the Get queries. Used Viewmodel to customize data based on the requirements for data. For example UserTodosViewModel, UserPostsViewModel, PostViewModel based on the requirements for Console application 1 and 2.
   
6) Console application will call this API and respective Post or Get method and the response is given and console output.

7) Deployment of this Rest API done through docker images. Dockerized the API and the images of service and DB and configured in the docker compose file. Jenkins pipeline is used build and publish the images to Dockerhub.

    
Each of the approaches are further discussed in details the following sections:

Microservice Design
* Use API Gateway to microservice
* Microservice design on CQRS. 
* Followed DDD approach to design domain. 
* Used Clean Architecture Principles to segregate Application, Domain and Infrastructure classes.
* Use Aggregate root approach to design the entities. User is the root entity.
* Use MediatR for Notification and decouple the Command and Query layer. Eventual consistency and Event driven design achieved using MediatR. Query DB is updated using MediatR notifications.
* External service from DummyJson implemented as repository in the Infrastructure layer.
* Repository pattern not applied.

DB Design
Create Write database and Read database based on CQRS approach
Create tables in the DB using EF migrations Code First approach.
Migrations generated and applied separately for Command DB and Query DB.


Deployment Approach
* Dockerize the service and use registry to store the images.
* Created Jenkins CI/CD pipeline to deploy the service image to Docker hub registry
* Used TWO Postgresql docker image to run the DB for Command and Query DB in the application.
* Created dockercompose file to deploy in the dockerdesktop. API runs successfully within dockerdesktop using DB images

Deployment Approach To AWS Cloud
The docker images are published to ECR registry
From ECR registry the images are deployed to ECS/EC2. To use Jenkins pipeline along with Terraform for environment configuration.
Future scope: For Orchestration and management of containers EKS is considered. Need to add Kubernetes config files for the containers.

Deployment Approach To Azure Cloud
The docker images are published to ACR registry
From ACR registry the images are deployed to Azure Apps. To use Azure DevOps pipeline.
Future scope: For Orchestration and management of containers AKS is considered. Need to add Kubernetes config files for the containers.

UnitTesting approach
* Xunit used for UnitTest
* Microsoft.EntityFrameworkCore.InMemory for DB Context in memory
* Mock Mediatr
* Use Automapper PersonProfile and DummyJson repository from the service directly

Console Application Design
* Console application 1 => Window to run all the services to create user and filter user records
* Console application 2 => Window to run all the services to Get all the posts based on the model in the scope




Steps to create the project
1)	Created Web API project with .Net 6.0 framework. Apply docker support for containerization.
2)	Have 5 projects under this solution. 
Microservices\Products.Microservice
Gateway.WebAPI
UnitTest.WebAPI
ConsoleApplications\ConsoleApp1
ConsoleApplications\ConsoleApp2
3)	Configure Ocelot Gateway in Gateway.WebAPI. Use ocelot json to define the microservice mappings.
4)	Install the following packages in the microservices project Products.Microservice
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL
Install-Package MediatR
Install-Package MediatR.Extensions.Microsoft.DependencyInjection
Install-Package Automapper.Dxtensions.Microsoft.DependencyInjection
Install-Package Newtonsoft.Json

Install the following packages in the Unit test project
Install-Package Moq
Install-Package Xunit



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
13)   Define the behaviours for logging, exception handling




