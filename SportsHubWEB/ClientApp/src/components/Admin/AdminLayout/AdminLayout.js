import React from "react";

import {connect} from "react-redux";
import {setCurrentLanguage} from "../../../redux/languages/languageActionCreator";

let PComponent = (props) => {
  return (
    <div>
      admin
    </div>
  )
}

let mapStateToProps = (state) => {
  return {language: state.languageReducer}
}

let AdminLayout = connect(mapStateToProps, {setCurrentLanguage})(PComponent);


export default AdminLayout;