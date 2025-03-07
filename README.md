# 📜 TodoList API  

**TodoList API** adalah layanan RESTful yang memungkinkan pengguna untuk mengelola daftar tugas (**Todo List**).  
Proyek ini dibuat menggunakan **.NET** dan **SQL Server/MySQL** sebagai database, serta dikembangkan di **Visual Studio 2022**.  

---

## 👌 Fitur  
✅ Menampilkan semua tugas (**GET /api/todos**)  
✅ Mengambil detail tugas berdasarkan ID (**GET /api/todos/{id}**)  
✅ Menambahkan tugas baru (**POST /api/todos**)  
✅ Memperbarui tugas (**PUT /api/todos/{id}**)  
✅ Menghapus tugas (**DELETE /api/todos/{id}**)  

---

## 🛠 Teknologi yang Digunakan  
- **.NET 6/7/8** (sesuai versi yang digunakan)  
- **ASP.NET Core Web API**  
- **Entity Framework Core**  
- **SQL Server / MySQL**  
- **Visual Studio 2022**  
- **Postman (untuk testing API)**  

---

## 📦 Instalasi & Menjalankan Proyek  

### 1️⃣ **Clone Repository**  
```sh
git clone https://github.com/username/tefa-net-muhammaddanishdhiyaulhaq.git
cd repo-todolist
```

### 2️⃣ **Konfigurasi Database**  
1. Pastikan **SQL Server / MySQL** telah terinstal dan berjalan.  
2. Ubah **connection string** pada `appsettings.json` sesuai dengan konfigurasi database kamu:  
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=TodoListDB;User Id=your_user;Password=your_password;"
   }
   ```
3. Jalankan migrasi database:  
   ```sh
   dotnet ef database update
   ```

### 3️⃣ **Menjalankan Proyek**  
- **Di Visual Studio 2022:**  
  1. Buka solusi proyek (`.sln`) di **Visual Studio 2022**  
  2. Pilih **Debug -> Start Debugging (F5)**  
  3. API akan berjalan di **`[https://localhost:4000/api/Todo]`**  

- **Di Terminal:**  
  ```sh
  dotnet run
  ```

---

## 📌 API Documentation  
Gunakan **Postman** atau **Swagger UI** untuk menguji API ini.  

### 🔹 **Menampilkan Semua Tugas**  
- **Endpoint:** `GET /api/todos`  
- **Response:**
  ```json
  [
    {
      "id": 1,
      "title": "Belajar API",
      "description": "Mempelajari cara membuat API dengan .NET",
    }
  ]
  ```

### 🔹 **Menambahkan Tugas Baru**  
- **Endpoint:** `POST /api/todos`  
- **Body Request:**
  ```json
  {
    "title": "Mengerjakan Laporan",
    "description": "Membuat laporan mingguan",
  }
  ```
- **Response (201 Created):**
  ```json
  {
    "message": "Todo berhasil ditambahkan",
    "todo": {
      "id": 2,
      "title": "Mengerjakan Laporan",
      "description": "Membuat laporan mingguan",
    }
  }
  ```

--- 
