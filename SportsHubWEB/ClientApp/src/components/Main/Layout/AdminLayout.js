import React, {Component, Fragment} from "react";
import "./AdminLayout.css";
import {Route, Switch} from "react-router-dom";
import ArticleConstructor from "../../../containers/Admin/Pages/Category/ArticleConstructor";
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
import Category from "../../../containers/Admin/Pages/Category/Category";
import ArticleRedactor from "../../../containers/Admin/Pages/Category/ArticleRedactor";
import BannersContainer from "../../../containers/Admin/Banners/Banners";

export class AdminLayout extends Component {
  state = {
    currentSection: "",
    buttonElem: null,
    showBox: false,
    Box: null
  }
  setCurrentSection = section => {
    this.setState({
      currentSection: section,
    })
  }
  setButtonElem = button => {
    this.setState({
      buttonElem: button,
    })
  }

  constructor(props) {
    super(props);
    // this.setCurrentSection = this.setCurrentSection.bind(this)
  }

  cancelBox = () => {
    //e.preventDefault()
    this.setState({
      showBox: false,
    })
  }
  showBox = e => {
    e.preventDefault()
    this.setState({
      showBox: true,
    })
  }
  setBox = box => {
    this.setState({
      Box: box,
    })
  }

  render() {
    return (
      <Fragment>

        <AdminHeader currentSection={this.state.currentSection} buttonElem={this.state.buttonElem}/>
        <AdminNavMenu/>
        <div style={{width:'calc(100vw - 120px)', height:'calc(100vh - 200px)', marginLeft:'100px', boxSizing: 'border-box'}}>
          <Switch>
            <Route path="/admin/surveys">
              <Surveys setCurrentSection={this.setCurrentSection}/>
            </Route>
            <Route path="/admin/banners">
              <BannersContainer />
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
            <Route path="/admin/:category/new_article">
              <ArticleConstructor
                setCurrentSection={this.setCurrentSection}
                setButtonElem={this.setButtonElem}
                setBox={this.setBox}
                showBox={this.showBox}
                cancelBox={this.cancelBox}/>
            </Route>
            <Route path="/admin/:category/:article">
              <ArticleRedactor
                setCurrentSection={this.setCurrentSection}
                setButtonElem={this.setButtonElem}
                setBox={this.setBox}
                showBox={this.showBox}
                cancelBox={this.cancelBox}/>
            </Route>
            <Route path="/admin/:category">
              <Category setCurrentSection={this.setCurrentSection} setButtonElem={this.setButtonElem}
                        cancelBox={this.cancelBox}/>
            </Route>
          </Switch>
        </div>
      </Fragment>
    );
  }
}
