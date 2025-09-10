# 📚 Library Management System
### "Gestiona tu biblioteca de forma sencilla y moderna" ✨

<div align="center">

Aplicación web en ASP.NET Core MVC con base de datos SQLite

<p> <img src="https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core"> <img src="https://img.shields.io/badge/SQLite-3.46-003B57?style=for-the-badge&logo=sqlite&logoColor=white" alt="SQLite"> <img src="https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white" alt="Bootstrap"> </p>




🌐 Demo en Vivo
 • 🐛 Reportar Bug
 • ✨ Solicitar Feature

</div>

## 📖 Sobre el Proyecto

Library Management System es una aplicación web desarrollada en ASP.NET Core MVC con base de datos SQLite.
Permite gestionar libros, autores, préstamos y reservas, ofreciendo una interfaz amigable y moderna con Bootstrap.

### ✨ Características

🏠 Página de inicio con logo, navegación y mensaje de bienvenida

📚 Catálogo de libros en tarjetas con título, autor, estado e imagen (ejemplo: quijote.jpg)

🔎 Búsqueda por título o autor

✅ Gestión de préstamos y reservas

🖼️ Soporte de imágenes para cada libro

🎨 Diseño responsivo con Bootstrap 5

## 📸 Screenshots

<div align="center">

### 🖥️ Vista de Escritorio
<img width="1872" height="672" alt="image" src="https://github.com/user-attachments/assets/2d35f66c-b553-4da4-90e1-a80eb2ee9a69" />
<img width="1486" height="513" alt="image" src="https://github.com/user-attachments/assets/98e97239-7c0a-4281-b0a7-cf5c1b30a81a" />
<img width="1402" height="450" alt="image" src="https://github.com/user-attachments/assets/b2de93ce-97f9-4f63-be85-7650e56dae9a" />
<img width="1408" height="457" alt="image" src="https://github.com/user-attachments/assets/7a2c164a-f176-4786-8873-eb5052bac10d" />
<img width="1392" height="428" alt="image" src="https://github.com/user-attachments/assets/ff4e2f95-d325-4b3b-a1a1-408ebbedf44a" />
<img width="1382" height="461" alt="image" src="https://github.com/user-attachments/assets/26797cd9-6ad9-4d29-8f2d-b586a66c5a29" />








</div>

## 🚀 Instalación y Configuración

### 📋 Requisitos Previos

Asegúrate de tener instalado:

.NET SDK 8.0+ (Descargar aquí
)

SQLite (ya viene integrado, no requiere servidor)

Un editor como Visual Studio o Visual Studio Code

### ⚡ Instalación Rápida

```bash

1. 📂 Clonar el repositorio

git clone https://github.com/yuban-hilarion/library-management.git

cd library-management

2. 📦 Restaurar dependencias

dotnet restore

3. 🗄️ Ejecutar migraciones y crear la base de datos

dotnet ef database update

4. 🚀 Ejecutar la aplicación

dotnet run
```

Abre tu navegador en: http://localhost:5000

## 🏗️ Estructura del Proyecto

```bash
LibraryManagement/
├── Controllers/ # 🎮 Lógica de controladores (Books, Prestamos, Reservas)
├── Models/ # 📊 Modelos (Libro, Autor, Usuario, etc.)
├── Views/ # 🖼️ Vistas en Razor (cshtml)
│ ├── Books/
│ │ ├── Index.cshtml # 📚 Vista de catálogo con cards
│ │ └── Create.cshtml
│ └── Shared/
│ └── _Layout.cshtml
├── wwwroot/
│ ├── images/ # 🖼️ Carpeta para imágenes (ej: quijote.jpg)
│ └── css/ # 🎨 Estilos adicionales
└── appsettings.json # ⚙️ Configuración (cadena de conexión SQLite)
```

## 💻 Ejemplo de Código

### 📚 Mostrar libros con imagen
```csharp
<img src="~/images/@libro.Imagen" class="card-img-top" alt="@libro.Titulo" style="max-height:240px;object-fit:cover;" />
```

### 🔎 Búsqueda en el catálogo
```csharp

<form method="get" asp-controller="Books" asp-action="Index"> <input name="search" class="form-control" placeholder="Buscar por título o autor" /> <button class="btn btn-outline-secondary">Buscar</button> </form> U´´´
```
## 🤝 Contribuir

¡Las contribuciones son bienvenidas! Aquí puedes ayudar:

Fork el proyecto

Crea tu rama feature (git checkout -b feature/NuevaCaracteristica)

Commit tus cambios (git commit -m 'Add: nueva característica')

Push a la rama (git push origin feature/NuevaCaracteristica)

Abre un Pull Request

## 🌟 Roadmap

 📖 Módulo de usuarios (lectores / administradores)

 📊 Reportes de préstamos y reservas

 🌐 Internacionalización (ES/EN)

 🔐 Autenticación y roles

## 📄 Licencia

Este proyecto está bajo la Licencia MIT © 2025 Yuban Hilarion

"Permite uso comercial, modificaciones y distribución. Solo requiere atribución."

Ver el archivo LICENSE
 para más detalles.

## 👨‍💻 Autor

Yuban Hilarion

GitHub: @Yuban29

<div align="center">

Desarrollado con 💙 por Yuban Hilarion


</div>
