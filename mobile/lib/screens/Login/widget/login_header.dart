import 'package:flutter/material.dart';

class LoginHeader extends StatelessWidget {
  const LoginHeader({super.key});

  @override
  Widget build(BuildContext context) {
    return const Column(
      children: [
        Text(
          'MyDoc',
          style: TextStyle(
            fontSize: 36,
            fontWeight: FontWeight.bold,
            color: Colors.white,
            letterSpacing: 2,
          ),
        ),
        SizedBox(height: 8),
        Text(
          'Tu salud en buenas manos',
          style: TextStyle(
            fontSize: 16,
            color: Colors.white70,
            letterSpacing: 1,
          ),
        ),
      ],
    );
  }
}
