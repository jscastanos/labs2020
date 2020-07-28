import 'package:demo_flutter/quote.dart';
import 'package:flutter/material.dart';
import 'quote.dart';

void main() => runApp(MaterialApp(
      home: QouteList(),
    ));

class QouteList extends StatefulWidget {
  @override
  _QouteListState createState() => _QouteListState();
}

class _QouteListState extends State<QouteList> {
  List<Quote> quotes = [
    Quote(
      author: 'Someone',
      text:
          'Bacon ipsum dolor amet pork chop drumstick andouille sausage doner.',
    ),
    Quote(
      author: 'No one',
      text:
          'Drumstick filet mignon bresaola leberkas beef ribs ribeye hamburger shankle porchetta tenderloin capicola swine biltong.',
    ),
    Quote(
      author: 'Any one',
      text:
          'Meatloaf tail spare ribs biltong, tri-tip sausage frankfurter turkey turducken short ribs shankle pork belly kielbasa jerky chuck.',
    ),
    Quote(
        author: 'You',
        text:
            'Swine turducken pig rump, turkey bacon drumstick kielbasa. Short loin pig pork loin landjaeger. Pancetta ham hock jowl chuck filet mignon frankfurter.')
  ];

  Widget quoteTemplate(quote) {
    return Card(
      margin: EdgeInsets.fromLTRB(10.0, 8.0, 10.0, 0.0),
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: <Widget>[
            Text(
              quote.text,
              style: TextStyle(
                fontSize: 18.0,
                color: Colors.grey[600],
              ),
            ),
            SizedBox(
              height: 6.0,
            ),
            Text(
              quote.author,
              style: TextStyle(
                fontSize: 14.0,
                color: Colors.grey[800],
              ),
            ),
          ],
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.grey[200],
      appBar: AppBar(
        backgroundColor: Colors.redAccent,
        centerTitle: true,
        title: Text(
          'Random Quotes',
          style: TextStyle(
            fontSize: 25.0,
          ),
        ),
      ),
      body: Column(
        children: quotes.map((quote) => quoteTemplate(quote)).toList(),
      ),
    );
  }
}
