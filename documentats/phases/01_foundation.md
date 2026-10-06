# Phase 01 — Foundation

### Goal

Set up the initial solution structure and prepare the development environment for the Aysan microservices system.

---

### 1- Create Blank Solution

Aysan.sln

The solution starts empty because services and shared components will be added gradually.

---

### 2-create the source structure

```text
src/
|___Services/
|___BuildingBlocks/
```

### Services

Contains independently deployable business services.

### BuildingBlocks

Contains reusable technical components shared between services.

---

### 3-Create the First Service

```text
src/
├── Services/
│   └── Catalog/
│       └── Catalog.Api/
└── BuildingBlocks/
```

`Catalog.Api`  is an ASP.NET Core Web API project.Catalog.Api

### Project

* Framework: .NET 10
* Type: ASP.NET Core Web API
* Purpose: Entry point for the Catalog service

---

### 4- Add the Project to the Soloution

The Catalog API project is added to:

Aysan.Sln

---

### 5. Initialize Git

Initialize the repository and create the initial Git history.

Important files such as `.gitignore` are added before committing the project.

### Initial commit

```
Initial project structure
```

Repository Name is : Aysan

---

### 6 - Add Docker Support

Prepare the project for containerized development.

The first Docker setup will provide a reproducible environment for running the services.

The Dockerfile is located at:

`src/Services/Catalog/Catalog.Api/Dockerfile`

---

### 7 - Add Docker Compose

Create:

docker-compose.yml

> **Important** : Create That file in root of project : `src/`

---

### 8 - Result

At the end of this phase , the project should have the following Structure

```text
Aysan/
|
|___src/
|   |___Services/
|   |    |___Catalog/
|   |        |___Catalog.Api/
|   |            |___Dockerfile
|   |___BuildingBlocks/
|
|___docs/
|
|___.env
|___catalog.env
|___docker-compose.yml
|___docker-compose.override.yml
|___.dockerignore
|___.gitignore
|___Aysan.Sln

```
