import React, {Fragment} from "react";
import {Route} from "react-router";
import {Switch} from "react-router-dom";
import AdminLayout from "./components/Admin/AdminLayout/AdminLayout";
import UserLayout from "./components/User/UserLayout/UserLayout";
//import LanguageContext from "./LanguageContext";
import {Provider} from "react-redux";
//import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";

const App = (props) => {

  return (
    <Fragment>
        <Switch>
          <Route path="/admin">

            <AdminLayout/>
          </Route>
          <Route path="/">
            <UserLayout/>
          </Route>
        </Switch>
    </Fragment>
  );
}
export default App;
