import 'package:demo_flutter/pages/choose_location.dart';
import 'package:demo_flutter/pages/home.dart';
import 'package:demo_flutter/pages/loading.dart';
import 'package:flutter/material.dart';

void main() => runApp(MaterialApp(
      initialRoute: '/',
      routes: {
        '/': (context) => Loading(),
        '/home': (context) => Home(),
        '/location': (context) => ChooseLocation()
      },
    ));
