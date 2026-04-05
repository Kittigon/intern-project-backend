#  MyApi - ASP.NET Core REST API

##  Overview

Backend API สำหรับระบบจัดการ **สินค้า (Products), ผู้ใช้ (Users), และคำสั่งซื้อ (Orders)**
พัฒนาด้วย **ASP.NET Core 8 + Entity Framework Core**

---

##  Quick Start

```bash
git clone <repository-url>
cd MyApi
dotnet restore
dotnet run
```

👉 API จะรันที่: `http://localhost:5000`

---

##  Tech Stack

* ASP.NET Core 8
* Entity Framework Core
* SQL Server
* Docker (optional)

---

##  Project Structure

```
MyApi/
├── Controllers/        # API endpoints
├── Models/             # Database models
├── DTOs/               # Request / Response models
├── AppDbContext.cs     # Database context
├── Program.cs          # App entry point
└── appsettings.json    # Config
```

---

##  API Endpoints

### Products

| Method | Endpoint           | Description       |
| ------ | ------------------ | ----------------- |
| GET    | /api/products      | Get all products  |
| GET    | /api/products/{id} | Get product by id |
| POST   | /api/products      | Create product    |
| PUT    | /api/products/{id} | Update product    |
| DELETE | /api/products/{id} | Delete product    |

### Users

| Method | Endpoint        | Description   |
| ------ | --------------- | ------------- |
| GET    | /api/users      | Get all users |
| POST   | /api/users      | Create user   |
| PUT    | /api/users/{id} | Update user   |
| DELETE | /api/users/{id} | Delete user   |

### Orders

| Method | Endpoint         | Description    |
| ------ | ---------------- | -------------- |
| GET    | /api/orders      | Get all orders |
| POST   | /api/orders      | Create order   |
| DELETE | /api/orders/{id} | Delete order   |

---

##  Configuration

ตั้งค่า Database ใน `appsettings.json` หรือ `appsettings.Development.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_connection_here"
  }
}
```

---

##  Run with Docker (Optional)

```bash
docker-compose up -d
```

---
