import React, {Component, Fragment} from "react";
import {Route} from "react-router";
import {Layout} from "./components/Main/Layout";
import {Home} from "./containers/Main/Home";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
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
import {Slideshow} from "./containers/Article/sliderTest";


export default class App extends Component {
  static displayName = App.name;
  state = {
    category: "test"
  }

  setCategory(category) {
    this.setState({category: category})
  }

  render() {
    return (
      <Fragment>
        <Layout category={this.state.category}>
          <Route exact path="/nav/:category"
                 render={(props) => <CategoryArticles setCategory={this.setCategory.bind(this)} {...props} />}/>
          <Route exact path="/" component={Home}/>
          <Route exact path="/slideshow" component={Slideshow}/>
          <Route exact path="/companyinfo/:name" component={CompanyInfo}/>
          <Route exact path="/contact" component={ContactUs}/>
          <Route exact path="/about" component={AboutSportHub}/>
          <Route exact path="/contributors/:name" component={Contributors}/>
          <Route exact path="/privacy" component={Privacy}/>
          <Route exact path="/terms" component={Terms}/>
          <Route
            exact
            path="/nav/:category/:subcategory"
            render={(props) => <SubCategoryArticles setCategory={this.setCategory.bind(this)} {...props}/>}
          />
          <Route
            exact
            path="/nav/:category/:subcategory/:team"
            render={(props) => <TeamArticles setCategory={this.setCategory.bind(this)} {...props}/>}

          />
          <Route
            exact
            path="/nav/:category/:subcategory/:team/:article"
            render={(props) => <Article setCategory={this.setCategory.bind(this)} {...props}/>}

          />
          <Route
            path={ApplicationPaths.ApiAuthorizationPrefix}
            component={ApiAuthorizationRoutes}
          />
        </Layout>
      </Fragment>
    );
  }
}
