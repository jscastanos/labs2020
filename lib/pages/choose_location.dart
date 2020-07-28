import 'package:flutter/material.dart';

class ChooseLocation extends StatefulWidget {
  @override
  _ChooseLocationState createState() => _ChooseLocationState();
}

class _ChooseLocationState extends State<ChooseLocation> {
  void getData() async {
// simulate network request for a username

    String username = await Future.delayed(Duration(seconds: 3), () {
      return 'yow';
    });

    print('Username is $username');
  }

  @override
  void initState() {
    super.initState();
    this.getData();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[200],
      appBar: AppBar(
        title: Text('Choose Location'),
        backgroundColor: Colors.blue[900],
      ),
      body: RaisedButton(
        onPressed: () {},
        child: Text('counter is'),
      ),
    );
  }
}
