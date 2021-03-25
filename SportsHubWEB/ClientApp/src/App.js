import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Main/Layout';
import { Home } from './components/Main/Home';
import { FetchData } from './components/Main/FetchData';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import {Article} from "./containers/Article/ArticlePage";
import './custom.css'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/article' component={Article} />
        <AuthorizeRoute path='/fetch-data' component={FetchData} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
        
      </Layout>
    );
  }
}
