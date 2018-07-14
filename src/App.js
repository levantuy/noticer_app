import React, { Component } from 'react';
import './App.css';
import Menu from './Menu/Menu';
import { Redirect, Route, Switch } from 'react-router-dom';
import Dashboard from './views/Dashboard/Dashboard';
import User from './views/User/User';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      searchValue: ''
    };
    this.handleSearch = this.handleSearch.bind(this);
  }

  handleSearch(searchText) {
    this.setState({
      searchValue: searchText
    });
  };

  render() {
    return (<div>
      <Menu onSearch={this.handleSearch} />
      <div className="container">
        <main>
          <Switch>
            <Route exact path='/' component={Dashboard} />
            <Route exact path='/user' component={User} {...this.props}/>
            <Route path='/dashboard' component={Dashboard}/>
            <Redirect to="/" />
          </Switch>
        </main>
      </div>
    </div>
    );
  }
}

export default App;
