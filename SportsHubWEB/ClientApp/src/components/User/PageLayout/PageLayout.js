import React, {Fragment} from "react";
import {Route, Switch, withRouter} from "react-router-dom";
import {Home} from "../../../containers/Main/Home";
import style from './PageLayout.module.css'
import CategoryArticles from "../../../containers/Article/CategoryArticles";
import SubCategoryArticles from "../../../containers/Article/SubCategoryArticles";
import TeamArticles from "../../../containers/Article/TeamArticles";
import SportArticle from "../../../containers/Article/SportArticle";
import MainArticle from "../../../containers/Article/MainArticle";
import {ApplicationPaths} from "../../api-authorization/ApiAuthorizationConstants";
import ApiAuthorizationRoutes from "../../api-authorization/ApiAuthorizationRoutes";
import Sidebar from "../../Main/SideBar/Sidebar";
import NavMenu from "../NavMenu/NavMenu";
import UserLayout from "../UserLayout/UserLayout";
import HomeContainer from "../../../containers/User/Home/Home";
import MainArticlesContainer from "../../../containers/User/MainArticles/MainArticles";

const PageLayout = (props) => {

  let setMainArticles = (articles, showCategory, link) => {

  }
  return (
    <Fragment>
      <NavMenu
        setHoveredCategory={props.setHoveredCategory}
        setHoveredConference={props.setHoveredConference} navigation={props.navigation}
        setIsConferencesOpened={props.setIsConferencesOpened}
        setIsTeamsOpened={props.setIsTeamsOpened}/>
      <div className={style.pageWrapper}>
        <div className={style.mainArticleWrapper}>
          <MainArticlesContainer/>
        </div>
        <div className={style.contentWrapper}>
          <Switch>
            <Route exact path={`/`}>
              <HomeContainer/>
            </Route>
            {/*<Route exact path={`/main-article/:article`}>*/}
            {/*  <MainArticles setMainArticles={setMainArticles}/>*/}
            {/*</Route>*/}
            {/*<Route exact path={`/nav/:category`}>*/}
            {/*  <CategoryArticles setMainArticles={setMainArticles}/>*/}
            {/*</Route>*/}
            {/*<Route exact path={`/nav/:category/:subcategory`}>*/}
            {/*  <SubCategoryArticles setMainArticles={setMainArticles}/>*/}
            {/*</Route>*/}
            {/*<Route exact path={`/nav/:category/:subcategory/:team`}>*/}
            {/*  <TeamArticles setMainArticles={setMainArticles}/>*/}
            {/*</Route>*/}
            {/*<Route exact path={`/nav/:category/:subcategory/:team/:article`}>*/}
            {/*  <SportArticle setMainArticles={setMainArticles}/>*/}
            {/*</Route>*/}
            {/*<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>*/}
          </Switch>
        </div>
        <div className={style.sideBarWrapper}>
          {/*<Sidebar/>*/}side
        </div>

      </div>
    </Fragment>
  );

}

export default withRouter(PageLayout)