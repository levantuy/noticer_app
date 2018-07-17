import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import { BrowserRouter } from 'react-router-dom';

localStorage.setItem("urlApi", 'http://api.t1store.com/api/');
// localStorage.setItem("urlApi", 'http://localhost:53875/api/');

ReactDOM.render(<BrowserRouter><App /></BrowserRouter>, document.getElementById('root'));
registerServiceWorker();
