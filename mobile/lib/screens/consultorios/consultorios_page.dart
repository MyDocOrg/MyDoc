import 'package:flutter/material.dart';
import '../../models/consultorio.dart';
import 'widgets/consultorio_card.dart';
import 'widgets/search_bar_consultorios.dart';
import '../Home/home.dart';
import '../Login/login.dart';

class ConsultoriosPage extends StatefulWidget {
  const ConsultoriosPage({super.key});

  @override
  State<ConsultoriosPage> createState() => _ConsultoriosPageState();
}

class _ConsultoriosPageState extends State<ConsultoriosPage> {
  final TextEditingController _searchController = TextEditingController();
  List<Consultorio> _consultoriosFiltrados = [];

  @override
  void initState() {
    super.initState();
    _consultoriosFiltrados = consultoriosMuestra;
  }

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  void _filtrarConsultorios(String query) {
    setState(() {
      if (query.isEmpty) {
        _consultoriosFiltrados = consultoriosMuestra;
      } else {
        _consultoriosFiltrados = consultoriosMuestra.where((consultorio) {
          final nombreLower = consultorio.nombre.toLowerCase();
          final direccionLower = consultorio.direccion.toLowerCase();
          final queryLower = query.toLowerCase();
          return nombreLower.contains(queryLower) ||
              direccionLower.contains(queryLower);
        }).toList();
      }
    });
  }

  void _seleccionarConsultorio(Consultorio consultorio) {
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => MyHomePage(title: consultorio.nombre),
      ),
    );
  }

  void _cerrarSesion() {
    Navigator.pushAndRemoveUntil(
      context,
      MaterialPageRoute(
        builder: (context) => const LoginPage(),
      ),
      (route) => false,
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: const Color(0xFF0D47A1),
        foregroundColor: Colors.white,
        title: const Text('Mis Consultorios'),
        centerTitle: true,
        elevation: 0,
        actions: [
          IconButton(
            icon: const Icon(Icons.logout),
            tooltip: 'Cerrar sesión',
            onPressed: _cerrarSesion,
          ),
        ],
      ),
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
        child: Column(
          children: [
            // Barra de búsqueda
            SearchBarConsultorios(
              controller: _searchController,
              onChanged: _filtrarConsultorios,
            ),
            const SizedBox(height: 16),
            // Lista de consultorios
            Expanded(
              child: _consultoriosFiltrados.isEmpty
                  ? const Center(
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Icon(
                            Icons.search_off,
                            size: 64,
                            color: Colors.white70,
                          ),
                          SizedBox(height: 16),
                          Text(
                            'No se encontraron consultorios',
                            style: TextStyle(
                              color: Colors.white70,
                              fontSize: 18,
                            ),
                          ),
                        ],
                      ),
                    )
                  : ListView.builder(
                      padding: const EdgeInsets.symmetric(horizontal: 16),
                      itemCount: _consultoriosFiltrados.length,
                      itemBuilder: (context, index) {
                        final consultorio = _consultoriosFiltrados[index];
                        return ConsultorioCard(
                          consultorio: consultorio,
                          onTap: () => _seleccionarConsultorio(consultorio),
                        );
                      },
                    ),
            ),
          ],
        ),
      ),
    );
  }
}
