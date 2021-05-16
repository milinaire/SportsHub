import React, {Fragment} from "react";
import {Route} from "react-router";
import {Switch} from "react-router-dom";
import UserLayout from "../User/UserLayout/UserLayout";
import {AdminLayout} from "../Main/Layout/AdminLayout";
import AdminLayoutContainer from "../../containers/Admin/AdminLayout/AdminLayout";
//import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";

const App = (props) => {
  return (
    <Fragment>
      <Switch>
        <Route path="/admin">

          <div style={{width: '100%', minHeight: '100vh',}}>
            <AdminLayoutContainer />
          </div>
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
