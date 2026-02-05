import 'package:flutter/material.dart';
import '../Home/home.dart';
import 'widget/login_logo.dart';
import 'widget/login_header.dart';
import 'widget/login_form.dart';
import 'widget/login_footer.dart';

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

  void _login() {
    // TODO: Descomentar para producción
    // if (_formKey.currentState!.validate()) {
      setState(() {
        _isLoading = true;
      });

      // Simulamos un delay de login
      Future.delayed(const Duration(seconds: 1), () {
        setState(() {
          _isLoading = false;
        });

        // Navegamos a la página de consultorios
        Navigator.pushReplacement(
          context,
          MaterialPageRoute(
            builder: (context) => MyHomePage(email: _emailController.text),
          ),
        );
      });
    // }
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
