# GenshinFan API

Este es el backend de la aplicación **GenshinFan**, una plataforma dedicada a mostrar imágenes y videos oficiales del juego **Genshin Impact**, incluyendo contenido relacionado con personajes, regiones, elementos y más.

## 🚧 Estado del proyecto

En desarrollo 🛠️  
Actualmente se está trabajando en el diseño de la base de datos y en los primeros endpoints.

## 🔧 Tecnologías

- **ASP.NET Core Web API**
- **SQL Server**
- **Entity Framework Core**

## 📦 ¿Qué hace esta API?

- Expone endpoints REST para acceder a:
  - Personajes del juego
  - Regiones del mundo de Teyvat
  - Elementos (Pyro, Hydro, etc.)
  - Imágenes oficiales y wallpapers
  - Videos relacionados al juego

Esta API es consumida por:

- Un **panel de administración** desarrollado en **React**
- Una **web pública estática** generada con **Astro**



## 📁 Estructura esperada

- `/Controllers` – Controladores de la API
- `/Models` – Clases de entidades del dominio
- `/Data` – Contexto de base de datos (DbContext)
- `/DTOs` – Objetos de transferencia de datos
- `/Migrations` – Migraciones EF Core


