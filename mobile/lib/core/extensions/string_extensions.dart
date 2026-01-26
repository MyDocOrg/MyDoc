/// Extensiones para String
extension StringExtensions on String {
  /// Verifica si el string es nulo o vacío
  bool get isEmpty => this.isEmpty;

  /// Verifica si el string no está vacío
  bool get isNotEmpty => this.isNotEmpty;

  /// Capitaliza la primera letra
  String capitalize() {
    if (isEmpty) return this;
    return this[0].toUpperCase() + substring(1).toLowerCase();
  }

  /// Valida si es un email válido
  bool isValidEmail() {
    final RegExp emailRegex = RegExp(
      r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$',
    );
    return emailRegex.hasMatch(this);
  }

  /// Valida si es un teléfono válido
  bool isValidPhoneNumber() {
    final RegExp phoneRegex = RegExp(r'^[0-9]{7,15}$');
    return phoneRegex.hasMatch(this);
  }

  /// Obtiene las iniciales de un nombre
  String getInitials() {
    if (isEmpty) return '';
    final parts = split(' ');
    final initials = parts.map((p) => p.isNotEmpty ? p[0].toUpperCase() : '').join();
    return initials.substring(0, (initials.length > 2 ? 2 : initials.length));
  }
}
