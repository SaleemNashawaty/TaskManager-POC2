# TaskManager
The Task Manager serves as a proof of concept (PoC) for the implementation of a GraphQL server API and a GraphQL client. This PoC comprises three primary components:

Server: This component encompasses the hosting application service for the GraphQL API, GraphQL schema (consisting of Queries, Mutations, and Subscribers), as well as the database schema and DBContext.
![image](https://github.com/SaleemNashawaty/TaskManager-POC2/assets/32152547/eca383bd-4477-4b79-97a8-9b8a5c8ef775)

Client: The Client component is an Angular application that features a Kendo grid displaying tasks. Additionally, it includes a sign-in page that enables users to log in and retrieve a list of tasks based on their signed-in user ID.
![image](https://github.com/SaleemNashawaty/TaskManager-POC2/assets/32152547/5c92382b-821d-4bef-bfaa-e991be9a316c)



Services: This part involves an email service that consumes Azure Service Bus messages. Its primary function is to send emails to recipients once they have been assigned a task.
![image](https://github.com/SaleemNashawaty/TaskManager-POC2/assets/32152547/4e032005-78b1-4368-97e7-e29ea123b3bc)


Ingredients/ Tooling
Visual Studio 2022
Visual Code
.NET 6
SQL Server Express
Angular
Kendo
Bootstrap
Hot Chocolate
GraphQL
MediatR
SignalR
Azure Service Bus
Postman


![image](https://github.com/SaleemNashawaty/TaskManager-POC2/assets/32152547/d7a79da0-a1b5-4ce2-811d-82b87bd5fb6f)



