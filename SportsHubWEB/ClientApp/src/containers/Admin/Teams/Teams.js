import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import Teams from "../../../components/Admin/Teams/Teams";


class TeamsAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('Teams');
    this.props.setCurrentAdminButtonPanel(null);
  }
  componentWillUnmount() {

  }

  render() {
    return (
      <Teams  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const TeamsContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(TeamsAPI)

export default TeamsContainer;