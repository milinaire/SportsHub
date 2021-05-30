import React from "react";
import {connect} from "react-redux";
import {setCurrentAdminButtonPanel, setSelectedAdminCategory} from "../../../redux/navigation/navigationActionCreator";
import NewsPartners from "../../../components/Admin/NewsPartners/NewsPartners";


class NewsPartnersAPI extends React.Component {
  componentDidMount() {
    this.props.setSelectedAdminCategory('NewsPartners');
    this.props.setCurrentAdminButtonPanel(null);
  }
  componentWillUnmount() {

  }

  render() {
    return (
      <NewsPartners  {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    navigation: state.navigationReducer,
    language: state.languageReducer,
  }
}
const NewsPartnersContainer = connect(mapStateToProps,
  {setSelectedAdminCategory,
    setCurrentAdminButtonPanel})(NewsPartnersAPI)

export default NewsPartnersContainer;