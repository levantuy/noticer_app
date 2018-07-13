import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import Menu from './Menu/Menu';

ReactDOM.render(<Menu />, document.getElementById('root'));
registerServiceWorker();
