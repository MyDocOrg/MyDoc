class Consultorio {
  final String id;
  final String nombre;
  final String direccion;
  final String telefono;
  final String correo;
  final String? imagen;

  Consultorio({
    required this.id,
    required this.nombre,
    required this.direccion,
    required this.telefono,
    required this.correo,
    this.imagen,
  });
}

// Datos de ejemplo de consultorios
List<Consultorio> consultoriosMuestra = [
  Consultorio(
    id: '1',
    nombre: 'Consultorio Médico San Rafael',
    direccion: 'Av. Insurgentes Sur 1234, Col. Del Valle, CDMX',
    telefono: '(55) 1234-5678',
    correo: 'contacto@sanrafael.com',
  ),
  Consultorio(
    id: '2',
    nombre: 'Centro de Salud Integral',
    direccion: 'Calle Reforma 567, Col. Centro, CDMX',
    telefono: '(55) 8765-4321',
    correo: 'info@saludintegral.mx',
  ),
  Consultorio(
    id: '3',
    nombre: 'Clínica Santa María',
    direccion: 'Blvd. Ávila Camacho 890, Polanco, CDMX',
    telefono: '(55) 2345-6789',
    correo: 'citas@clinicasantamaria.com',
  ),
  Consultorio(
    id: '4',
    nombre: 'Médica Sur Consultorio 5',
    direccion: 'Puente de Piedra 150, Tlalpan, CDMX',
    telefono: '(55) 3456-7890',
    correo: 'consultorio5@medicasur.org',
  ),
  Consultorio(
    id: '5',
    nombre: 'Consultorio Dr. González',
    direccion: 'Av. Universidad 1500, Coyoacán, CDMX',
    telefono: '(55) 4567-8901',
    correo: 'dr.gonzalez@gmail.com',
  ),
  Consultorio(
    id: '6',
    nombre: 'Centro Médico ABC',
    direccion: 'Sur 136 No. 116, Col. Las Américas, CDMX',
    telefono: '(55) 5678-9012',
    correo: 'citas@centromedicoabc.com',
  ),
];
