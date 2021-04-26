import React, {Component, Fragment} from "react";
import {Route} from "react-router";
import {HomeLayout} from "./components/Main/Layout/HomeLayout";
import {Home} from "./containers/Main/Home";
//import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import {ApplicationPaths} from "./components/api-authorization/ApiAuthorizationConstants";
import {Article} from "./containers/Article/ArticlePage";
import {CategoryArticles} from "./containers/Article/CategoryArticles";
import {SubCategoryArticles} from "./containers/Article/SubCategoryArticles";
import {TeamArticles} from "./containers/Article/TeamArticles";
import {Privacy} from "./components/Main/Footer/Privacy";
import {Terms} from "./components/Main/Footer/Terms";
import {CompanyInfo} from "./components/Main/Footer/CompanyInfo";
import {Contributors} from "./components/Main/Footer/Contributors";
import {ContactUs} from "./components/Main/Footer/ContactUs";
import {AboutSportHub} from "./components/Main/Footer/AboutSportHub";


export default class App extends Component {
  static displayName = App.name;
  state = {
    category: "",
    layout: "home",
    MainArticles: [],
  }

  setArticles = MainArticles => {
    this.setState({MainArticles: MainArticles})
  }

  setLayout = layout => {
    this.setState({layout: layout})
  }

  setCategory(category) {
    this.setState({category: category})
  }

  render() {
    return (
      <Fragment>
        <HomeLayout layout={this.state.layout} category={this.state.category} articles={this.state.MainArticles}>
          <Route exact path="/" render={(props) => <Home setArticles={this.setArticles.bind(this)} {...props} />}/>
          <Route exact path="/privacy" render={(props) => <Privacy setLayout={this.setLayout.bind(this)} {...props} />}/>
          <Route exact path="/terms" render={(props) => <Terms setLayout={this.setLayout.bind(this)} {...props} />}/>
          <Route exact path="/contact" render={(props) => <ContactUs setLayout={this.setLayout.bind(this)} {...props} />}/>
          <Route exact path="/about" render={(props) => <AboutSportHub setLayout={this.setLayout.bind(this)} {...props} />}/>
          <Route exact path="/companyinfo/:name" render={(props) => <CompanyInfo setLayout={this.setLayout.bind(this)} {...props} />}/>
          <Route exact path="/contributors/:name" render={(props) => <Contributors setLayout={this.setLayout.bind(this)} {...props} />}/>
          <Route exact path="/nav/:category" render={(props) => <CategoryArticles setCategory={this.setCategory.bind(this)} {...props} />}/>
          <Route exact path="/nav/:category/:subcategory" render={(props) => <SubCategoryArticles setCategory={this.setCategory.bind(this)} {...props}/>}/>
          <Route exact path="/nav/:category/:subcategory/:team" render={(props) => <TeamArticles setCategory={this.setCategory.bind(this)} {...props}/>}/>
          <Route exact path="/nav/:category/:subcategory/:team/:article" render={(props) => <Article setCategory={this.setCategory.bind(this)} {...props}/>}/>
          <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>
        </HomeLayout>
      </Fragment>
    );
  }
}
