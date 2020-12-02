import React, { Component } from 'react';
import { PieChart } from 'react-minimal-pie-chart';
import './App.css';

var Airtable = require('airtable');
Airtable.configure({
  endpointUrl: 'https://api.airtable.com',
  apiKey: '123',
});

var base = Airtable.base('appDgDge8fpsbicfR');

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      records: [],
      recordStatus: [],
    };
  }
  async componentDidMount() {
    await base('Opportunities')
      .select({
        view: 'All opportunities',
      })
      .eachPage((records, fetchNextPage) => {
        if (records)
          this.setState({
            records,
          });
        fetchNextPage();
      });

    //get all status name and count
    var recordStatus = [];
    this.state.records.forEach((record) => {
      var randomColor =
        '#' + (0x1000000 + Math.random() * 0xffffff).toString(16).substr(1, 6);

      if (
        !recordStatus.filter(
          (status) => status.title === record.fields['Status']
        ).length > 0
      ) {
        recordStatus.push({
          title: record.fields['Status'],
          value: 1,
          color: randomColor,
          data: [record.fields['Opportunity name']],
        });
      } else {
        recordStatus.filter((status) => {
          if (status.title === record.fields['Status']) {
            status.value += 1;
            status.data.push(record.fields['Opportunity name']);
          }
          return;
        });
      }
    });
    this.setState({ recordStatus });
    console.log(this.state.recordStatus);
  }
  render() {
    return (
      <div className="main">
        <div className="chart">
          <h1>Sales CRM</h1>
          <PieChart data={this.state.recordStatus} />
        </div>
        <div className="legend">
          <ul>
            {this.state.recordStatus.length > 0 ? (
              this.state.recordStatus.map((status) => (
                <li>
                  <p
                    className="statusTitle"
                    style={{ backgroundColor: status.color }}
                  >
                    {status.title}
                  </p>
                  {status.data.map((d, index) =>
                    index === 0 ? <span>- {d}, </span> : <span>{d}, </span>
                  )}
                </li>
              ))
            ) : (
              <p>Loading ...</p>
            )}
          </ul>
        </div>
      </div>
    );
  }
}

export default App;
