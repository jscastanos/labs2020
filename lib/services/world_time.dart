import 'package:http/http.dart';
import 'dart:convert';

class WorldTime {
  String location;
  String time;
  String flag;
  String url;

  WorldTime({this.location, this.flag, this.url});

  Future<void> getTime() async {
    try {
      Response response =
          await get('http://worldtimeapi.org/api/timezone/$url');
      Map data = jsonDecode(response.body);

      //get properties from data
      String datetime = data['utc_datetime'];
      String offset = data['utc_offset'].substring(1, 3);

      DateTime now = DateTime.parse(datetime);
      now = now.add(Duration(hours: int.parse(offset)));

      time = now.toString();
    } catch (e) {
      print('$e');
      this.time = 'Could not connect to the server!';
    }
  }
}
