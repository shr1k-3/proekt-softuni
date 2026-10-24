# Movie Catalog

ASP.NET Core MVC (.NET 8) приложение за каталог с филми. Използва Entity Framework Core и SQL Server LocalDB.

## Функционалности
- Пълен CRUD за филми (Create, Read, Update, Delete)
- Преглед на режисьори с техните филми
- Жанрове в падащо меню при добавяне/редакция
- Валидация на данните (задължително заглавие, година 1888-2100, рейтинг 1-10)

## Структура
- **Entities:** Movie, Director, Genre
- **Controllers:** MoviesController, DirectorsController
- **Views:** Movies (Index, Details, Create, Edit, Delete), Directors (Index)

## Изисквания
- .NET 8 SDK
- SQL Server LocalDB (идва с Visual Studio)
- dotnet-ef: `dotnet tool install --global dotnet-ef`

## Стартиране
```bash
dotnet restore
dotnet ef database update
dotnet run
```
Отвори адреса, показан в конзолата (напр. https://localhost:5001).

## Миграции
```bash
dotnet ef migrations add <ИмеНаМиграция>
dotnet ef database update
```

## Connection string
Намира се в `appsettings.json` (`DefaultConnection`).


Проектът ми е готов, просто забравих да го кача в github и разбрах, че трябва в 3 различни дни да се качват или променят файлове а сегашната дата и час е 24/10/2026 23:50 и затова качвам само README понеже нямам голяма представа как се работи с github и ми се видя като най-лесното и бързо нещо за качване.
