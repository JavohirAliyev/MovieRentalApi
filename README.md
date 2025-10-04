🚀 Steps to Build
-----------------

### 1\. Setup Project

```
dotnet new webapi -n MovieRentalAPI
cd MovieRentalAPI

```

Install dependencies:

```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Swashbuckle.AspNetCore
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

```

* * * * *
### 2\. Models & DTOs

-   `Models/` → define **Movie, Customer, Rental** with relationships.

-   `DTOs/` → define **MovieDto, CustomerDto, RentalDto** (for data transfer, avoiding exposing DB entities directly).

* * * * *

### 3\. Database & EF Core

-   Define `ApplicationDbContext.cs` in `Data/`

-   Configure DbSets for `Movies`, `Customers`, `Rentals`

-   Register DbContext in `Program.cs` with PostgreSQL connection string.

Run migrations:

```
dotnet ef migrations add InitialCreate
dotnet ef database update

```

* * * * *

### 4\. Repositories & Interfaces

-   Create repository interfaces:

    -   `IMovieRepository`

    -   `ICustomerRepository`

    -   `IRentalRepository`

-   Implement them in `Repositories/` folder.

-   Handle CRUD operations.

* * * * *

### 5\. Services Layer

-   Create services:

    -   `MovieService`

    -   `CustomerService`

    -   `RentalService`

-   Services call repositories and contain business logic.

* * * * *

### 6\. Controllers

-   Create controllers:

    -   `MoviesController`

    -   `CustomersController`

    -   `RentalsController`

-   Map endpoints: CRUD operations + rental actions.

-   Use DTOs for input/output.

* * * * *

### 7\. Authentication (JWT)

-   Add user registration/login (basic Identity or custom).

-   Configure JWT in `Program.cs`.

-   Add `[Authorize]` attribute to controllers.

* * * * *

### 8\. Swagger Setup

-   Configure Swagger to require JWT tokens.

-   Test API endpoints directly in Swagger.

* * * * *

### 9\. Testing the Flow

1.  Create a movie

2.  Create a customer

3.  Rent a movie

4.  Return a movie

5.  See rental history

* * * * *

### 10\. Future Enhancements

-   Pagination and filtering

-   Role-based authorization (Admin/User)

-   Dockerize API and DB

-   Frontend integration (React/Angular)

* * * * *
