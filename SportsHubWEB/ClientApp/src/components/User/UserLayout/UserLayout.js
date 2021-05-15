import React, {Fragment} from "react";
import styles from "./UserLayout.module.css";
import {Route, Switch} from "react-router-dom";
import ScrollToTop from "../../Main/Layout/ScrollToTop";
import {UpFooterPart} from "../../Main/Footer/UpFooterPart";
import {DownFooterPart} from "../../Main/Footer/DownFooterPart";
import Header from "../Header/Header";
import PageLayout from "../PageLayout/PageLayout";


const UserLayout = (props) => {
  return (
    <Fragment>
      <Header language={props.language} setCurrentLanguage={props.setCurrentLanguage}/>
      <div className={styles.allPageWrapper}>
        <Switch>
          {/*<Route exact path="/about">*/}
          {/*  <ScrollToTop>*/}
          {/*    <AboutSportHub/>*/}
          {/*  </ScrollToTop>*/}
          {/*</Route>*/}
          {/*<Route exact path="/terms">*/}
          {/*  <ScrollToTop>*/}
          {/*    <Terms/>*/}
          {/*  </ScrollToTop>*/}
          {/*</Route>*/}
          {/*<Route exact path="/privacy">*/}
          {/*  <ScrollToTop>*/}
          {/*    <Privacy/>*/}
          {/*  </ScrollToTop>*/}
          {/*</Route>*/}
          {/*<Route exact path="/contact">*/}
          {/*  <ScrollToTop>*/}
          {/*    <ContactUs/>*/}
          {/*  </ScrollToTop>*/}
          {/*</Route>*/}
          {/*<Route exact path="/company-info/:name">*/}
          {/*  <ScrollToTop>*/}
          {/*    <CompanyInfo/>*/}
          {/*  </ScrollToTop>*/}
          {/*</Route>*/}
          {/*<Route exact path="/contributors/:name">*/}
          {/*  <ScrollToTop>*/}
          {/*    <Contributors/>*/}
          {/*  </ScrollToTop>*/}
          {/*</Route>*/}
          <Route path={`/`}>
            <ScrollToTop>
              <PageLayout
                setHoveredCategory={props.setHoveredCategory}
                setHoveredConference={props.setHoveredConference}
                navigation={props.navigation}/>
            </ScrollToTop>
          </Route>
        </Switch>
        <UpFooterPart/>
      </div>
      <DownFooterPart/>
    </Fragment>
  );
}


export default UserLayout;