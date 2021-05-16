import React from "react";
import {connect} from "react-redux";
import {
  addNewBanner, addNewBannerImg,
  closeBanner,
  getBanners,
  postNewBanner,
  publishBanner, selectBanner
} from "../../../redux/sideBar/sideBarActionCreator";
import Banners from "../../../components/Admin/Banners/Banners";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import AdminLayout from "../../../components/Admin/AdminLayout/AdminLayout";

class AdminLayoutAPI extends React.Component {
  componentDidMount() {

  }

  componentWillUnmount() {

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
    selectBanner, setSelectedAdminCategory, setCurrentAdminButtonPanel
  })(AdminLayoutAPI)

export default AdminLayoutContainer;