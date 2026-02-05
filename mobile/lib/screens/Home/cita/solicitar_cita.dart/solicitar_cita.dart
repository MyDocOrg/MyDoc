import 'package:flutter/material.dart';
import '../../../widgets/showSuccesDialog.dart';
import '../../../widgets/autocomplete.dart';
import '../../../widgets/date_time.dart';

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

  final List<String> _doctores = [
    'Dr. Juan Pérez',
    'Dra. Ana López',
    'Dr. Mario Ruiz',
    'Dra. Carla Gómez',
  ];
  final List<String> _consultorios = [
    'Consultorio Central',
    'Consultorio Norte',
    'Consultorio Sur',
    'Consultorio Este',
  ];

  String? _doctorSeleccionado;
  String? _consultorioSeleccionado;
  DateTime? _fechaSeleccionada;
  TimeOfDay? _horaSeleccionada;

  List<String> _filtrarLista(String query, List<String> lista) {
    return lista
        .where((item) => item.toLowerCase().contains(query.toLowerCase()))
        .toList();
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

  void _enviarFormulario() {
    if (_formKey.currentState!.validate() &&
        _doctorSeleccionado != null &&
        _consultorioSeleccionado != null &&
        _fechaSeleccionada != null &&
        _horaSeleccionada != null) {
      // Guardar la cita como pendiente
      ultimaCitaSolicitada = {  
        'doctor': _doctorSeleccionado!,
        'consultorio': _consultorioSeleccionado!,
        'fecha':
            '${_fechaSeleccionada!.day.toString().padLeft(2, '0')}/${_fechaSeleccionada!.month.toString().padLeft(2, '0')}/${_fechaSeleccionada!.year}',
        'hora': _horaSeleccionada!.format(context),
        'estado': 'Pendiente',
      };
      showSuccessDialog(context, 'Cita registrada correctamente').then((_) {
        if (widget.onCitaRegistrada != null) {
          widget.onCitaRegistrada!();
        }
      });
      setState(() {});
    }
  }

  @override
  Widget build(BuildContext context) {
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
                    options: _doctores,
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
                    options: _consultorios,
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