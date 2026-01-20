# MyDoc - Sistema de Gestión de Citas Médicas

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Angular](https://img.shields.io/badge/Angular-21-DD0031?logo=angular)](https://angular.io/)
[![Flutter](https://img.shields.io/badge/Flutter-3.10-02569B?logo=flutter)](https://flutter.dev/)

Sistema integral de gestión de citas médicas que permite a pacientes y profesionales de la salud administrar consultas, historiales médicos, prescripciones y más a través de múltiples plataformas.

## Características

### Backend (API REST)
- Autenticación y autorización con JWT
- Gestión completa de citas médicas
- Administración de doctores y clínicas
- Historiales médicos completos
- Prescripciones y medicamentos
- Sistema de notificaciones
- Consultas y reportes

### Frontend Web
- Interfaz moderna con Angular Material
- Progressive Web App (PWA)
- Server-Side Rendering (SSR)
- Gestión de estado reactiva con RxJS
- Dashboard interactivo
- Modo oscuro

### Mobile App
- Aplicación nativa para iOS y Android
- Navegación fluida con Go Router
- Almacenamiento seguro de credenciales

## Arquitectura

Este proyecto sigue una arquitectura de **Monorepo** con tres aplicaciones principales:

```
MyDoc/
├── backend/     → API REST (.NET 10)
├── frontend/    → Aplicación Web (Angular 21)
└── mobile/      → Aplicación Móvil (Flutter)
```

### Backend - Multi-Layer Architecture
- **MyDoc (API)**: Capa de presentación con controladores y middleware
- **MyDoc.Application**: Lógica de negocio, DTOs y servicios DAL
- **MyDoc.Infrastructure**: Modelos de datos, DbContext y configuración

## 📁 Estructura del Proyecto

```
MyDoc/
├── backend/
│   ├── backend.slnx                        # Solución de Visual Studio
│   ├── GenerateControllers.ps1            # Script generación de controladores
│   ├── GenerateDALServices.ps1            # Script generación de servicios DAL
│   ├── Recreate-Models.ps1                # Script regeneración de modelos
│   │
│   ├── MyDoc/                             # API Principal
│   │   ├── Controllers/                   # Controladores REST
│   │   ├── Middleware/                    # Middleware personalizado
│   │   ├── Program.cs                     # Configuración de la aplicación
│   │   └── appsettings.json               # Configuración
│   │
│   ├── MyDoc.Application/                 # Capa de Aplicación
│   │   ├── BO/                            # Business Objects
│   │   │   ├── Constants/                 # Constantes
│   │   │   └── DTO/                       # Data Transfer Objects
│   │   ├── DAL/                           # Data Access Layer
│   │   ├── Helper/                        # Utilidades
│   │   └── Services/                      # Servicios de negocio
│   │
│   └── MyDoc.Infrastructure/              # Capa de Infraestructura
│       ├── AuthModels/                    # Modelos de autenticación
│       └── Models/                        # Modelos de base de datos
│
├── frontend/
│   ├── angular.json                       # Configuración de Angular
│   ├── package.json                       # Dependencias npm
│   ├── ngsw-config.json                   # Service Worker config
│   │
│   └── src/
│       ├── app/                           # Módulos y componentes
│       ├── assets/                        # Recursos estáticos
│       ├── environments/                  # Variables de entorno
│       ├── main.ts                        # Entry point
│       └── styles.scss                    # Estilos globales
│
└── mobile/
    ├── pubspec.yaml                       # Dependencias Flutter
    ├── analysis_options.yaml              # Configuración de análisis
    │
    ├── lib/
    │   └── main.dart                      # Entry point
    │
    ├── android/                           # Configuración Android
    └── ios/                               # Configuración iOS
```

## Tecnologías

### Backend
- **Framework**: .NET 10.0
- **ORM**: Entity Framework Core 10.0.2
- **Base de datos**: SQL Server
- **Autenticación**: JWT Bearer
- **Documentación**: Swagger/OpenAPI
- **IDE**: Visual Studio 2022

### Frontend
- **Framework**: Angular 21.0
- **UI**: Angular Material 21.0.6
- **Estilos**: Bootstrap 5.3.8, SCSS
- **HTTP**: HttpClient
- **Estado**: RxJS 7.8
- **SSR**: Angular SSR
- **PWA**: Service Worker
- **IDE**: Visual Studio Code

### Mobile
- **Framework**: Flutter 3.10+
- **Lenguaje**: Dart 3.10.7
- **Navegación**: Go Router 17.0.1
- **Estado**: Flutter BLoC 9.1.1
- **HTTP**: Dio 5.9.0
- **Almacenamiento**: Flutter Secure Storage 10.0.0
- **IDE**: Visual Studio Code

## Requisitos Previos

### Backend
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (opcional pero recomendado)
- [SQL Server](https://www.microsoft.com/sql-server) (o SQL Server Express)
- PowerShell 5.0+

### Frontend
- [Node.js](https://nodejs.org/) 20.x o superior
- [npm](https://www.npmjs.com/) 11.6.0 o superior
- [Angular CLI](https://angular.io/cli) 21.x
- [Visual Studio Code](https://code.visualstudio.com/)

### Mobile
- [Flutter SDK](https://flutter.dev/docs/get-started/install) 3.10+
- [Dart SDK](https://dart.dev/get-dart) 3.10.7+
- [Android Studio](https://developer.android.com/studio) (para desarrollo Android)
- [Xcode](https://developer.apple.com/xcode/) (para desarrollo iOS, solo macOS)
- [Visual Studio Code](https://code.visualstudio.com/) con extensión de Flutter


#### Instalar dependencias
```bash
cd backend
dotnet restore
```

### 3. Frontend

```bash
cd frontend
npm install
```

### 4. Mobile

```bash
cd mobile
flutter pub get
```

## Ejecución

### Backend

#### Usando Visual Studio
1. Abre `backend/backend.slnx` en Visual Studio
2. Establece `MyDoc` como proyecto de inicio
3. Presiona F5 o haz clic en "Run"

La API estará disponible en:
- **HTTP**: https://localhost:7000
- **Swagger UI**: https://localhost:7000/swagger

### Frontend

#### Modo desarrollo
```bash
cd frontend
npm start
# o
ng serve
```

La aplicación estará disponible en: http://localhost:4200

## 📄 Licencia

Este proyecto está bajo la licencia especificada en el archivo [LICENSE](LICENSE).

---