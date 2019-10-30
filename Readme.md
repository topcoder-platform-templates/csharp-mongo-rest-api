# Starter pack for ASP.NET Core 2.2 Web API using C#

## Overview

 This is a starter packs for ASP.NET Core 2.2 Web API projects using MongoDB as a database.

The starter pack provides a /users API endpoints with CRUD operations.

## Configuration

- All configuration is done in `appSettings.json` files in each starter pack. Basically, the only thing you need to update is DB Connection details.

## Docker Deployment

- Deployment with Docker is as simple as executing `docker-compose up` which will setup and deploy both DB and Web API.

## Verification

- Load postman collection:
  - endpoints: postman/starter-pack.postman_collection.json
  - environment: postman/starter-pack.postman_environment.json
