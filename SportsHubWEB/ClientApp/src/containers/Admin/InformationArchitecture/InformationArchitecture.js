import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import InformationArchitecture from "../../../components/Admin/InformationArchitecture/InformationArchitecture";


class InformationArchitectureAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('InformationArchitecture');
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
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const InformationArchitectureContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(InformationArchitectureAPI)

export default InformationArchitectureContainer;