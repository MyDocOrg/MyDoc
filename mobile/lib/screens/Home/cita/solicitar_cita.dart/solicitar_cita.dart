import 'package:flutter/material.dart';
import '../../../widgets/showSuccesDialog.dart';
import '../../../widgets/autocomplete.dart';
import '../../../widgets/date_time.dart';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:flutter_secure_storage/flutter_secure_storage.dart';

final FlutterSecureStorage secureStorage = FlutterSecureStorage();

// Variable global para simular almacenamiento de la última cita
Map<String, String>? ultimaCitaSolicitada;

class SolicitarCitaPage extends StatefulWidget {
  final VoidCallback? onCitaRegistrada;
  const SolicitarCitaPage({super.key, this.onCitaRegistrada});

  @override
  State<SolicitarCitaPage> createState() => _SolicitarCitaPageState();
}

class _SolicitarCitaPageState extends State<SolicitarCitaPage> {
  final _formKey = GlobalKey<FormState>();

  List<dynamic> _doctores = [];
  List<dynamic> _consultorios = [];

  bool _isLoading = true;


  String? _doctorSeleccionado;
  String? _consultorioSeleccionado;
  DateTime? _fechaSeleccionada;
  TimeOfDay? _horaSeleccionada;

  List<String> _filtrarLista(String query, List<String> lista) {
    return lista
        .where((item) => item.toLowerCase().contains(query.toLowerCase()))
        .toList();
  }

  Future<void> fetchDoctores() async {
    final token = await secureStorage.read(key: 'jwt_token');

    final response = await http.get(
      Uri.parse('http://localhost:5002/api/doctor'),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $token',
      },
    );

    if (response.statusCode == 200) {
      final data = jsonDecode(response.body);
      print("doctores: ${data['data']}");
      setState(() {
        _doctores = data['data'];
      });
    }
  }

  Future<void> fetchConsultorios() async {
    final token = await secureStorage.read(key: 'jwt_token');

    final response = await http.get(
      Uri.parse('http://localhost:5002/api/clinic'),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $token',
      },
    );

    if (response.statusCode == 200) {
      final data = jsonDecode(response.body);
      print("Consultorios: ${data['data']}");
      setState(() {
        _consultorios = data['data'];
      });
    }
  }


  Future<void> _seleccionarFecha(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: _fechaSeleccionada ?? DateTime.now(),
      firstDate: DateTime.now(),
      lastDate: DateTime.now().add(const Duration(days: 365)),
    );
    if (picked != null) {
      setState(() {
        _fechaSeleccionada = picked;
      });
    }
  }

  Future<void> _seleccionarHora(BuildContext context) async {
    final TimeOfDay? picked = await showTimePicker(
      context: context,
      initialTime: _horaSeleccionada ?? TimeOfDay.now(),
    );
    if (picked != null) {
      setState(() {
        _horaSeleccionada = picked;
      });
    }
  }

  Future<void> _enviarFormulario() async {
    if (!_formKey.currentState!.validate() ||
        _doctorSeleccionado == null ||
        _consultorioSeleccionado == null ||
        _fechaSeleccionada == null ||
        _horaSeleccionada == null) return;

    final token = await secureStorage.read(key: 'jwt_token');

    final doctor = _doctores.firstWhere(
      (d) => d['fullName'] == _doctorSeleccionado,
    );

    final clinic = _consultorios.firstWhere(
      (c) => c['name'] == _consultorioSeleccionado,
    );

    final appointmentDate = DateTime(
      _fechaSeleccionada!.year,
      _fechaSeleccionada!.month,
      _fechaSeleccionada!.day,
      _horaSeleccionada!.hour,
      _horaSeleccionada!.minute,
    ).toUtc();

    final response = await http.post(
      Uri.parse('http://localhost:5002/api/appointment'),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer $token',
      },
      body: jsonEncode({
        'doctorId': doctor['id'],
        'clinicId': clinic['id'],
        'statusId': 1, // 👈 estático como dijiste
        'appointmentDate': appointmentDate.toIso8601String(),
      }),
    );

    if (response.statusCode == 200 || response.statusCode == 201) {
      showSuccessDialog(context, 'Cita registrada correctamente').then((_) {
        if (widget.onCitaRegistrada != null) {
          widget.onCitaRegistrada!();
        }
      });
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(
          content: Text('Error al registrar cita'),
          backgroundColor: Colors.red,
        ),
      );
    }
  }


  @override
  void initState() {
    super.initState();
    _loadInitialData();
  }

  Future<void> _loadInitialData() async {
    await fetchDoctores();
    await fetchConsultorios();

    setState(() {
      _isLoading = false;
    });
  }


  @override
  Widget build(BuildContext context) {
    if (_isLoading) {
      return const Center(child: CircularProgressIndicator());
    }
    return Center(
      child: SingleChildScrollView(
        child: Card(
          elevation: 4,
          margin: const EdgeInsets.all(16),
          shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(16)),
          child: Padding(
            padding: const EdgeInsets.all(24.0),
            child: Form(
              key: _formKey,
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  // Doctor
                  CustomAutocompleteField(
                    label: 'Doctor',
                    icon: Icons.person,
                    options: _doctores.map((d) => d['fullName'] as String).toList(),
                    value: _doctorSeleccionado,
                    onChanged: (value) {
                      setState(() {
                        _doctorSeleccionado = value;
                      });
                    },
                    validator: (value) =>
                        _doctorSeleccionado == null || _doctorSeleccionado!.isEmpty
                            ? 'Seleccione un doctor'
                            : null,
                  ),
                  const SizedBox(height: 16),
                  // Consultorio
                  CustomAutocompleteField(
                    label: 'Consultorio',
                    icon: Icons.local_hospital,
                    options: _consultorios.map((c) => c['name'] as String).toList(),
                    value: _consultorioSeleccionado,
                    onChanged: (value) {
                      setState(() {
                        _consultorioSeleccionado = value;
                      });
                    },
                    validator: (value) =>
                        _consultorioSeleccionado == null || _consultorioSeleccionado!.isEmpty
                            ? 'Seleccione un consultorio'
                            : null,
                  ),
                  const SizedBox(height: 16),
                  // Fecha
                  DateTimeFormField(
                    label: 'Fecha',
                    icon: Icons.calendar_today,
                    value: _fechaSeleccionada == null
                        ? ''
                        : '${_fechaSeleccionada!.day.toString().padLeft(2, '0')}/${_fechaSeleccionada!.month.toString().padLeft(2, '0')}/${_fechaSeleccionada!.year}',
                    onTap: () => _seleccionarFecha(context),
                    validator: (value) =>
                        _fechaSeleccionada == null ? 'Seleccione una fecha' : null,
                  ),
                  const SizedBox(height: 16),
                  // Hora
                  DateTimeFormField(
                    label: 'Hora',
                    icon: Icons.access_time,
                    value: _horaSeleccionada == null ? '' : _horaSeleccionada!.format(context),
                    onTap: () => _seleccionarHora(context),
                    validator: (value) =>
                        _horaSeleccionada == null ? 'Seleccione una hora' : null,
                  ),
                  const SizedBox(height: 24),
                  ElevatedButton(
                    onPressed: _enviarFormulario,
                    child: const Text('Solicitar Cita'),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}