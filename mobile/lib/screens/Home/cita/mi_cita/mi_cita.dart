import 'package:flutter/material.dart';
import '../solicitar_cita.dart/solicitar_cita.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

final FlutterSecureStorage secureStorage = FlutterSecureStorage();


class MiCitaPage extends StatefulWidget {
  const MiCitaPage({super.key});

  @override
  State<MiCitaPage> createState() => _MiCitaPageState();
}

class _MiCitaPageState extends State<MiCitaPage> {
  List<dynamic> _historial = [];
  bool _isLoading = true;

  @override
  void initState() {
    super.initState();
    fetchAppointments();
  }

  Future<void> fetchAppointments() async {
    try {
      final token = await secureStorage.read(key: 'jwt_token');
      final response = await http.get(
        Uri.parse('http://localhost:5002/api/appointment/table'),
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer $token', // si usas JWT
        },
      );

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);

        setState(() {
          _historial = data['data'];
          _isLoading = false;
        });
      } else {
        setState(() {
          _isLoading = false;
        });
      }
    } catch (e) {
      setState(() {
        _isLoading = false;
      });
    }
  }


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
            child: _isLoading
                ? const Center(child: CircularProgressIndicator())
                : _historial.isEmpty
                    ? const Center(child: Text("No hay historial de citas"))
                    : ListView.builder(
                        itemCount: _historial.length,
                        itemBuilder: (context, index) {
                          final cita = _historial[index];

                          return ListTile(
                            leading: Icon(
                              cita['statusName'] == 'Pending'
                                  ? Icons.check_circle
                                  : cita['statusName'] == 'Cancelada'
                                      ? Icons.cancel
                                      : Icons.schedule,
                              color: cita['statusName'] == 'Completada'
                                  ? Colors.green
                                  : cita['statusName'] == 'Cancelada'
                                      ? Colors.red
                                      : Colors.orange,
                            ),
                            title: Text("${cita['appointmentDate']} - ${cita['hora']}"),
                            subtitle: Text(
                                "${cita['doctorName']}\nDirección: ${cita['clinicName']}"),
                            trailing: Text(
                              cita['statusName'],
                              style: const TextStyle(color: Colors.grey),
                            ),
                            isThreeLine: true,
                          );
                        },
                      ),
        ),
        ],
      ),
    );
  }
}
