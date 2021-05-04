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
import SportArticle from "../../../containers/Article/SportArticle";
import {MainArticles} from "../MainArticles/MainArticles";
import MainArticle from "../../../containers/Article/MainArticle";

class PageLayout extends Component {
  state = {
    MainArticles: [],
    ShowCategory: false,
    Link: undefined
  }

  setMainArticles(articles, showCategory, link) {
    this.setState({
      MainArticles: articles,
      ShowCategory: showCategory,
      Link: link
    })
  }

  constructor(props) {
    super(props);
    this.setMainArticles = this.setMainArticles.bind(this);
  }

  render() {

    return (
      <Fragment>
        <NavMenu/>
        <div className="main-part">
          {this.state.MainArticles && <MainArticles articles={this.state.MainArticles} showCategory={this.state.ShowCategory} link={this.state.Link}/>}
          <div className="main-content">
            <div className="content">
              <Switch>
                <Route exact path={`/`}>
                  <Home setMainArticles={this.setMainArticles}/>
                </Route>
                <Route exact path={`/main-article/:article`}>
                  <MainArticle setMainArticles={this.setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category`}>
                  <CategoryArticles setMainArticles={this.setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory`}>
                  <SubCategoryArticles setMainArticles={this.setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory/:team`}>
                  <TeamArticles setMainArticles={this.setMainArticles}/>
                </Route>
                <Route exact path={`/nav/:category/:subcategory/:team/:article`}>
                  <SportArticle setMainArticles={this.setMainArticles}/>
                </Route>
                <Route>
                  <NotFound/>
                </Route>
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
}

export default withRouter(PageLayout)