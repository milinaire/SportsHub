import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import SocialNetworks from "../../../components/Admin/SocialNetworks/SocialNetworks";


class SocialNetworksAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('SocialNetworks');
    this.props.setCurrentAdminButtonPanel(null);
  }
  componentWillUnmount() {

  }

  render() {
    return (
      <SocialNetworks  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const SocialNetworksContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(SocialNetworksAPI)

export default SocialNetworksContainer;