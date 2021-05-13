import React, {Component, Fragment} from "react";
import {Route} from "react-router";
import {AdminLayout} from "./components/Main/Layout/AdminLayout";
//import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import {Switch } from "react-router-dom";
import Layout from "./components/Main/Layout/Layout";
import {Provider} from "react-redux";


export class App extends Component {

  render() {
    return (
      <Fragment>
        {/*<Provider>*/}
        <Switch>
          <Route path="/admin">
            <AdminLayout/>
          </Route>
          <Route path="/">
            <Layout/>
          </Route>
        </Switch>
        {/*</Provider>*/}
      </Fragment>
    );
  }
}
