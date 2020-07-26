# OrderApp

Initial implementation of Order application. Information of what's included below:

Fullstack web application
- Angular app
- .NET Core WebAPI
- SQL Server Database

Database
- Built code first using Entity Framework Core.
- Migrations for InitialCreate will need to be run manually at the moment
- Seeded items catalog

API
- Endpoints for both Orders and Order items
- Service layer and repository layers implemented
- Some basic Authentication and Authorization handling
- Unit tests for storing Order dates

App
- Angular 8, Bootstrap CSS framework
- Home Page
  - See catalog of items
  - Add items to an Order
- Orders Page
  - See list of existing orders
  - Cancel an order
- Catalog Page
  - See list of items
  - Edit an existing item
    - Basic form validation
  - Remove an existing item
  - Add a new item
- Basket page
  - List of order items in basket
  - Remove an item from an Order
  - Create a new Order
 
