import React, {Component, Fragment} from "react";
import {Route} from "react-router";
import {Layout} from "./components/Main/Layout/Layout";
import {Home} from "./containers/Main/Home";
//import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import {ApplicationPaths} from "./components/api-authorization/ApiAuthorizationConstants";
import {SportArticle} from "./containers/Article/ArticlePage";
import {CategoryArticles} from "./containers/Article/CategoryArticles";
import {SubCategoryArticles} from "./containers/Article/SubCategoryArticles";
import {TeamArticles} from "./containers/Article/TeamArticles";
import {Privacy} from "./components/Main/Footer/Privacy";
import {Terms} from "./components/Main/Footer/Terms";
import {CompanyInfo} from "./components/Main/Footer/CompanyInfo";
import {Contributors} from "./components/Main/Footer/Contributors";
import {ContactUs} from "./components/Main/Footer/ContactUs";
import {AboutSportHub} from "./components/Main/Footer/AboutSportHub";
import Test from "./Test";
import {Article} from "./containers/Article/SimpleArticle";

export default class App extends Component {

  render() {
    return (
      <Fragment>
        <Layout>
          <Route exact path="/" component={Home}/>
          <Route exact path="/test" component={Test}/>
          <Route exact path="/about" component={AboutSportHub}/>
          <Route exact path="/terms" component={Terms}/>
          <Route exact path="/privacy" component={Privacy}/>
          <Route exact path="/contact" component={ContactUs}/>
          <Route exact path="/company-info/:name" component={CompanyInfo}/>
          <Route exact path="/contributors/:name" component={Contributors}/>
          <Route exact path="/art/:article" component={Article}/>
          <Route exact path="/nav/:category" component={CategoryArticles}/>
          <Route exact path="/nav/:category/:subcategory" component={SubCategoryArticles}/>
          <Route exact path="/nav/:category/:subcategory/:team" component={TeamArticles}/>
          <Route exact path="/nav/:category/:subcategory/:team/:article" component={SportArticle}/>
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>
        </Layout>
      </Fragment>
    );
  }
}
