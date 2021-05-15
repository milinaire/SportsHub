import React from "react";
import {connect} from "react-redux";
import SideBar from "../../../components/User/SideBar/SideBar";

class SideBarAPI extends React.Component {
  render() {
    return (
      <SideBar banners={this.props.banners}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    banners: state.sideBarReducer,
  }
}
const SideBarContainer = connect(mapStateToProps, {})(SideBarAPI)

export default SideBarContainer;