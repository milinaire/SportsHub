import React, {Fragment} from "react";
import {Route} from "react-router";
import {Switch} from "react-router-dom";
import AdminLayout from "../Admin/AdminLayout/AdminLayout";
import UserLayout from "../User/UserLayout/UserLayout";
//import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";

const App = (props) => {
  return (
    <Fragment>
      <Switch>
        <Route path="/admin">
          <AdminLayout/>
        </Route>
        <Route path="/">
          <UserLayout
            setHoveredCategory={props.setHoveredCategory}
            setHoveredConference={props.setHoveredConference}
            language={props.language}
            setCurrentLanguage={props.setCurrentLanguage}
            setLanguages={props.setLanguages}
            navigation={props.navigation}/>
        </Route>
      </Switch>
    </Fragment>
  );
}
export default App;
