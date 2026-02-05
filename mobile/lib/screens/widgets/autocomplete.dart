import 'package:flutter/material.dart';

class CustomAutocompleteField extends StatelessWidget {
  final String label;
  final IconData icon;
  final List<String> options;
  final String? value;
  final Function(String) onChanged;
  final String? Function(String?) validator;

  const CustomAutocompleteField({
    super.key,
    required this.label,
    required this.icon,
    required this.options,
    required this.value,
    required this.onChanged,
    required this.validator,
  });

  List<String> _filter(String query) {
    return options
        .where((e) => e.toLowerCase().contains(query.toLowerCase()))
        .toList();
  }

  @override
  Widget build(BuildContext context) {
    return Autocomplete<String>(
      optionsBuilder: (textEditingValue) {
        if (textEditingValue.text.isEmpty) return options;
        return _filter(textEditingValue.text);
      },
      onSelected: onChanged,
      fieldViewBuilder: (context, controller, focusNode, onEditingComplete) {
        controller.text = value ?? '';
        return TextFormField(
          controller: controller,
          focusNode: focusNode,
          decoration: InputDecoration(
            labelText: label,
            prefixIcon: Icon(icon),
          ),
          validator: validator,
          onChanged: onChanged,
          onEditingComplete: onEditingComplete,
        );
      },
    );
  }
}
