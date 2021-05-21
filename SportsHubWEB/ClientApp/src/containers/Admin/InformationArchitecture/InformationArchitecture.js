import React from "react";
import {connect} from "react-redux";
import {
  addCategory,
  setCurrentAdminButtonPanel,
  setIsCategoryModalOpen, setNewCategoryName,
  setSelectedAdminCategory
} from "../../../redux/navigation/navigationActionCreator";
import InformationArchitecture from "../../../components/Admin/InformationArchitecture/InformationArchitecture";
import {useTranslation} from "react-i18next";


// const AddNewLanguageBtn = (props) => {
//   const {t} = useTranslation();
//   return (
//     <button style={{border:"none", background:"#d72130", color:"white", padding:" 8px 15px"}} onClick={() => props.setIsModalOpen(true)}>{t("Admin/Languages/AddNewLanguages")}</button>
//   )
// }

const InformationArchitectureCategoryTranslation = (props) => {
  const {t} = useTranslation();
  return (
    <div>{t("Admin/Languages/InformationArchitectureCategoryTranslation")}</div>
  )
}

class InformationArchitectureAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory(<InformationArchitectureCategoryTranslation/>);
    this.props.setCurrentAdminButtonPanel(null);
  }

  componentWillUnmount() {

  }

  render() {
    return (
      <InformationArchitecture  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigationReducer: state.navigationReducer,
    languageReducer: state.languageReducer,
  }
}

export default connect(mapStateToProps, {
  setSelectedAdminCategory,
  setCurrentAdminButtonPanel,
  setIsCategoryModalOpen,
  setNewCategoryName,
  addCategory
})(InformationArchitectureAPI)