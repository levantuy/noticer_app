import React from 'react';
import Loadable from 'react-loadable';

function Loading() {
  return <div>Loading...</div>;
}

const Dashboard = Loadable({
  loader: () => import('./views/Dashboard/Dashboard'),
  loading: Loading,
});

const User = Loadable({
    loader: () => import('./views/User/User'),
    loading: Loading,
  });

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
    // { path: '/', exact: true, name: 'Home', component: Menu },
    { path: '/dashboard', name: 'Dashboard', component: Dashboard },  
    { path: '/user', name: 'User', component: User },  
  ];
  
export default routes;