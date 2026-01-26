# mobile

A new Flutter project.

## Getting Started

This project is a starting point for a Flutter application.

A few resources to get you started if this is your first Flutter project:

- [Lab: Write your first Flutter app](https://docs.flutter.dev/get-started/codelab)
- [Cookbook: Useful Flutter samples](https://docs.flutter.dev/cookbook)

For help getting started with Flutter development, view the
[online documentation](https://docs.flutter.dev/), which offers tutorials,
samples, guidance on mobile development, and a full API reference.

# Arquitectura de MyDocApp

## Estructura de Carpetas

```
lib/
├── config/                 # Configuración de la aplicación
│   └── app_config.dart    # Variables globales y constantes de config
│
├── core/                   # Funcionalidades centrales compartidas
│   ├── constants/         # Constantes de la aplicación
│   ├── extensions/        # Extensiones de Dart
│   └── utils/             # Utilidades generales (logger, helpers, etc)
│
├── data/                   # Capa de datos
│   ├── datasources/       # Fuentes de datos (API, local storage)
│   ├── models/            # Modelos de datos (DTO)
│   └── repositories/      # Implementación de repositorios
│
├── domain/                 # Capa de dominio (lógica de negocio)
│   ├── entities/          # Entidades de negocio
│   ├── repositories/      # Interfaces de repositorios
│   └── usecases/          # Casos de uso
│
├── presentation/           # Capa de presentación (UI)
│   ├── bloc/              # BLoCs para manejo de estado
│   ├── pages/             # Páginas completas
│   ├── widgets/           # Widgets reutilizables
│   └── screens/           # Pantallas complejas
│
└── main.dart              # Punto de entrada

```

## Arquitectura Clean Architecture

Este proyecto implementa **Clean Architecture** con las siguientes capas:

### 1. **Presentation Layer** (`presentation/`)
- Widgets y páginas de UI
- BLoCs para manejo de estado
- Manejo de eventos del usuario
- Actualización de UI

### 2. **Domain Layer** (`domain/`)
- Entidades (modelos de negocio puros)
- Interfaces de repositorios
- Casos de uso (UseCases)
- Lógica de negocio independiente de frameworks

### 3. **Data Layer** (`data/`)
- Modelos de datos (DTO)
- Implementación de repositorios
- Fuentes de datos (API, base de datos local)
- Mapeo entre modelos y entidades

### 4. **Core Layer** (`core/`)
- Constantes
- Extensiones
- Utilidades compartidas
- Logger y herramientas comunes

### 5. **Config Layer** (`config/`)
- Configuración global de la aplicación
- Variables de entorno
- URLs base de API

## Flujo de Datos

```
UI (Pages/Widgets)
    ↓
BLoC (Manejo de Estado)
    ↓
UseCases (Lógica de Negocio)
    ↓
Repositories (Implementación)
    ↓
DataSources (API / Local Storage)
```

## Mejores Prácticas

✅ **Separación de responsabilidades** - Cada capa tiene un propósito específico
✅ **Reutilización** - Widgets comunes en `widgets/`
✅ **Testabilidad** - Fácil de testear cada capa independientemente
✅ **Mantenibilidad** - Código limpio y organizado
✅ **Escalabilidad** - Fácil agregar nuevas funcionalidades

## Ejemplo de Flujo Completo

```dart
// 1. Usuario hace clic en botón (Presentation)
CustomButton(
  onPressed: () {
    context.read<UserBloc>().add(FetchUserEvent());
  },
)

// 2. BLoC maneja el evento (Presentation)
on<FetchUserEvent>((event, emit) async {
  emit(UserLoading());
  final result = await fetchUserUseCase();
})

// 3. UseCase ejecuta lógica de negocio (Domain)
final user = await userRepository.getUser();

// 4. Repositorio obtiene datos (Data)
final userModel = await apiDataSource.fetchUser();

// 5. UI se actualiza con el resultado (Presentation)
if (state is UserLoaded) {
  return Text(state.user.name);
}
```

## Convenciones de Nombres

- **Archivos**: `snake_case` (user_model.dart)
- **Clases**: `PascalCase` (UserModel)
- **Métodos**: `camelCase` (fetchUser())
- **Constantes**: `camelCase` (apiBaseUrl)
- **Variables privadas**: `_camelCase` (_counter)

