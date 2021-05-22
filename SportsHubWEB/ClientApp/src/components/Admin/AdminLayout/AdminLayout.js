import React, {Fragment} from "react";
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
import NavMenu from "../NavMenu/NavMenu";
import AdminHeaderContainer from "../../../containers/Admin/AdminHeader/AdminHeader";
import s from './Adminlayout.module.css'

let AdminLayout = (props) => {
  return (
    <Fragment>
      <AdminHeaderContainer/>
      <div className={s.allPageWrapper}>
        <NavMenu/>
        <div className={s.contentWrapper}>
          <div className={s.content}>
          <Switch>
            <Route path="/admin/surveys">
              <SurveysContainer/>
            </Route>
            <Route path="/admin/banners">
              <BannersContainer/>
            </Route>
            <Route path="/admin/languages">
              <LanguagesContainer/>
            </Route>
            <Route path="/admin/footer">
              <FooterContainer/>
            </Route>
            <Route path="/admin/social_networks">
              <SocialNetworksContainer/>
            </Route>
            <Route path="/admin/users">
              <UsersContainer/>
            </Route>
            <Route path="/admin/information_architecture">
              <InformationArchitectureContainer/>
            </Route>
            <Route path="/admin/teams">
              <TeamsContainer/>
            </Route>
            <Route path="/admin/news_partners">
              <NewsPartnersContainer/>
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
        </div>
      </div>
    </Fragment>
  )
}
export default AdminLayout

