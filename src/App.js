import React, { Component } from 'react';
import './App.css';
import Menu from './Menu/Menu';
import { Route, BrowserRouter, Switch } from 'react-router-dom';
import Dashboard from './views/Dashboard/Dashboard';
import User from './views/User/User';

class App extends Component {
  render() {
    return (<div>
      <Menu />
      <div className="container">
        <main>
          <Switch>
            <Route exact path='/user' component={User} />
            <Route path='/dashboard' component={Dashboard} />
          </Switch>
        </main>
      </div>
    </div>
    );
  }
}

export default App;
