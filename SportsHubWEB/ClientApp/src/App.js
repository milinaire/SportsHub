import React, { Component, Fragment } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Main/Layout';
import { Home } from './components/Main/Main/Home';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';
import {Article} from "./containers/Article/ArticlePage";
import {CategoryArticles} from "./containers/Article/CategoryArticles";
import {SubCategoryArticles} from "./containers/Article/SubCategoryArticles";
import {TeamArticles} from "./containers/Article/TeamArticles";
import { Privacy } from './components/Main/Footer/Privacy';
import { Terms } from './components/Main/Footer/Terms';
import { CompanyInfo } from './components/Main/Footer/CompanyInfo';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Fragment>
      <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/companyinfo/:name' component={CompanyInfo} />
        <Route exact path='/privacy' component={Privacy} />
        <Route exact path='/terms' component={Terms} />
        <Route exact path='/nav/:category' component={CategoryArticles} />
        <Route exact path='/nav/:category/:subcategory' component={SubCategoryArticles} />
        <Route exact path='/nav/:category/:subcategory/:team' component={TeamArticles} />
        <Route exact path='/nav/:category/:subcategory/:team/:article' component={Article} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
      </Fragment>
    );
  }
}
