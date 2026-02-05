import 'package:flutter/material.dart';
import '../solicitar_cita.dart/solicitar_cita.dart';

class MiCitaPage extends StatefulWidget {
  const MiCitaPage({super.key});

  @override
  State<MiCitaPage> createState() => _MiCitaPageState();
}

class _MiCitaPageState extends State<MiCitaPage> {
  @override
  Widget build(BuildContext context) {
    final cita = ultimaCitaSolicitada; // Variable global

    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          // Próxima cita
          Card(
            elevation: 4,
            shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12)),
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Row(
                children: [
                  const Icon(Icons.calendar_today, size: 40, color: Color(0xFF0D47A1)),
                  const SizedBox(width: 16),
                  Expanded(
                    child: cita == null
                        ? const Text('No tienes próximas citas.')
                        : Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              const Text('Próxima cita', style: TextStyle(fontWeight: FontWeight.bold)),
                              const SizedBox(height: 8),
                              Text('Fecha: ${cita['fecha']}'),
                              Text('Hora: ${cita['hora']}'),
                              Text('Doctor: ${cita['doctor']}'),
                              Text('Dirección: ${cita['consultorio']}'),
                              const SizedBox(height: 8),
                              const Text('Estado: Pendiente', style: TextStyle(color: Colors.orange)),
                            ],
                          ),
                  ),
                ],
              ),
            ),
          ),
          const SizedBox(height: 24),
          // Historial de citas
          const Text(
            'Historial de Citas',
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
          ),
          const SizedBox(height: 8),
          Expanded(
            child: ListView(
              children: [
                ListTile(
                  leading: const Icon(Icons.check_circle, color: Colors.green),
                  title: const Text('28/01/2026 - 09:00 AM'),
                  subtitle: const Text('Dr. Ana López\nDirección: Calle Salud 456'),
                  trailing: const Text('Completada', style: TextStyle(color: Colors.grey)),
                  isThreeLine: true,
                ),
                ListTile(
                  leading: const Icon(Icons.cancel, color: Colors.red),
                  title: const Text('25/01/2026 - 11:00 AM'),
                  subtitle: const Text('Dr. Mario Ruiz\nDirección: Calle Salud 789'),
                  trailing: const Text('Cancelada', style: TextStyle(color: Colors.grey)),
                  isThreeLine: true,
                ),
                // Puedes agregar más citas aquí
              ],
            ),
          ),
        ],
      ),
    );
  }
}