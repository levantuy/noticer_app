import React, { Component } from 'react';
import './App.css';
import Menu from './Menu/Menu';
import { HashRouter, Route, Switch } from 'react-router-dom';
import User from './views/User/User';

class App extends Component {
  render() {
    return (
      <HashRouter>
        <Switch>
          <Route exact path="/user" name="user" component={User} />
          {/* <Route path="/" name="Home" component={Menu} /> */}
          <Menu/>
        </Switch>        
      </HashRouter>
    );
  }
}

export default App;
