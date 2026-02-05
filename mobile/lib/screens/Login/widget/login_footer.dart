import 'package:flutter/material.dart';

class LoginFooter extends StatelessWidget {
  final VoidCallback onRegister;

  const LoginFooter({
    super.key,
    required this.onRegister,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        // Registro
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Text(
              '¿No tienes cuenta? ',
              style: TextStyle(color: Colors.white70),
            ),
            TextButton(
              onPressed: onRegister,
              child: const Text(
                'Regístrate',
                style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.bold,
                  decoration: TextDecoration.underline,
                  decorationColor: Colors.white,
                ),
              ),
            ),
          ],
        ),
        const SizedBox(height: 20),
        // Footer
        const Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Icon(Icons.favorite, color: Colors.red, size: 16),
            SizedBox(width: 8),
            Text(
              'Cuidando tu bienestar',
              style: TextStyle(
                color: Colors.white60,
                fontSize: 12,
              ),
            ),
          ],
        ),
      ],
    );
  }
}
