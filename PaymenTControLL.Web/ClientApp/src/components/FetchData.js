import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { parcels: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderParcelsTable(parcels) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Competencia</th>
            <th>Valor</th>
          </tr>
        </thead>
        <tbody>
          {parcels.map(parcel=>
            <tr key={parcel.competencia}>
              <td>{new Date(parcel.competencia).toLocaleDateString()}</td>
              <td>{"$ " + parcel.valor.toFixed(2)}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderParcelsTable(this.state.parcels);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        {contents}
      </div>
    );
  }

    async populateWeatherData() {
      const response = await fetch('https://localhost:44354/api/parcels');
      const data = await response.json();

      this.setState({ parcels: data, loading: false });
  }
}
