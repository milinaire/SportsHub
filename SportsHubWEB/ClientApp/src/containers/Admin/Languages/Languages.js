import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import Languages from "../../../components/Admin/Languages/Languages";
import {useTranslation} from "react-i18next";
import {
  addLanguages,
  deleteLanguage,
  getLanguages,
  setIsModalOpen,
  setNewLanguages
} from "../../../redux/languages/languageActionCreator";


const AddNewLanguageBtn = (props) => {
  const {t} = useTranslation();
  return (
    <button style={{border:"none", background:"#d72130", color:"white", padding:" 8px 15px"}} onClick={() => props.setIsModalOpen(true)}>{t("Admin/Languages/AddNewLanguages")}</button>
  )
}


const LanguagesCategoryTranslation = (props) => {
  const {t} = useTranslation();
  return (
    <div>{t("Admin/Languages/LanguagesCategoryTranslation")}</div>
  )
}


class LanguagesAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory(<LanguagesCategoryTranslation/>);
    this.props.setCurrentAdminButtonPanel(
      <AddNewLanguageBtn
        setIsModalOpen={this.props.setIsModalOpen}
      />
    );
  }

  componentWillUnmount() {

  }

  render() {
    return (
      <Languages {...this.props}/>
    )
  }
}


let mapStateToProps = (state) => {
  return {
    languageReducer: state.languageReducer,
  }
}

const LanguagesContainer = connect(mapStateToProps,
  {
    setSelectedAdminCategory,
    deleteLanguage,
    getLanguages,
    setCurrentAdminButtonPanel,
    setIsModalOpen,
    setNewLanguages,
    addLanguages,
  }
)(LanguagesAPI)

export default LanguagesContainer;