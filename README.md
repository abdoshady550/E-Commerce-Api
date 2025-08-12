# 🛍️ E-Commerce API

Welcome to the E-Commerce API!  
This project is a robust backend solution for managing products, orders, users, and more for any online shop.  
Built for speed, scalability, and simplicity! 🚀

![E-Commerce API](https://cdn.learnwoo.com/wp-content/uploads/2021/11/types-of-APIs.png)

---

## ✨ Features

- 🛒 **Product Management**  
  Create, update, and list products with ease.

- 👤 **User Authentication**  
  Secure login, registration, and profile management.

- 📦 **Order Processing**  
  Seamless order creation, tracking, and history.

- 🏷️ **Category & Tag Support**  
  Organize products for optimal browsing.

- 🔒 **Security**  
  JWT authentication & best practices.

- 🛠️ **Built with .NET for robust and scalable APIs**
- 📦 **Clean project structure for easy understanding**
- ⚡ **Quick to set up and start running**
- 🔒 **Ready to secure and extend**
- 📦 **Custom API responses for consistency**
- 🛡️ **Simple rate limiting middleware to prevent abuse**

---

## 🌐 Live Domain

You can access the API here:  
**[ecommercebuying.runasp.net/](https://ecommercebuying.runasp.net/)**

---

## 🗂️ Entity Relationship Diagram (ERD)

Visualize your data model and relationships:

![ERD](https://github.com/abdoshady550/E-Commerce-Api/blob/master/ecommerce_erd.png)
> ERD for E-Commerce API project

---

## 🧪 Testing the API with Postman

You can easily test all API endpoints using Postman!  
Postman helps you explore, debug, and visualize responses for your requests.

### 📋 Example Postman Collection Structure
- Auth: Register, Login
- Category: Add, Update, Delete, Get All, Get By Id
- Products: Add, Edit, Delete, Pagination, Search
- Cart: Get, Add, Delete
- Buying Request: Get Requests

#### 🖼️ Sample Postman Response

![Postman Result](https://github.com/abdoshady550/E-Commerce-Api/blob/master/Screenshot%202025-08-12%20114615.png)
> Example of product endpoint response in Postman

This image shows how products look when you request them via:
```
GET /api/Products?page=1&pageSize=10
```
You get clear, visualized results with product details and prices!

---

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/abdoshady550/E-Commerce-Api.git
   cd E-Commerce-Api
   ```

2. **Install dependencies**
   ```bash
   dotnet restore
   ```

3. **Configure your environment**
   - انسخ ملف `appsettings.example.json` إلى `appsettings.json`
   - حدّث بيانات الاتصال بقاعدة البيانات و الـ secret keys في ملف الإعدادات

4. **Run the server**
   ```bash
   dotnet run
   ```

---

## 📚 API Documentation

See the [API Docs](./docs/API.md) for detailed endpoints and usage.

---

## 🏗️ Tech Stack

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT
- Swagger (for docs)

---

## 🤝 Contributing

Contributions are welcome!  
Please open an [issue](https://github.com/abdoshady550/E-Commerce-Api/issues) or submit a PR.

---

## 💬 Contact

Questions, suggestions, or feedback?  
Open an issue or reach out on [GitHub](https://github.com/abdoshady550).

---

## 🌟 Star this repo

If you find this project helpful, please give it a ⭐!
