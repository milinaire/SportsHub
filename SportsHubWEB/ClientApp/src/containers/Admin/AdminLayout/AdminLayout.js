import React from "react";
import {connect} from "react-redux";
import {
  addNewBanner, addNewBannerImg,
  closeBanner,
  getBanners,
  postNewBanner,
  publishBanner, selectBanner
} from "../../../redux/sideBar/sideBarActionCreator";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import AdminLayout from "../../../components/Admin/AdminLayout/AdminLayout";
import {setCurrentLanguage} from "../../../redux/languages/languageActionCreator";

class AdminLayoutAPI extends React.Component {
  componentDidMount() {
    // this.props.setSelectedAdminCategory('');
    // this.props.setCurrentAdminButtonPanel(null);
  }

  componentWillUnmount() {
    this.props.setSelectedAdminCategory('');
    this.props.setCurrentAdminButtonPanel(null);
  }

  render() {
    return (
      <AdminLayout  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    banners: state.sideBarReducer,
    navigation: state.navigationReducer,
    language: state.languageReducer,

  }
}
const AdminLayoutContainer = connect(mapStateToProps,
  {
    getBanners, publishBanner, closeBanner, addNewBanner, postNewBanner, addNewBannerImg,
    selectBanner, setSelectedAdminCategory, setCurrentAdminButtonPanel, setCurrentLanguage
  })(AdminLayoutAPI)

export default AdminLayoutContainer;