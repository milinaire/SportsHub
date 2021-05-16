import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import Languages from "../../../components/Admin/Languages/Languages";


class LanguagesAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('Languages');
    this.props.setCurrentAdminButtonPanel(null);
  }
  componentWillUnmount() {

  }

  render() {
    return (
      <Languages  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const LanguagesContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(LanguagesAPI)

export default LanguagesContainer;