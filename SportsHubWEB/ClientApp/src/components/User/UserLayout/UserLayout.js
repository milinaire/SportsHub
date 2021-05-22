import React, {Fragment} from "react";
import styles from "./UserLayout.module.css";
import {Route, Switch} from "react-router-dom";
import {UpFooterPart} from "../Footer/UpFooterPart";
import {DownFooterPart} from "../Footer/DownFooterPart";
import Header from "../Header/Header";
import PageLayout from "../PageLayout/PageLayout";
import {AboutSportHub} from "../Footer/AboutSportHub";
import {Terms} from "../Footer/Terms";
import {Privacy} from "../Footer/Privacy";
import {ContactUs} from "../Footer/ContactUs";
import {CompanyInfo} from "../Footer/CompanyInfo";
import {Contributors} from "../Footer/Contributors";


const UserLayout = (props) => {
  return (
    <Fragment>
      <Header languageReducer={props.languageReducer} setCurrentLanguage={props.setCurrentLanguage}/>
      <div className={styles.allPageWrapper}>
        <Switch>
          <Route exact path="/about">
            <AboutSportHub/>
          </Route>
          <Route exact path="/terms">
            <Terms/>
          </Route>
          <Route exact path="/privacy">
            <Privacy/>
          </Route>
          <Route exact path="/contact">
            <ContactUs/>
          </Route>
          <Route exact path="/company-info/:name">
            <CompanyInfo/>
          </Route>
          <Route exact path="/contributors/:name">
            <Contributors/>
          </Route>
          <Route path={`/`}>
            <PageLayout
              languageReducer={props.languageReducer}
              setHoveredCategory={props.setHoveredCategory}
              setHoveredConference={props.setHoveredConference}
              navigation={props.navigationReducer}/>
          </Route>
        </Switch>
        <UpFooterPart/>
      </div>
      <DownFooterPart/>
    </Fragment>
  );
}

export default UserLayout;