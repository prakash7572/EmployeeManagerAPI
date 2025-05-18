# 👨‍💻 Employee Management API with JWT Authentication (.NET 8 + SQL Server)

## 📋 Overview

This is a secure and scalable RESTful API developed using **ASP.NET Core 8 Web API** for managing employee records. It supports **JWT-based authentication**, **role-based authorization**, and uses **Entity Framework Core** with **SQL Server** as the backend.

---

## 🛠️ Technology Stack

- **Framework:** .NET 8 (ASP.NET Core Web API)
- **ORM:** Entity Framework Core, ADO.NET
- **Database:** Microsoft SQL Server
- **Authentication:** JWT Bearer Token
- **Tools:** Swagger (OpenAPI), Postman, Visual Studio 2022+

---

## 🔐 Authentication & Authorization

- JWT tokens are generated upon successful login.
- Secure endpoints require: `Authorization: Bearer <token>`
- Role-based access:
  - **Admin**: Full access (Create, Read, Update, Delete)
  - **User**: Read-only access

---

## 👥 User Roles

| Role   | Permissions                     |
|--------|----------------------------------|
| Admin  | Full CRUD access on employees   |
| User   | Read-only access to employees   |

---

## 📡 API Endpoints

### 🔑 Authentication

| Method | Endpoint            | Description              | Access  |
|--------|---------------------|--------------------------|---------|
| POST   | `/api/auth/register` | Register a new user       | Public  |
| POST   | `/api/auth/login`    | Login and receive token   | Public  |
| GET    | `/api/auth/me`       | Get current user details  | Private |

### 👨‍💼 Employee Management

| Method | Endpoint                   | Description              | Access     |
|--------|----------------------------|--------------------------|------------|
| GET    | `/api/employees`           | List all employees       | Admin/User |
| GET    | `/api/employees/{id}`      | Get employee by ID       | Admin/User |
| POST   | `/api/employees`           | Create new employee      | Admin      |
| PUT    | `/api/employees/{id}`      | Update employee          | Admin      |
| DELETE | `/api/employees/{id}`      | Delete employee          | Admin      |

---

## 📦 Required NuGet Packages

Install the necessary NuGet packages by running the following commands in your terminal:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Swashbuckle.AspNetCore

