# TaskManager
The Task Manager serves as a proof of concept (PoC) for the implementation of a GraphQL server API and a GraphQL client. This PoC comprises three primary components:

Server: This component encompasses the hosting application service for the GraphQL API, GraphQL schema (consisting of Queries, Mutations, and Subscribers), as well as the database schema and DBContext.

Client: The Client component is an Angular application that features a Kendo grid displaying tasks. Additionally, it includes a sign-in page that enables users to log in and retrieve a list of tasks based on their signed-in user ID.

Services: This part involves an email service that consumes Azure Service Bus messages. Its primary function is to send emails to recipients once they have been assigned a task.


