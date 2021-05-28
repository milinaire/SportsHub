import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import Users from "../../../components/Admin/Users/Users";


class UsersAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('Users');
    this.props.setCurrentAdminButtonPanel(null);
  }
  componentWillUnmount() {

  }

  render() {
    return (
      <Users  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const UsersContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(UsersAPI)

export default UsersContainer;