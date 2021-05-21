import React from "react";
import {connect} from "react-redux";
import App from "../../components/App/App";
import {getLanguages, setCurrentLanguage, setLanguages} from "../../redux/languages/languageActionCreator";
import {
  setCategories,
  setConferences,
  setTeams,
  setHoveredCategory,
  setHoveredConference, getNavigation
} from "../../redux/navigation/navigationActionCreator";

import {navigationAPI} from "../../api/navigationAPI";


class AppContainer extends React.Component {
  componentDidMount() {
    this.props.getLanguages()
    this.props.getNavigation(this.props.languageReducer.currentLanguage.id)
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.languageReducer.currentLanguage.id !== this.props.languageReducer.currentLanguage.id) {
      this.props.getNavigation(this.props.languageReducer.currentLanguage.id)
    }
  }

  render() {
    return (
      <App {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    languageReducer: state.languageReducer,
    navigationReducer: state.navigationReducer
  }
}
export default connect(mapStateToProps, {
  setCurrentLanguage,
  setLanguages,
  setCategories,
  setConferences,
  setTeams,
  setHoveredCategory,
  setHoveredConference,
  getLanguages,
  getNavigation
})(AppContainer)


