import React, {Component, Fragment} from "react";
import Header from "../Header/Header";
import "./Layout.css";
import {DownFooterPart} from "../Footer/DownFooterPart";
import {Route, Switch} from "react-router-dom";
import {withRouter} from 'react-router-dom';
import PageLayout from "./PageLayout";
import {UpFooterPart} from "../Footer/UpFooterPart";
import {AboutSportHub} from "../Footer/AboutSportHub";
import {Terms} from "../Footer/Terms";
import {Privacy} from "../Footer/Privacy";
import {ContactUs} from "../Footer/ContactUs";
import {CompanyInfo} from "../Footer/CompanyInfo";
import {Contributors} from "../Footer/Contributors";
import ScrollToTop from "./ScrollToTop";

class Layout extends Component {

  render() {
    return (
      <Fragment>
        <Header/>
        <div className={"all-page"}>
          <Switch>
            <Route exact path="/about">
              <ScrollToTop>
                <AboutSportHub/>
              </ScrollToTop>
            </Route>
            <Route exact path="/terms">
              <ScrollToTop>
                <Terms/>
              </ScrollToTop>
            </Route>
            <Route exact path="/privacy">
              <ScrollToTop>
                <Privacy/>
              </ScrollToTop>
            </Route>
            <Route exact path="/contact">
              <ScrollToTop>
                <ContactUs/>
              </ScrollToTop>
            </Route>
            <Route exact path="/company-info/:name">
              <ScrollToTop>
                <CompanyInfo/>
              </ScrollToTop>
            </Route>
            <Route exact path="/contributors/:name">
              <ScrollToTop>
                <Contributors/>
              </ScrollToTop>
            </Route>
            <Route path={`/`}>
              <ScrollToTop>
                <PageLayout/>
              </ScrollToTop>
            </Route>
          </Switch>
          <UpFooterPart/>
        </div>
        <DownFooterPart/>
      </Fragment>
    );
  }
}

export default withRouter(Layout)