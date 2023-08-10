Approach to solve the practical test
1)	Build microservice using CQRS, DDD, Clean Architecture, Aggregate, MediatR, EF, Postgresql, Jenkins and Docker

2)	The microservice has Domain driven design approach and create aggregate root for User. Todos and Posts are aggregation under this aggregate root.

3)	Use EF Code First approach to create DB objects. Segregated and created Command DB and Read DB considering SOLID principle and loose coupling with the scope of scaling the performance for Read Operations. 

4) Dummyjson APIs for User, Todo, Posts are imported using repository in Infrastructure layer.

5)	Controller for Web API has http methods for Create and Get operations. Create actions will import the tables based on the model defined and save this to CommandDB. Mediatr Notifications publish events asynchronously to create the Query records in the Query Database.

5)	ReadDB has projections/tables to read the Get queries. Used Viewmodel to customize data based on the requirements for data. For example UserTodosViewModel, UserPostsViewModel, PostViewModel based on the requirements for Console application 1 and 2.
   
6) Console application will call this API and respective Post or Get method and the response is given and console output.

7) Deployment of this Rest API done through docker images. Dockerized the API and the images of service and DB and configured in the docker compose file. Jenkins pipeline is used build and publish the images to Dockerhub.

![image](https://github.com/shijithss/PTWebApi/assets/32163593/81fea22d-6424-423f-934b-1eab1656e859)

    
Each of the approaches are further discussed in details the following sections:

Microservice Design
![image](https://github.com/shijithss/PTWebApi/assets/32163593/9355f464-cd19-4f44-88ae-edbaff9ee9fc)

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
* Docker hub image below
  ![image](https://github.com/shijithss/PTWebApi/assets/32163593/a5fab27c-9afe-41ac-b20f-0435d9aac1b9)


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
![image](https://github.com/shijithss/PTWebApi/assets/32163593/8326b9e4-f919-43b4-8b51-95fa7400c186)


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




Jenkins Deployment Output Log to build and push the image to Docker Hub.

Started by user admin
Running as SYSTEM
Building in workspace C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild
The recommended git tool is: NONE
No credentials specified
 > git.exe rev-parse --resolve-git-dir C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild\.git # timeout=10
Fetching changes from the remote Git repository
 > git.exe config remote.origin.url https://github.com/shijithss/PTWebApi # timeout=10
Fetching upstream changes from https://github.com/shijithss/PTWebApi
 > git.exe --version # timeout=10
 > git --version # 'git version 2.38.0.windows.1'
 > git.exe fetch --tags --force --progress -- https://github.com/shijithss/PTWebApi +refs/heads/*:refs/remotes/origin/* # timeout=10
 > git.exe rev-parse "refs/remotes/origin/master^{commit}" # timeout=10
Checking out Revision 8894c5981303fedd26f9321021781b556ce885f2 (refs/remotes/origin/master)
 > git.exe config core.sparsecheckout # timeout=10
 > git.exe checkout -f 8894c5981303fedd26f9321021781b556ce885f2 # timeout=10
Commit message: "Dockercompose added"
 > git.exe rev-list --no-walk 8894c5981303fedd26f9321021781b556ce885f2 # timeout=10
[PTWebAPI] $ C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\tools\io.jenkins.plugins.dotnet.DotNetSDK\NET6\dotnet.exe build User.Microservice.csproj
Microsoft (R) Build Engine version 17.2.0+41abc5629 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  All projects are up-to-date for restore.
  User.Microservice -> C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild\PTWebAPI\bin\Debug\net6.0\User.Microservice.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.16
.NET Command Completed - Exit Code: 0

[PTWebAPIBuild] $ C:\Windows\system32\cmd.exe -xe C:\Users\sshylan\AppData\Local\Temp\jenkins11431161856955843309.sh
Microsoft Windows [Version 10.0.22621.2134]
(c) Microsoft Corporation. All rights reserved.

C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild>[PTWebAPIBuild] $ cmd /c call C:\Users\sshylan\AppData\Local\Temp\jenkins389664918159427910.bat

C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild>docker login -u shijith.ss@gmail.com -p Password  docker.io 
WARNING! Using --password via the CLI is insecure. Use --password-stdin.
Login Succeeded

C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild>exit 0 
[PTWebAPIBuild] $ docker build -f PTWebAPI/Dockerfile -t index.docker.io/shijithss/ptwebapi --pull=true C:\Users\sshylan\AppData\Local\Jenkins\.jenkins\workspace\PTWebAPIBuild
#1 [internal] load build definition from Dockerfile
#1 transferring dockerfile: 30B
#1 transferring dockerfile: 891B done
#1 DONE 0.0s

#2 [internal] load .dockerignore
#2 transferring context: 382B done
#2 DONE 0.0s

#3 [internal] load metadata for mcr.microsoft.com/dotnet/aspnet:6.0
#3 DONE 0.4s

#4 [internal] load metadata for mcr.microsoft.com/dotnet/sdk:6.0
#4 DONE 0.4s

#5 [build 1/7] FROM mcr.microsoft.com/dotnet/sdk:6.0@sha256:1efb2e907d398f576607983ea8d3913c802ae55ddfacda75e54208c1c070c0ab
#5 DONE 0.0s

#6 [base 1/2] FROM mcr.microsoft.com/dotnet/aspnet:6.0@sha256:367fcd63ce8722aad8632fd9151832971f0e11c3f665e4ed9be7e2e3d2531ac4
#6 resolve mcr.microsoft.com/dotnet/aspnet:6.0@sha256:367fcd63ce8722aad8632fd9151832971f0e11c3f665e4ed9be7e2e3d2531ac4
#6 resolve mcr.microsoft.com/dotnet/aspnet:6.0@sha256:367fcd63ce8722aad8632fd9151832971f0e11c3f665e4ed9be7e2e3d2531ac4 0.0s done
#6 DONE 0.0s

#7 [internal] load build context
#7 transferring context: 5.46kB 0.0s done
#7 DONE 0.0s

#8 [build 6/7] WORKDIR /src/PTWebAPI
#8 CACHED

#9 [build 2/7] WORKDIR /src
#9 CACHED

#10 [build 4/7] RUN dotnet restore "PTWebAPI/User.Microservice.csproj"
#10 CACHED

#11 [build 7/7] RUN dotnet build "User.Microservice.csproj" -c Release -o /app/build
#11 CACHED

#12 [final 1/2] WORKDIR /app
#12 CACHED

#13 [build 3/7] COPY [PTWebAPI/User.Microservice.csproj, PTWebAPI/]
#13 CACHED

#14 [base 2/2] WORKDIR /app
#14 CACHED

#15 [publish 1/1] RUN dotnet publish "User.Microservice.csproj" -c Release -o /app/publish /p:UseAppHost=false
#15 CACHED

#16 [build 5/7] COPY . .
#16 CACHED

#17 [final 2/2] COPY --from=publish /app/publish .
#17 CACHED

#18 exporting to image
#18 exporting layers done
#18 writing image sha256:00595601162f205178a0c08b56b5e08b13532d70fff12ad0cf9957b25d7601b2 done
#18 naming to docker.io/shijithss/ptwebapi done
#18 DONE 0.0s
[PTWebAPIBuild] $ docker push index.docker.io/shijithss/ptwebapi
Using default tag: latest
The push refers to repository [docker.io/shijithss/ptwebapi]
4254d1ec0cf5: Preparing
5f70bf18a086: Preparing
75fdf84e34aa: Preparing
a3884885f268: Preparing
9420ab5f560b: Preparing
b0a4e3e23649: Preparing
f6c4eaf2bdb1: Preparing
b0a4e3e23649: Waiting
8ce178ff9f34: Preparing
f6c4eaf2bdb1: Waiting
8ce178ff9f34: Waiting
5f70bf18a086: Pushed
75fdf84e34aa: Pushed
9420ab5f560b: Pushed
4254d1ec0cf5: Pushed
a3884885f268: Pushed
b0a4e3e23649: Pushed
f6c4eaf2bdb1: Pushed
8ce178ff9f34: Pushed
latest: digest: sha256:ad732ca3ba412b0170875d1a441a51ec12e2b5de6e4ae02dc9f884211815fa56 size: 1994
Finished: SUCCESS
