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
