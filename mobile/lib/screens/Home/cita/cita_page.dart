import 'package:flutter/material.dart';
import 'mi_cita/mi_cita.dart';
import 'solicitar_cita.dart/solicitar_cita.dart';

class CitasPage extends StatefulWidget {
  const CitasPage({super.key});

  @override
  State<CitasPage> createState() => _CitasPageState();
}

class _CitasPageState extends State<CitasPage> {
  int _selectedTab = 0; // 0: Mis Citas, 1: Solicitar Cita

  void _goToMisCitas() {
    setState(() {
      _selectedTab = 0;
    });
  }

  @override
  Widget build(BuildContext context) {
    Widget content;
    if (_selectedTab == 0) {
      content = const MiCitaPage();
    } else {
      content = SolicitarCitaPage(onCitaRegistrada: _goToMisCitas);
    }

    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          // Botones superiores
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              ElevatedButton(
                onPressed: () {
                  setState(() {
                    _selectedTab = 0;
                  });
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: _selectedTab == 0 ? const Color(0xFF0D47A1) : null,
                  foregroundColor: _selectedTab == 0 ? Colors.white : null,
                ),
                child: const Text('Mis Citas'),
              ),
              const SizedBox(width: 16),
              ElevatedButton(
                onPressed: () {
                  setState(() {
                    _selectedTab = 1;
                  });
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: _selectedTab == 1 ? const Color(0xFF0D47A1) : null,
                  foregroundColor: _selectedTab == 1 ? Colors.white : null,
                ),
                child: const Text('Solicitar Cita'),
              ),
            ],
          ),
          const SizedBox(height: 24),
          Expanded(child: content),
        ],
      ),
    );
  }
}