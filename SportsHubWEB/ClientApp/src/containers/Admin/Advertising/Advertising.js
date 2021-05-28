import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import Advertising from "../../../components/Admin/Advertising/Advertising";


class AdvertisingAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('Advertising');
    this.props.setCurrentAdminButtonPanel(null);
  }
  componentWillUnmount() {

  }

  render() {
    return (
      <Advertising  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const AdvertisingContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(AdvertisingAPI)

export default AdvertisingContainer;