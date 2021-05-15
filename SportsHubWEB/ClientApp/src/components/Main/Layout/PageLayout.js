import React, {Component, Fragment} from "react";
import "./Layout.css";
import NavMenu from "../NavBar/NavMenu";
import Sidebar from "../SideBar/Sidebar";
import {Route, Switch, withRouter} from "react-router-dom";
import {NotFound} from "./NotFound";
import {Home} from "../../../containers/Main/Home";
import CategoryArticles from "../../../containers/Article/CategoryArticles";
import SubCategoryArticles from "../../../containers/Article/SubCategoryArticles";
import TeamArticles from "../../../containers/Article/TeamArticles";
import SportArticle from "../../../containers/Article/SportArticle";
import {MainArticles} from "../MainArticles/MainArticles";
import MainArticle from "../../../containers/Article/MainArticle";
import {ApplicationPaths} from "../../api-authorization/ApiAuthorizationConstants";
import ApiAuthorizationRoutes from "../../api-authorization/ApiAuthorizationRoutes";

const PageLayout =(props)=> {

  let setMainArticles = (articles, showCategory, link) =>{

  }
    return (
      <Fragment>
        <NavMenu navigation={props.navigation}/>
        <div className="main-part">
          <div className="main-content">
            <div className="content">
              <Switch>
                <Route exact path={`/`}>
                  <Home setMainArticles={setMainArticles}/>
                </Route>
                <Route exact path={`/main-article/:article`}>
                  <MainArticle setMainArticles={setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category`}>
                  <CategoryArticles setMainArticles={setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory`}>
                  <SubCategoryArticles setMainArticles={setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory/:team`}>
                  <TeamArticles setMainArticles={setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory/:team/:article`}>
                  <SportArticle setMainArticles={setMainArticles}/>
                </Route>
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
              </Switch>
            </div>
            <div className="side">
              <Sidebar/>
            </div>
          </div>
        </div>
      </Fragment>
    );

}

export default withRouter(PageLayout)