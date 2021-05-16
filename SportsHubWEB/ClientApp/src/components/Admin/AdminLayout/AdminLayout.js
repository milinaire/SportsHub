import React, {Fragment} from "react";
import AdminHeader from "../../Main/AdminHeader/AdminHeader";
import {AdminNavMenu} from "../../../containers/Admin/AdminNavbar";
import {Route, Switch} from "react-router-dom";
import {Surveys} from "../../../containers/Admin/Pages/Surveys";
import BannersContainer from "../../../containers/Admin/Banners/Banners";
import {Languages} from "../../../containers/Admin/Pages/Languages";
import {Footer} from "../../../containers/Admin/Pages/Footer";
import {SocialNetworks} from "../../../containers/Admin/Pages/SocialNetworks";
import {Users} from "../../../containers/Admin/Pages/Users";
import {InformationArchitecture} from "../../../containers/Admin/Pages/InformationArchitecture";
import {Teams} from "../../../containers/Admin/Pages/Teams";
import {NewsPartners} from "../../../containers/Admin/Pages/NewsPartners";
import {Advertising} from "../../../containers/Admin/Pages/Advertising";
import ArticleConstructor from "../ArticleConstructor/ArticleConstructor";
import Category from "../Category/Category";
import ArticleRedactor from "../ArticleRedactor/ArticleRedactor";


let AdminLayout = (props) => {
  return (
    <Fragment>
      <AdminHeader currentSection={props.navigation.selectedAdminCategory} buttonElem={props.navigation.currentButtonPanel}/>
      <AdminNavMenu/>
      <div style={{width:'calc(100vw - 120px)', minHeight:'calc(100vh - 200px)', marginLeft:'100px', boxSizing: 'border-box'}}>
        <Switch>
          {/*<Route path="/admin/surveys">*/}
          {/*  <Surveys />*/}
          {/*</Route>*/}
          <Route path="/admin/banners">
            <BannersContainer />
          </Route>
          {/*<Route path="/admin/languages">*/}
          {/*  <Languages setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/footer">*/}
          {/*  <Footer setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/social_networks">*/}
          {/*  <SocialNetworks setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/users">*/}
          {/*  <Users setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/information_architecture">*/}
          {/*  <InformationArchitecture setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/teams">*/}
          {/*  <Teams setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/news_partners">*/}
          {/*  <NewsPartners setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          {/*<Route path="/admin/advertising">*/}
          {/*  <Advertising setCurrentSection={this.setCurrentSection}/>*/}
          {/*</Route>*/}
          <Route path="/admin/:category/new_article">
            <ArticleConstructor
              {...props}
            />
          </Route>
          <Route path="/admin/:category/:article">
            <ArticleRedactor
              {...props}
            />
          </Route>
          <Route path="/admin/:category">
            <Category {...props}/>
          </Route>
        </Switch>
      </div>
    </Fragment>
  )
}
export default AdminLayout

