import 'package:flutter/material.dart';
import '../Home/home.dart';
import 'widget/login_logo.dart';
import 'widget/login_header.dart';
import 'widget/login_form.dart';
import 'widget/login_footer.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

final FlutterSecureStorage secureStorage = FlutterSecureStorage();

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final _formKey = GlobalKey<FormState>();
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  bool _obscurePassword = true;
  bool _isLoading = false;

  @override
  void dispose() {
    _emailController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  Future<void> _login() async {
    if (!_formKey.currentState!.validate()) return;

    setState(() {
      _isLoading = true;
    });

    try {
      // Reemplaza con tu URL real de backend desplegado
      final response = await http.post(
        Uri.parse('http://localhost:5001/api/auth/login'),
        headers: {
          'Content-Type': 'application/json',
          'X-Application-Name': 'MyDoc'
        },
        body: jsonEncode({
          'email': _emailController.text,
          'password': _passwordController.text,
        }),
      );

      if (response.statusCode == 200) {
        
        final data = jsonDecode(response.body);

        final token = data['data']; // depende de tu backend

        await secureStorage.write(key: 'jwt_token', value: token);

        // Aquí puedes guardar el token si quieres
        print("TOKEN: $token");

        Navigator.pushReplacement(
          context,
          MaterialPageRoute(
            builder: (context) =>
                MyHomePage(email: _emailController.text),
          ),
        );
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
            content: Text('Credenciales incorrectas'),
            backgroundColor: Colors.red,
          ),
        );
      }
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Error de conexión'),
          backgroundColor: Colors.red,
        ),
      );
    } finally {
      setState(() {
        _isLoading = false;
      });
    }
  }


  void _togglePassword() {
    setState(() {
      _obscurePassword = !_obscurePassword;
    });
  }

  void _forgotPassword() {
    ScaffoldMessenger.of(context).showSnackBar(
      const SnackBar(
        content: Text('Función próximamente disponible'),
        backgroundColor: Color(0xFF0D47A1),
      ),
    );
  }

  void _register() {
    ScaffoldMessenger.of(context).showSnackBar(
      const SnackBar(
        content: Text('Registro próximamente disponible'),
        backgroundColor: Color(0xFF0D47A1),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: const BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
            colors: [
              Color(0xFF0D47A1),
              Color(0xFF1976D2),
              Color(0xFF42A5F5),
            ],
          ),
        ),
        child: SafeArea(
          child: Center(
            child: SingleChildScrollView(
              padding: const EdgeInsets.all(24.0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const LoginLogo(),
                  const SizedBox(height: 30),
                  const LoginHeader(),
                  const SizedBox(height: 50),
                  LoginForm(
                    formKey: _formKey,
                    emailController: _emailController,
                    passwordController: _passwordController,
                    obscurePassword: _obscurePassword,
                    isLoading: _isLoading,
                    onTogglePassword: _togglePassword,
                    onLogin: _login,
                    onForgotPassword: _forgotPassword,
                  ),
                  const SizedBox(height: 30),
                  LoginFooter(onRegister: _register),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
