# CityInfo API

Welcome to the CityInfo API, a fully functional ASP.NET Core 6 Web API project that covers the fundamentals. This project serves as a comprehensive example, addressing key concerns like CRUD operations, dependency injection, database connectivity, authentication, versioning, and API documentation.

## Table of Contents
- [Project Overview](#project-overview)
- [Features](#features)
- [Key Endpoints](#key-endpoints)
- [How to Run](#how-to-run)
- [Postman Collection](#postman-collection)
- [Technologies Used](#technologies-used)


## Project Overview
<a name="project-overview"></a>
The CityInfo API provides information about cities, their famous visiting areas, tourism places, and more.

## Features
<a name="features"></a>
- CRUD Operations: Perform Create, Read, Update, and Delete operations on cities and points of interest.
- Dependency Injection: Utilizes the dependency injection feature of ASP.NET Core for managing components and services.
- Database Connectivity: Connects to a database to store and retrieve city and point of interest data.
- Authentication: Implements authentication for securing certain endpoints, ensuring secure access to sensitive information.
- Versioning: Supports versioning of the API to manage changes and updates.
- Documentation: Includes documentation for the API to facilitate usage and development.

## Key Endpoints
<a name="key-endpoints"></a>

### 1. GET Cities
- **URL:** `https://localhost:{{portNumber}}/api/cities`
- **Method:** GET
- **Description:** Retrieve a list of cities.

### 2. GET City
- **URL:** `https://localhost:{{portNumber}}/api/cities/1`
- **Method:** GET
- **Description:** Retrieve information about a specific city.

### 3. POST Point of Interest
- **URL:** `https://localhost:{{portNumber}}/api/cities/3/pointsofinterest`
- **Method:** POST
- **Description:** Add a new point of interest to a city.

### 4. PUT Point of Interest
- **URL:** `https://localhost:{{portNumber}}/api/cities/1/pointsofinterest/1`
- **Method:** PUT
- **Description:** Update information about a specific point of interest.

### 5. DELETE Point of Interest
- **URL:** `https://localhost:{{portNumber}}/api/cities/1/pointsofinterest/1`
- **Method:** DELETE
- **Description:** Remove a specific point of interest.

### 6. GET Cities, filtered and searched
- **URL:** `https://localhost:{{portNumber}}/api/cities?name=Antwerp&searchQuery=the`
- **Method:** GET
- **Description:** Retrieve a filtered and searched list of cities.

### 7. POST Authentication info to get a token
- **URL:** `https://localhost:{{portNumber}}/api/authentication/authenticate`
- **Method:** POST
- **Description:** Obtain an authentication token by providing username and password.

...

## How to Run
<a name="how-to-run"></a>
1. Clone this repository.
2. Open the solution in Visual Studio.
3. Configure any necessary settings in `appsettings.json`.
4. Build and run the project.

## Postman Collection
<a name="postman-collection"></a>
Use the provided Postman collection to test the API endpoints. You can find the collection [here](https://schema.getpostman.com/json/collection/v2.1.0/collection.json).

## Technologies Used
<a name="technologies-used"></a>
- ASP.NET Core 6
- Entity Framework Core
- Postman
- Visual Studio


