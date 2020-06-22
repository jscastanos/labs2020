import React from 'react';
import './App.css';
import Counter from './components/Counter';
import Form from './components/Form';
import Items from './components/Items';

function App() {
  return (
    <div className="App">
      <Counter />
      <hr/>
      <Form />
      <hr />
      <Items />
    </div>
  );
}

export default App;
