import 'package:flutter/material.dart';

void main() => runApp(MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('Demo App'),
          centerTitle: true,
        ),
        body: Center(
          child: Text('Im a pirate'),
        ),
        floatingActionButton: FloatingActionButton(
          child: Text('FAB'),
        ),
      ),
    ));
