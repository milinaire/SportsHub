import React, { Component, Fragment } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Main/Layout';
import { Home } from './components/Main/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import {Article} from "./containers/Article/ArticlePage";
import {CategoryArticles} from "./containers/Article/CategoryArticles";
import {SubCategoryArticles} from "./containers/Article/SubCategoryArticles";
import {TeamArticles} from "./containers/Article/TeamArticles";

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Fragment>
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/:category' component={CategoryArticles} />
        <Route exact path='/:category/:subcategory' component={SubCategoryArticles} />
        <Route exact path='/:category/:subcategory/:team' component={TeamArticles} />
        <Route exact path='/:category/:subcategory/:team/:article' component={Article} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
      </Fragment>
    );
  }
}
