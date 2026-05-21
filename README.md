# 🎵 MusicShop — интернет-магазин музыкальных инструментов

<div align="center">

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![Blazor](https://img.shields.io/badge/Blazor-Server-brightgreen)
![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![Docker](https://img.shields.io/badge/Docker-✓-2496ED)
![License](https://img.shields.io/badge/License-MIT-green)

**Курсовой проект по дисциплине «Кроссплатформенная среда исполнения программного обеспечения»**

</div>

---

## 📖 О проекте

**MusicShop** — это веб-приложение интернет-магазина музыкальных инструментов, разработанное с использованием современного стека технологий .NET 8, ASP.NET Core, Blazor Server и PostgreSQL. Приложение позволяет пользователям просматривать каталог музыкальных инструментов, управлять корзиной покупок, оформлять заказы с проверкой остатков на складе и отслеживать историю заказов.

Проект демонстрирует навыки работы с кроссплатформенной средой .NET, Entity Framework Core (Code First), Dependency Injection, контейнеризацией Docker, а также построением интерактивных веб-интерфейсов на Blazor Server.

### 🎸 Основные возможности

- **Просмотр каталога инструментов** – список товаров с ценами, изображениями и описанием
- **Фильтрация по жанрам** – отображение инструментов выбранного жанра (Гитары, Клавишные, Ударные, Струнные, Духовые)
- **Детальная карточка товара** – просмотр полной информации и характеристик инструмента
- **Управление корзиной** – добавление товаров, изменение количества, удаление позиций, расчёт итоговой суммы
- **Оформление заказа** – форма с валидацией данных покупателя, проверка остатков на складе
- **История заказов** – просмотр ранее оформленных заказов с детализацией по позициям
- **Демо-пользователь** – автоматическое создание гостевого аккаунта (guest@musicshop.local) без необходимости регистрации
- **Модальные окна** – подтверждение действий (очистка корзины, удаление позиции)
- **Полная контейнеризация** – запуск приложения и базы данных через Docker Compose

---

## 🛠 Технологии

| Технология | Назначение |
|------------|------------|
| .NET 8 | Кроссплатформенная среда исполнения |
| ASP.NET Core | Веб-фреймворк |
| Blazor Server | Интерактивный веб-интерфейс на C# |
| Entity Framework Core 8 | ORM, Code First, миграции |
| PostgreSQL 16 | Реляционная база данных |
| FluentValidation | Валидация моделей (Buyer, OrderForm) |
| Blazored.Modal | Модальные окна для Blazor |
| Docker / Docker Compose | Контейнеризация и оркестрация |
| Git | Система контроля версий |

---

## 📁 Структура проекта
```
MusicShop/
├── MusicShop/ # 📦 Основной веб-проект
│ ├── Components/ # 🧩 Blazor компоненты
│ │ ├── Layout/ # 🏗️ Макеты и навигация
│ │ │ ├── MainLayout.razor
│ │ │ └── NavMenu.razor
│ │ └── Pages/ # 📄 Страницы приложения
│ │ ├── Index.razor # Главная страница
│ │ ├── Catalog.razor # Каталог инструментов
│ │ ├── InstrumentPage.razor # Детальная карточка инструмента
│ │ ├── Basket.razor # Корзина покупок
│ │ ├── PlaceOrder.razor # Оформление заказа
│ │ └── Purchases.razor # История заказов
│ │
│ ├── Data/ # 🗄️ Доступ к данным
│ │ ├── Configurations/ # ⚙️ Fluent API конфигурации
│ │ │ ├── BuyerConfiguration.cs
│ │ │ ├── GenreConfiguration.cs
│ │ │ ├── InstrumentConfiguration.cs
│ │ │ ├── InstrumentSpecsConfiguration.cs
│ │ │ └── PurchaseConfiguration.cs
│ │ ├── CatalogSeeder.cs # 🌱 Начальные данные (Seed)
│ │ └── ShopContext.cs # 🔗 Контекст БД
│ │
│ ├── Models/ # 📋 Модели сущностей
│ │ ├── Buyer.cs # 👤 Покупатель
│ │ ├── Genre.cs # 🏷️ Жанр/категория инструмента
│ │ ├── Instrument.cs # 🎸 Музыкальный инструмент
│ │ ├── InstrumentSpecs.cs # 📊 Характеристики инструмента (1:1)
│ │ ├── Purchase.cs # 📦 Заказ
│ │ ├── PurchaseEntry.cs # 📃 Позиция заказа
│ │ └── BasketEntry.cs # 🛒 Корзина
│ │
│ ├── Repositories/ # 📚 Репозитории
│ │ ├── IDataStore.cs # 🔌 Интерфейс универсального репозитория
│ │ ├── DataStore.cs # ⚙️ Реализация универсального репозитория
│ │ ├── InstrumentRepository.cs # 🎸 Репозиторий инструментов (+ Include)
│ │ └── PurchaseRepository.cs # 📦 Репозиторий заказов (+ Include)
│ │
│ ├── Services/ # ⚙️ Бизнес-логика
│ │ ├── GenreService.cs # CRUD жанров
│ │ ├── InstrumentService.cs # CRUD инструментов
│ │ ├── BasketService.cs # Управление корзиной
│ │ ├── PurchaseService.cs # Создание заказов, списание товаров
│ │ └── SessionBuyerService.cs # 👤 Демо-покупатель (guest)
│ │
│ ├── Validators/ # ✅ FluentValidation валидаторы
│ │ └── FormValidators.cs # Валидация Buyer и OrderForm
│ │
│ ├── Migrations/ # 📜 EF Core миграции
│ ├── wwwroot/ # 🌐 Статические файлы
│ │ ├── css/
│ │ ├── js/
│ │ └── images/
│ │
│ ├── appsettings.json # ⚙️ Конфигурация (строки подключения)
│ ├── appsettings.Development.json # 🛠️ Конфигурация для разработки
│ ├── Program.cs # 🚀 Точка входа, DI, миграции
│ └── Dockerfile # 🐳 Docker-образ приложения
│
├── docker-compose.yml # 🐳 Оркестрация контейнеров
├── README.md # 📖 Документация
└── .gitignore # 🚫 Исключения для Git
```
---

## 🚀 Быстрый старт

### Предварительные требования

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (для локальной разработки)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (для контейнеризации)
- [PostgreSQL](https://www.postgresql.org/download/) (при локальном запуске без Docker)
- [Git](https://git-scm.com/)

---

## 🐳 Запуск через Docker (рекомендуемый способ)

Этот способ не требует установки .NET SDK и PostgreSQL на хост-машине — всё работает в изолированных контейнерах.

### Шаг 1: Клонирование репозитория

```bash
git clone https://github.com/your-username/MusicShop.git
cd MusicShop
