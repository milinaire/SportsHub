import React, {Fragment} from "react";
import AdminHeader from "../../Main/AdminHeader/AdminHeader";
import {AdminNavMenu} from "../../../containers/Admin/AdminNavbar";
import {Route, Switch} from "react-router-dom";
import BannersContainer from "../../../containers/Admin/Banners/Banners";
import ArticleConstructor from "../ArticleConstructor/ArticleConstructor";
import Category from "../Category/Category";
import ArticleRedactor from "../ArticleRedactor/ArticleRedactor";
import SurveysContainer from "../../../containers/Admin/Surveys/Surveys";
import LanguagesContainer from "../../../containers/Admin/Languages/Languages";
import AdvertisingContainer from "../../../containers/Admin/Advertising/Advertising";
import NewsPartnersContainer from "../../../containers/Admin/NewsPartners/NewsPartners";
import TeamsContainer from "../../../containers/Admin/Teams/Teams";
import InformationArchitectureContainer
  from "../../../containers/Admin/InformationArchitecture/InformationArchitecture";
import UsersContainer from "../../../containers/Admin/Users/Users";
import FooterContainer from "../../../containers/Admin/Footer/Footer";
import SocialNetworksContainer from "../../../containers/Admin/SocialNetworks/SocialNetworks";


let AdminLayout = (props) => {
  return (
    <Fragment>
      <AdminHeader language={props.language} setCurrentLanguage={props.setCurrentLanguage}
                   currentSection={props.navigation.selectedAdminCategory}
                   buttonElem={props.navigation.currentButtonPanel}/>
      <AdminNavMenu/>
      <div style={{
        width: 'calc(100vw - 120px)',
        minHeight: 'calc(100vh - 200px)',
        marginLeft: '100px',
        boxSizing: 'border-box',
        zIndex:0
      }}>
        <Switch>
          <Route path="/admin/surveys">
            <SurveysContainer/>
          </Route>
          <Route path="/admin/banners">
            <BannersContainer/>
          </Route>
          <Route path="/admin/languages">
            <LanguagesContainer />
          </Route>
          <Route path="/admin/footer">
            <FooterContainer/>
          </Route>
          <Route path="/admin/social_networks">
            <SocialNetworksContainer />
          </Route>
          <Route path="/admin/users">
            <UsersContainer/>
          </Route>
          <Route path="/admin/information_architecture">
            <InformationArchitectureContainer />
          </Route>
          <Route path="/admin/teams">
            <TeamsContainer/>
          </Route>
          <Route path="/admin/news_partners">
            <NewsPartnersContainer />
          </Route>
          <Route path="/admin/advertising">
            <AdvertisingContainer/>
          </Route>
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

