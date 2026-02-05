import 'package:flutter/material.dart';

class DateTimeFormField extends StatelessWidget {
  final String label;
  final IconData icon;
  final String value;
  final VoidCallback onTap;
  final String? Function(String?) validator;

  const DateTimeFormField({
    super.key,
    required this.label,
    required this.icon,
    required this.value,
    required this.onTap,
    required this.validator,
  });

  @override
  Widget build(BuildContext context) {
    return TextFormField(
      readOnly: true,
      controller: TextEditingController(text: value),
      decoration: InputDecoration(
        labelText: label,
        prefixIcon: Icon(icon),
        suffixIcon: IconButton(
          icon: Icon(icon),
          onPressed: onTap,
        ),
      ),
      validator: validator,
      onTap: onTap,
    );
  }
}
