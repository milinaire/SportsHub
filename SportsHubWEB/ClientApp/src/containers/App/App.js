import React from "react";
import {connect} from "react-redux";
import axios from 'axios'
import App from "../../components/App/App";
import {setCurrentLanguage, setLanguages} from "../../redux/languages/languageActionCreator";
import {
  setCategories,
  setConferences,
  setTeams,
  setHoveredCategory,
  setHoveredConference
} from "../../redux/navigation/navigationActionCreator";

class AppAPI extends React.Component {
  componentDidMount() {
    axios.get(`/language`)
      .then(response => {
        this.props.setLanguages(response.data)
      })
    axios.get(`/category?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setCategories(response.data)
      })
    axios.get(`/conference?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setConferences(response.data)
      })
    axios.get(`/team?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setTeams(response.data)
      })
  }

  render() {
    return (
      <App language={this.props.language} navigation={this.props.navigation}
           setCurrentLanguage={this.props.setCurrentLanguage}
           setHoveredCategory={this.props.setHoveredCategory}
           setHoveredConference={this.props.setHoveredConference}
           setLanguages={this.props.setLanguages}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    language: state.languageReducer,
    navigation: state.navigationReducer
  }
}
const AppContainer = connect(mapStateToProps, {
  setCurrentLanguage,
  setLanguages,
  setCategories,
  setConferences,
  setTeams,
  setHoveredCategory,
  setHoveredConference
})(AppAPI)


export default AppContainer;