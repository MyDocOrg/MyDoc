/// Configuración global de la aplicación
class AppConfig {
  // URLs de API
  static const String apiBaseUrl = 'http://localhost:3000/api';
  static const String authApiUrl = 'http://localhost:3001/api';

  // Timeouts
  static const int connectionTimeout = 30000; // ms
  static const int receiveTimeout = 30000; // ms

  // Configuración de sesión
  static const int sessionTimeout = 3600000; // 1 hora en ms
  static const String tokenKey = 'auth_token';
  static const String refreshTokenKey = 'refresh_token';

  // Configuración de logging
  static const bool enableLogging = true;
  static const String logLevel = 'debug';

  // Configuración de la aplicación
  static const String appName = 'MyDoc';
  static const String appVersion = '1.0.0';
  static const String environment = 'development';
}
