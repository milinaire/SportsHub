import React, {Fragment, useContext} from "react";
import styles from "./Adminlayout.module.css";
import {ADD_CATEGORY} from "../../../redux/actions/navigationActions";
import LanguageContext from "../../../LanguageContext";
import {connect} from "react-redux";
import navigationReducer from "../../../redux/reducers/navigationReducer";

let PComponent = (props) => {
  {console.log("test")}
  return (
    <div>
      {/*{language}*/}
      {props.nav.categories.map(c=>(
        <div>
          {c.name}
        </div>
      ))}
      {console.log("test")}
      {console.log(props.nav, props.addCategory)}
      <button onClick={props.addCategory}>
        click
      </button>
      {/*{console.log(language)}*/}
    </div>
  )
}

let mapStateToProps = (state) => {
  return {nav: state.navigationReducer}
}

let mapDispatchToProps = (dispatch) => {
  console.log(dispatch)
  return {
    addCategory: () => {
      dispatch({type: ADD_CATEGORY, name: 'you'})
    }
  }
}
let AdminLayout = connect(mapStateToProps, mapDispatchToProps)(PComponent);


export default AdminLayout;