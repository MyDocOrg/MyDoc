import 'package:flutter/material.dart';
import 'screens/Login/login.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'MyDoc',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
          seedColor: const Color(0xFF0D47A1),
        ),
        useMaterial3: true,
      ),
      home: const LoginPage(),
    );
  }
}
//-------------------------------------------------------------

// import 'package:flutter/material.dart';

// void main() => runApp(const MyApp());

// class MyApp extends StatelessWidget {
//   const MyApp({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return MaterialApp(
//       debugShowCheckedModeBanner: false,
//       home: const LoginPage(),
//     );
//   }
// }

// class LoginPage extends StatefulWidget {
//   const LoginPage({super.key});

//   @override
//   State<LoginPage> createState() => _LoginPageState();
// }

// class _LoginPageState extends State<LoginPage> {
//   final TextEditingController _userController = TextEditingController();
//   final TextEditingController _passController = TextEditingController();
//   bool _obscureText = true;

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       backgroundColor: Colors.white,
//       body: Center(
//         child: SingleChildScrollView(
//           padding: const EdgeInsets.symmetric(horizontal: 32),
//           child: Column(
//             mainAxisAlignment: MainAxisAlignment.center,
//             children: [
//               const LogoForm(),
//               const SizedBox(height: 16),
//               const TitleForm(),
//               const SizedBox(height: 24),
//               UsernameInput(controller: _userController),
//               const SizedBox(height: 16),
//               PasswordInput(
//                 controller: _passController,
//                 obscureText: _obscureText,
//                 onToggle: () {
//                   setState(() {
//                     _obscureText = !_obscureText;
//                   });
//                 },
//               ),
//               const SizedBox(height: 24),
//               LoginButton(
//                 onPressed: () {
//                   final user = _userController.text;
//                   final pass = _passController.text;
//                   ScaffoldMessenger.of(context).showSnackBar(
//                     SnackBar(content: Text('Usuario: $user, Contraseña: $pass')),
//                   );
//                 },
//               ),
//               const SizedBox(height: 24),
//               const FinalText(),
//             ],
//           ),
//         ),
//       ),
//     );
//   }
// }

// class LogoForm extends StatelessWidget {
//   const LogoForm({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return Image.asset(
//       'assets/images/Senna.jpg',
//       width: 120,
//       height: 120,
//     );
//   }
// }

// class TitleForm extends StatelessWidget {
//   const TitleForm({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return const Text(
//       'Iniciar Sesión',
//       style: TextStyle(
//         fontSize: 24,
//         fontWeight: FontWeight.bold,
//       ),
//     );
//   }
// }

// class UsernameInput extends StatelessWidget {
//   final TextEditingController controller;
//   const UsernameInput({super.key, required this.controller});

//   @override
//   Widget build(BuildContext context) {
//     return TextField(
//       controller: controller,
//       decoration: const InputDecoration(
//         labelText: 'Usuario',
//         border: OutlineInputBorder(),
//       ),
//     );
//   }
// }

// class PasswordInput extends StatelessWidget {
//   final TextEditingController controller;
//   final bool obscureText;
//   final VoidCallback onToggle;
//   const PasswordInput({super.key, required this.controller, required this.obscureText, required this.onToggle});

//   @override
//   Widget build(BuildContext context) {
//     return TextField(
//       controller: controller,
//       obscureText: obscureText,
//       decoration: InputDecoration(
//         labelText: 'Contraseña',
//         border: const OutlineInputBorder(),
//         suffixIcon: IconButton(
//           icon: Icon(obscureText ? Icons.visibility : Icons.visibility_off),
//           onPressed: onToggle,
//         ),
//       ),
//     );
//   }
// }

// class LoginButton extends StatelessWidget {
//   final VoidCallback onPressed;
//   const LoginButton({super.key, required this.onPressed});

//   @override
//   Widget build(BuildContext context) {
//     return SizedBox(
//       width: double.infinity,
//       child: ElevatedButton(
//         onPressed: onPressed,
//         child: const Text('Iniciar sesión'),
//       ),
//     );
//   }
// }

// class FinalText extends StatelessWidget {
//   const FinalText({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return const Text(
//       '¿Olvidaste tu contraseña?',
//       style: TextStyle(
//         color: Colors.grey,
//         fontSize: 14,
//       ),
//     );
//   }
// }