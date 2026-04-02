# 🛒 AI Destekli E-Ticaret | AI-Powered E-Commerce

> **BTK Akademi** projesi — ASP.NET Core + Google Gemini AI

---

## 🇹🇷 Türkçe

### Proje Hakkında

Bu proje, **ASP.NET Core MVC (.NET 9)** ile geliştirilmiş, yapay zeka destekli bir e-ticaret web uygulamasıdır. Kullanıcılar ürünleri görüntüleyip sepetlerine ekleyebilirken, entegre edilmiş **Google Gemini AI** sohbet asistanı sayesinde alışveriş deneyimlerini kişiselleştirebilirler. Yöneticiler ürün yönetimini (ekleme, düzenleme, silme) özel admin paneli üzerinden gerçekleştirebilir.

### Özellikler

- 🤖 **AI Sohbet Asistanı** — Google Gemini 2.5 Flash entegrasyonu ile gerçek zamanlı yapay zeka sohbet desteği
- 🛍️ **Ürün Kataloğu** — Kategori, fiyat, stok ve resim bilgileriyle ürün listeleme ve detay görüntüleme
- 🛒 **Alışveriş Sepeti** — Kullanıcıya özel sepet; ürün ekleme, miktarı artırma/azaltma (stok kontrolü ile)
- 👤 **Kimlik Doğrulama** — ASP.NET Identity ile üyelik sistemi (kayıt ol, giriş yap, çıkış yap)
- 🔐 **Rol Tabanlı Yetkilendirme** — Admin rolü ile ürün oluşturma, güncelleme ve silme
- 📁 **Resim Yükleme** — Ürünlere `wwwroot/images` klasörüne dosya yükleme desteği
- 🗄️ **SQLite Veritabanı** — Hafif ve dosya tabanlı veritabanı, Entity Framework Core ile yönetim

### Kullanılan Teknolojiler

| Teknoloji | Versiyon |
|---|---|
| ASP.NET Core MVC | .NET 9 |
| Entity Framework Core | 9.0.0 |
| ASP.NET Core Identity | 9.0.0 |
| SQLite | — |
| Google Gemini API | gemini-2.5-flash |
| Razor Views | — |

### Kurulum ve Çalıştırma

#### Ön Gereksinimler

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Google Gemini API anahtarı ([Google AI Studio](https://aistudio.google.com/) üzerinden edinebilirsiniz)

#### Adımlar

1. **Depoyu klonlayın:**
   ```bash
   git clone https://github.com/MertBuyuknisan/AI_Destekli_E-Ticaret_BTK.git
   cd AI_Destekli_E-Ticaret_BTK
   ```

2. **Gemini API anahtarını ayarlayın** (`User Secrets` ya da `appsettings.json` ile):
   ```bash
   cd AI_Destekli_E-ticaret
   dotnet user-secrets set "GeminiApi:ApiKey" "BURAYA_API_ANAHTARINIZI_YAZIN"
   ```

3. **Veritabanı migrasyonlarını uygulayın:**
   ```bash
   dotnet ef database update
   ```

4. **Uygulamayı başlatın:**
   ```bash
   dotnet run
   ```

5. Tarayıcınızda `https://localhost:PORT` adresine gidin.

#### Varsayılan Admin Hesabı

Uygulama ilk çalıştırıldığında otomatik olarak bir admin kullanıcısı oluşturulur:

| Alan | Değer |
|---|---|
| E-posta | `admin@test.com` |
| Şifre | `1234567890Admin.` |

> ⚠️ **Güvenlik notu:** Canlı (production) ortama geçmeden önce admin şifresini mutlaka değiştirin.

### Proje Yapısı

```
AI_Destekli_E-ticaret/
├── Controllers/
│   ├── AccountController.cs   # Kayıt, giriş, çıkış işlemleri
│   ├── CartController.cs      # Sepet yönetimi
│   ├── ChatController.cs      # AI sohbet API endpoint'i
│   ├── HomeController.cs      # Ana sayfa
│   └── ProductController.cs  # Ürün CRUD (Admin)
├── Models/
│   ├── AppDbContext.cs        # EF Core veritabanı bağlamı
│   ├── AppUser.cs             # Kimlik kullanıcı modeli
│   ├── CartItem.cs            # Sepet kalemi modeli
│   ├── GeminiSettings.cs      # Gemini API yapılandırması
│   ├── Product.cs             # Ürün modeli
│   └── ViewModels/            # Login ve Register ViewModel'leri
├── Services/
│   └── GeminiChatService.cs   # Google Gemini API istemcisi
├── Views/                     # Razor şablonları
├── Migrations/                # EF Core migrations
├── wwwroot/                   # Statik dosyalar (CSS, JS, resimler)
├── appsettings.json
└── Program.cs                 # Uygulama başlangıç noktası
```

---

## 🇬🇧 English

### About the Project

This is an **AI-powered e-commerce web application** built with **ASP.NET Core MVC (.NET 9)**. Users can browse products and add them to a shopping cart, while an integrated **Google Gemini AI** chat assistant enhances the shopping experience. Administrators can manage the product catalogue (create, update, delete) through a dedicated admin interface.

### Features

- 🤖 **AI Chat Assistant** — Real-time conversational AI powered by Google Gemini 2.5 Flash
- 🛍️ **Product Catalogue** — List and view products with category, price, stock, and image support
- 🛒 **Shopping Cart** — Per-user cart with add, increase/decrease quantity (stock-aware)
- 👤 **Authentication** — Full membership system via ASP.NET Identity (register, login, logout)
- 🔐 **Role-based Authorization** — Admin role for product creation, update, and deletion
- 📁 **Image Upload** — Upload product images saved to `wwwroot/images`
- 🗄️ **SQLite Database** — Lightweight file-based database managed with Entity Framework Core

### Tech Stack

| Technology | Version |
|---|---|
| ASP.NET Core MVC | .NET 9 |
| Entity Framework Core | 9.0.0 |
| ASP.NET Core Identity | 9.0.0 |
| SQLite | — |
| Google Gemini API | gemini-2.5-flash |
| Razor Views | — |

### Getting Started

#### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A Google Gemini API key (obtain one from [Google AI Studio](https://aistudio.google.com/))

#### Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/MertBuyuknisan/AI_Destekli_E-Ticaret_BTK.git
   cd AI_Destekli_E-Ticaret_BTK
   ```

2. **Set your Gemini API key** (via User Secrets or `appsettings.json`):
   ```bash
   cd AI_Destekli_E-ticaret
   dotnet user-secrets set "GeminiApi:ApiKey" "YOUR_API_KEY_HERE"
   ```

3. **Apply database migrations:**
   ```bash
   dotnet ef database update
   ```

4. **Run the application:**
   ```bash
   dotnet run
   ```

5. Open `https://localhost:PORT` in your browser.

#### Default Admin Account

An admin user is automatically seeded on first run:

| Field | Value |
|---|---|
| Email | `admin@test.com` |
| Password | `1234567890Admin.` |

> ⚠️ **Security note:** Change the admin password before deploying to a production environment.

### Project Structure

```
AI_Destekli_E-ticaret/
├── Controllers/
│   ├── AccountController.cs   # Register, login, logout
│   ├── CartController.cs      # Shopping cart management
│   ├── ChatController.cs      # AI chat API endpoint
│   ├── HomeController.cs      # Home page
│   └── ProductController.cs  # Product CRUD (Admin only)
├── Models/
│   ├── AppDbContext.cs        # EF Core database context
│   ├── AppUser.cs             # Identity user model
│   ├── CartItem.cs            # Cart item model
│   ├── GeminiSettings.cs      # Gemini API configuration
│   ├── Product.cs             # Product model
│   └── ViewModels/            # Login & Register ViewModels
├── Services/
│   └── GeminiChatService.cs   # Google Gemini API client
├── Views/                     # Razor templates
├── Migrations/                # EF Core migrations
├── wwwroot/                   # Static files (CSS, JS, images)
├── appsettings.json
└── Program.cs                 # Application entry point
```

### Architecture Overview

```
Browser
  │
  ▼
ASP.NET Core MVC (Controllers + Razor Views)
  │           │
  ▼           ▼
EF Core    Gemini API
(SQLite)   (HTTP Client)
```

The application follows the **MVC pattern**. `GeminiChatService` acts as an HTTP client wrapper around the Gemini REST API, registered via `AddHttpClient<T>` for proper `HttpClient` lifecycle management. Authentication and authorisation are handled by ASP.NET Core Identity with cookie-based sessions.

---

*Bu proje BTK Akademi eğitimi kapsamında geliştirilmiştir. / This project was developed as part of a BTK Akademi course.*
