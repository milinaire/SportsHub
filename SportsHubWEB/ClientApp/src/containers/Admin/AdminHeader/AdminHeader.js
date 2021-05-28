import React from "react";
import {connect} from "react-redux";
import AdminHeader from "../../../components/Admin/AdminHeader/AdminHeader";
import {setCurrentLanguage} from "../../../redux/languages/languageActionCreator";
class AdminHeaderContainer extends React.Component {
  componentDidMount() {

  }

  componentWillUnmount() {

  }

  render() {
    return (
      <AdminHeader  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    languageReducer: state.languageReducer,
    navigationReducer: state.navigationReducer
  }
}
export default connect(mapStateToProps,  { setCurrentLanguage })(AdminHeaderContainer)

