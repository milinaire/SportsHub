import React from "react";
import {connect} from "react-redux";
import {getLanguages, setCurrentLanguage, setIsInitializing} from "./redux/languages/languageActionCreator";
import {getNavigation} from "./redux/navigation/navigationActionCreator";
import {Route} from "react-router";
import AdminLayoutContainer from "./containers/Admin/AdminLayout/AdminLayout";
import {Switch} from "react-router-dom";
import UserLayoutContainer from "./containers/User/UserLayout/UserLayout";
import {ApplicationPaths} from "./api-authorization/ApiAuthorizationConstants";
import ApiAuthorizationRoutes from "./api-authorization/ApiAuthorizationRoutes";
import Loader from "./CustomLoader/Loader";


class App extends React.Component {
  async componentDidMount() {
    await this.props.getLanguages()
    await this.props.setCurrentLanguage(localStorage.i18nextLng)
    await this.props.setIsInitializing(false)
    await this.props.getNavigation(this.props.languageReducer.currentLanguage.id)
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.languageReducer.currentLanguage.id !== this.props.languageReducer.currentLanguage.id) {
      this.props.getNavigation(this.props.languageReducer.currentLanguage.id)
    }
  }

  render() {
    return (
      !this.props.languageReducer.isInitializing?
      <Switch>
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>
        <Route path="/admin">
          <AdminLayoutContainer/>
        </Route>
        <Route path="/">
          <UserLayoutContainer/>
        </Route>
      </Switch>:<Loader/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    languageReducer: state.languageReducer
    ,
  }
}
export default connect(mapStateToProps,
  {
    getLanguages,
    getNavigation,
    setCurrentLanguage,
    setIsInitializing
  }
)(App)


