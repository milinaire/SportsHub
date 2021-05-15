import React, {Fragment} from "react";
import {Route, Switch, withRouter} from "react-router-dom";
import style from './PageLayout.module.css'
import NavMenu from "../NavMenu/NavMenu";
import HomeContainer from "../../../containers/User/Home/Home";
import MainArticlesContainer from "../../../containers/User/MainArticles/MainArticles";
import CategoryArticlesContainer from "../../../containers/User/CategoryArticles/CategoryArticles";
import ConferenceArticlesContainer from "../../../containers/User/ConferenceArticles/ConferenceArticles";
import TeamArticlesContainer from "../../../containers/User/TeamArticles/TeamArticles";
import ArticleContainer from "../../../containers/User/Article/Article";
import SideBarContainer from "../../../containers/User/SideBar/SideBar";

const PageLayout = (props) => {

  return (
    <Fragment>
      <NavMenu
        setHoveredCategory={props.setHoveredCategory}
        setHoveredConference={props.setHoveredConference} navigation={props.navigation}/>
      <div className={style.pageWrapper}>
        <div className={style.mainArticleWrapper}>
          <MainArticlesContainer/>
        </div>
        <div className={style.contentWrapper}>
          <Switch>
            <Route exact path={`/`}>
              <HomeContainer/>
            </Route>
            <Route exact path={`/main-article/:article`}>
              <ArticleContainer/>
            </Route>
            <Route exact path={`/nav/:category`}>
              <CategoryArticlesContainer />
            </Route>
            <Route exact path={`/nav/:category/:conference`}>
              <ConferenceArticlesContainer />
            </Route>
            <Route exact path={`/nav/:category/:conference/:team`}>
              <TeamArticlesContainer/>
            </Route>
            <Route exact path={`/nav/:category/:conference/:team/:article`}>
              <ArticleContainer/>
            </Route>
            {/*<Route exact path={`/nav/:category/:subcategory/:team/:article`}>*/}
            {/*  <SportArticle setMainArticles={setMainArticles}/>*/}
            {/*</Route>*/}
            {/*<Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>*/}
          </Switch>
        </div>
        <div className={style.sideBarWrapper}>
          <SideBarContainer/>
        </div>

      </div>
    </Fragment>
  );

}

export default withRouter(PageLayout)