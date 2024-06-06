# Contracts Controller API Documentation

## Introduction
This API allows users to manage legal contracts.

## Authentication
Authentication is not required to access this API.

## Endpoints

### Get all contracts
- **URL**: `/api/Contracts`
- **Method**: `GET`
- **Description**: Retrieves all contracts.
- **Response**: 
  - **Status Code**: `200 OK`
  - **Body**: A list of legal contracts.

### Get a contract by ID
- **URL**: `/api/Contracts/{id}`
- **Method**: `GET`
- **Description**: Retrieves a contract by its ID.
- **Parameters**: 
  - `id` (integer, path): The ID of the contract to retrieve.
- **Response**:
  - **Status Code**: 
    - `200 OK` if the contract is found.
    - `400 Bad Request` if the contract is not found.
  - **Body**: The legal contract.

### Create a new contract
- **URL**: `/api/Contracts`
- **Method**: `POST`
- **Description**: Creates a new contract.
- **Request Body**: 
  - `AuthorName` (string, required): The author's name.
  - `LegalEntityName` (string, required): The name of the legal entity.
  - `LegalEntityDescription` (string, required): A description of the legal entity.
- **Response**: 
  - **Status Code**: `200 OK`
  - **Body**: The newly created legal contract.

### Update a contract
- **URL**: `/api/Contracts/{id}`
- **Method**: `PUT`
- **Description**: Updates an existing contract.
- **Parameters**: 
  - `id` (integer, path): The ID of the contract to update.
- **Request Body**: 
  - `AuthorName` (string, required): The author's name.
  - `LegalEntityName` (string, required): The name of the legal entity.
  - `LegalEntityDescription` (string, required): A description of the legal entity.
- **Response**:
  - **Status Code**: 
    - `200 OK` if the contract is updated successfully.
    - `400 Bad Request` if the contract is not found.
  - **Body**: The updated legal contract.

### Delete a contract
- **URL**: `/api/Contracts/{id}`
- **Method**: `DELETE`
- **Description**: Deletes an existing contract.
- **Parameters**: 
  - `id` (integer, path): The ID of the contract to delete.
- **Response**:
  - **Status Code**: 
    - `200 OK` if the contract is deleted successfully.
    - `400 Bad Request` if the contract is not found.
  - **Body**: The deleted legal contract.

## Data Model
The `LegalContract` model represents a legal contract with the following properties:
- `Id` (integer): The unique identifier of the contract.
- `AuthorName` (string): The name of the author of the contract.
- `LegalEntityName` (string): The name of the legal entity involved in the contract.
- `LegalEntityDescription` (string): A description of the legal entity.
- `CreatedAt` (DateTime): The date and time when the contract was created.
- `UpdatedAt` (DateTime): The date and time when the contract was last updated. This field may be null if the contract has not been updated.