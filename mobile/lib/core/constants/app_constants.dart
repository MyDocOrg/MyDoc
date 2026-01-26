/// Constantes globales de la aplicación
class AppConstants {
  // Mensajes
  static const String welcomeMessage = 'Bienvenido a MyDoc';
  static const String errorMessage = 'Ha ocurrido un error';
  static const String successMessage = 'Operación exitosa';
  static const String loadingMessage = 'Cargando...';

  // Errores
  static const String connectionError = 'Error de conexión';
  static const String timeoutError = 'La solicitud tardó demasiado';
  static const String unknownError = 'Error desconocido';
  static const String validationError = 'Error de validación';

  // Valores por defecto
  static const int defaultPageSize = 10;
  static const int defaultRetryAttempts = 3;
  static const int defaultRetryDelay = 1000; // ms
}
