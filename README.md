# Almaari - E-commerce Website

Almaari is a comprehensive e-commerce website developed using ASP.NET Core, C#, HTML/CSS, JavaScript, and SQL. This project aims to provide a fully functional online shopping experience, including features for both customers and administrators.

## Features

### Customer Functionalities

- **User Authentication**
  - Customer login and registration.
  - Profile editing for registered customers.
- **Product Interaction**
  - Browse and view all products.
  - Add products to the cart.
  - Add products to the wishlist.
  - Purchase items from the cart.
- **Feedback System**
  - Customers can leave feedback on products.

### Admin Functionalities

- **Data Management**
  - Add, edit, and delete products.
  - Manage categories, orders, and customer data.
  - Manage admin profiles.
- **Admin Panel**
  - Dedicated interface for administrators to manage website content and data.

### Database

- **SQL Database**
  - Centralized storage for all data including admins, products, orders, feedback, categories, customers, and cart information.

## Technologies Used

- **Back-End**
  - ASP.NET Core
  - C#
- **Front-End**
  - HTML
  - CSS
  - JavaScript
- **Database**
  - SQL

## Installation

1. **Clone the repository:**

   ```sh
   git clone https://github.com/zuhairdadi/e-commerce-website.git
2. **Navigate to the project directory:**

   ```sh
   cd almaari
3. **Set up the SQL Database:**
   
   - Create a new SQL database.
   - Update the connection string in appsettings.json with your SQL database details.
3. **Install dependencies:**

   ```sh
   dotnet restore
4. **Run the application:**

   ```sh
   dotnet run

## Usage

- **Access the Website:**
  - Open your browser and navigate to `http://localhost:5000`.
- **Admin Panel:**
  - Navigate to `http://localhost:5000/admin` to access the admin panel.

## Project Structure

- **Controllers:** Handles user requests and responses.
- **Models:** Defines the data structures and interacts with the database.
- **Views:** Contains HTML and Razor files for the front-end.
- **wwwroot:** Static files such as CSS, JavaScript, and images.

## License

This project is licensed under the MIT License.

## Contact

For any questions or inquiries, please contact zuhairkhalid229@gmail.com


