# E-Commerce_Api_Project
 I'm doing an e-commerce project. In this project, I used the onion architecture as the architecture. I will implement the Cqrs+MediatR design pattern.

## What is Onion Architecture?
Onion Architecture was designed by Jeffrey Palermo in 2008 so we can build even better the testability, maintainability and reliability of an application. Onion Architecture is an approach that aims to provide solutions by addressing the difficulties and concerns encountered in the classical 3 or n-layer architectural structuring, and allows us to build the architecture by establishing a loose dependency between the layers.

### Benefits of Onion Architecture
- This approach makes it possible to create a universal business logic that is not tied to anything.
- It’s a good fit for microservices, where it’s not only a database that can act as a data access layer, but also for example an http client, if you need to get data from another microservice, or even from an external system.
- Onion architecture ensures flexibility, sustainability and portability.
- The system can be quickly tested because the application core is independent.

<img src="https://unixmagick.xyz/images/onion-architecture.png" width="300" height="300">

### What is CQRS (Command Query Responsibility Segregation)?

 CQRS is an architectural design model whose main focus is on the separation of write and read responsibilities. The CQRS architecture is based on the CQS principle. To talk about the main idea of CQS; a method should change the state of the object or return a result, but not both operations.
 In this approach, methods should be divided into 2 different models:
- Commands: Changes the state of the object or system.
- Queries: It only returns the result and does not change the state of any object or system.
- MediatR; It is a library that enables the use of the Mediator pattern. In our example, we will use this library for the CQRS pattern to provide a loosely coupled connection between the command query models and the classes that will handle these models from a single point.

- If we briefly talk about the mediator pattern; It is a pattern based on providing communication between objects derived from the same interface over a single point. It provides loose cohesion as it provides communication through a single class (Mediator). The most common example in this regard is the example of aircraft and tower. All aircraft communicate with the tower , they do not communicate directly with each other. In this example, we can say that the Mediator object is the tower, the classes that derive from the planes.

<img src="https://miro.medium.com/max/640/1*-6Fn4EB_5V7GnKJsZsn1CQ.png" width="300" height="300">
