import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import Languages from "../../../components/Admin/Languages/Languages";
import {
  addChangeLanguage,
  addNewLanguage,
  changeLanguage,
  changeNewLanguage,
  deleteLanguage, deleteNewLanguage,
  getLanguages,
  postNewLanguage,
  putLanguage
} from "../../../redux/languages/languageActionCreator";


class LanguagesAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('Languages');
    // this.props.setCurrentAdminButtonPanel(
    //   <button onClick={props.addNewLanguage}>Add New Language</button>
    //
    // );
  }

  componentWillUnmount() {

  }


  render() {
    console.log(this.props)
    return (
      <Languages {...this.props}/>
    )
  }
}

let mapStateToProps = (state) =>
{
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const LanguagesContainer = connect(mapStateToProps,
{
  setSelectedAdminCategory,
    addChangeLanguage,
    addNewLanguage,
    changeNewLanguage,
    changeLanguage,
    postNewLanguage,
    deleteLanguage,
    putLanguage,
    getLanguages,
    setCurrentAdminButtonPanel,
  deleteNewLanguage
}
)(LanguagesAPI)

export default LanguagesContainer;