# Legal Contracts Management System

This project is a Legal Contracts Management System consisting of a backend API built with .NET Core 3.1 and a frontend web application developed with Vue.js 3.

## Backend

The backend of this system provides RESTful API endpoints for managing legal contracts. It is built with .NET Core 3.1 and utilizes ASP.NET Core framework.

### Features
- Retrieve all contracts
- Get a contract by ID
- Create a new contract
- Update an existing contract
- Delete a contract

### API Documentation
The API documentation can be found [here](docs/api_documentation.md).

### Technologies Used
- .NET Core 3.1
- C#

## Frontend

The frontend of this system is a single-page application (SPA) built with Vue.js 3.

### Features
- View a list of contracts
- View details of a contract
- Add a new contract
- Edit an existing contract
- Delete a contract

### Technologies Used
- Vue.js 3
- Vue Router
- TypeScript
- Axios
- Tailwind

## Getting Started

### Prerequisites
- .NET Core 3.1 SDK
- Node.js version 18.3 or higher

### Installation

#### Backend
1. Clone this repository.
2. Navigate to the `LegalContracts.Server` directory.
3. Run `dotnet restore` to restore the dependencies.
4. Run `dotnet run` to start the API server.

#### Frontend
1. Navigate to the `LegalContracts.Client` directory.
2. Run `npm install` to install dependencies.
3. Run `npm run dev` to start the development server.