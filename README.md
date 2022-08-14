
* Used patterns **DDD, CQRS, and Clean Architecture** with clean code
*  **CQRS** development by  **MediatR**, validation by FluentValidation and mapping AutoMapper library
* Sending to rabbitmq with CompleteOrder(end point) and order service using **MassTransit**
* Using **Entity Framework Core ORM** and auto migrate and seed dummy data to postgrsql

### Installing

At the root directory which include **docker-compose.yml** files, run below command:

docker-compose up --force-recreate

You can **call microservices** as below urls:

* **Order Service http://localhost:443/swagger/index.html**
* **Product Service http://localhost:444/swagger/index.html**
* **customer Service http://localhost:448/swagger/index.html**
* **Rabbit Management  http://http://localhost:15672/**   user:guest- Password:guest
* **pgAdmin PostgreSQL http://http://localhost:5050**   -- password:admin

