import React from "react";
import {connect} from "react-redux";
import UserLayout from "../../../components/User/UserLayout/UserLayout";
import {setCurrentLanguage} from "../../../redux/languages/languageActionCreator";
import {setHoveredCategory, setHoveredConference} from "../../../redux/navigation/navigationActionCreator";

class UserLayoutContainer extends React.Component {
  componentDidMount() {

  }

  componentWillUnmount() {

  }

  render() {
    return (
      <UserLayout {...this.props}/>
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
  setHoveredCategory,
  setHoveredConference
})(UserLayoutContainer)