import React, {Component, Fragment} from "react";
import "./AdminLayout.css";
import {Route, Switch} from "react-router-dom";
import {ArticleConstructor} from "../../../containers/Admin/ArticleConstructor";
import {AdminPage} from "../../../containers/Admin/AdminPage";
import AdminHeader from "../AdminHeader/AdminHeader";
import {AdminNavMenu} from "../../../containers/Admin/AdminNavbar";
import {Surveys} from "../../../containers/Admin/Pages/Surveys";
import {Banners} from "../../../containers/Admin/Pages/Banners";
import {Languages} from "../../../containers/Admin/Pages/Languages";
import {Footer} from "../../../containers/Admin/Pages/Footer";
import {SocialNetworks} from "../../../containers/Admin/Pages/SocialNetworks";
import {Users} from "../../../containers/Admin/Pages/Users";
import {InformationArchitecture} from "../../../containers/Admin/Pages/InformationArchitecture";
import {Teams} from "../../../containers/Admin/Pages/Teams";
import {NewsPartners} from "../../../containers/Admin/Pages/NewsPartners";
import {Advertising} from "../../../containers/Admin/Pages/Advertising";
import Category from "../../../containers/Admin/Pages/Category";

export class AdminLayout extends Component {
  state ={
    currentSection:"",
  }
  setCurrentSection = section =>{
    this.setState({
      currentSection: section
    })
  }
  constructor(props){
    super(props);
    // this.setCurrentSection = this.setCurrentSection.bind(this)
  }

  render() {
    return (
      <Fragment>
        <AdminHeader currentSection={this.state.currentSection}/>
        <AdminNavMenu/>
        <div className="wrap-shit">
          <Switch>
            <Route path="/admin/surveys">
              <Surveys setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/banners">
              <Banners setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/languages">
              <Languages setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/footer">
              <Footer setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/social_networks">
              <SocialNetworks setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/users">
              <Users setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/information_architecture">
              <InformationArchitecture setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/teams">
              <Teams setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/news_partners">
              <NewsPartners setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/advertising">
              <Advertising setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/:category">
              <Category setCurrentSection={this.setCurrentSection}/>
            </Route>
          </Switch>
        </div>
      </Fragment>
    );
  }
}
