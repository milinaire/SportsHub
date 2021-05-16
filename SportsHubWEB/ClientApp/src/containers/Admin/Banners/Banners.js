import React from "react";
import {connect} from "react-redux";
import {addNewBanner, closeBanner, getBanners, publishBanner} from "../../../redux/sideBar/sideBarActionCreator";
import Banners from "../../../components/Admin/Banners/Banners";

class BannerAPI extends React.Component {
  componentDidMount() {
    this.props.getBanners()
  }

  componentWillUnmount() {

  }

  render() {
    return (
      <Banners language={this.props.language} addNewBanner={this.props.addNewBanner} categories={this.props.categories} closeBanner={this.props.closeBanner} publishBanner={this.props.publishBanner} banners={this.props.banners}/>
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
  {getBanners, publishBanner, closeBanner, addNewBanner})(BannerAPI)

export default BannersContainer;