import React, {Component, Fragment} from "react";
import "./Layout.css";
import {NavMenu} from "../NavBar/NavMenu";
import Sidebar from "../SideBar/Sidebar";
import {Route, Switch, withRouter} from "react-router-dom";
import {NotFound} from "./NotFound";
import {Home} from "../../../containers/Main/Home";
import CategoryArticles from "../../../containers/Article/CategoryArticles";
import SubCategoryArticles from "../../../containers/Article/SubCategoryArticles";
import TeamArticles from "../../../containers/Article/TeamArticles";
import SportArticle from "../../../containers/Article/ArticlePage";

class PageLayout extends Component {

  render() {
    return (
      <Fragment>
        <NavMenu/>
        <div className="main-part">
          {/*{this.props.MainArticles.length > 0 && <MainArticles articles={this.props.MainArticles} link={this.props.link}/>}*/}
          <div className="main-content">
            <div className="content">
              <Switch>
                <Route exact path={`/`}>
                  <Home/>
                </Route>
                <Route exact path={`/nav/:category`}>
                  <CategoryArticles/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory`}>
                  <SubCategoryArticles/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory/:team`}>
                  <TeamArticles/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory/:team/:article`}>
                  <SportArticle/>
                </Route>
                <Route>
                  <NotFound/>
                </Route>
              </Switch>
            </div>
            <div className="side">
              <Sidebar />
            </div>
          </div>
        </div>
      </Fragment>
    );
  }
}

export default withRouter(PageLayout)