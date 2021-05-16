import React from "react";
import {connect} from "react-redux";
import {
  addBannerLocalization,
  addNewBanner,
  addNewBannerImg,
  changeBannerCategory,
  closeBanner,
  closeNewBanner,
  deleteBanner, deleteBannerLocalization,
  getBanners,
  postNewBanner,
  publishBanner,
  selectBanner,
  setBannersStatus,
  setNewBannerCategory,
  updateBannerLocalization,
  updateBannerLocalizationHeadline
} from "../../../redux/sideBar/sideBarActionCreator";
import Banners from "../../../components/Admin/Banners/Banners";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";

class BannerAPI extends React.Component {
  componentDidMount() {
    this.props.getBanners(this.props.language.currentLanguage.id)
    this.props.setSelectedAdminCategory('Banners')

  }

  componentWillUnmount() {

  }

  render() {
    return (
      <Banners  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    banners: state.sideBarReducer,
    categories: state.navigationReducer.categories,
    language: state.languageReducer,

  }
}
const BannersContainer = connect(mapStateToProps,
  {
    getBanners,
    publishBanner,
    closeBanner,
    addNewBanner,
    postNewBanner,
    addNewBannerImg,
    updateBannerLocalizationHeadline,
    selectBanner,
    setSelectedAdminCategory,
    setCurrentAdminButtonPanel,
    deleteBannerLocalization,
    updateBannerLocalization,
    addBannerLocalization,
    changeBannerCategory,
    setBannersStatus,
    deleteBanner,
    closeNewBanner,
    setNewBannerCategory,
  })(BannerAPI)

export default BannersContainer;