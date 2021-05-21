import React from "react";
import {connect} from "react-redux";
import App from "../../components/App/App";
import {getLanguages, setCurrentLanguage, setLanguages} from "../../redux/languages/languageActionCreator";
import {
  setCategories,
  setConferences,
  setTeams,
  setHoveredCategory,
  setHoveredConference
} from "../../redux/navigation/navigationActionCreator";
import axios from "axios";


class AppContainer extends React.Component {
  componentDidMount() {
    this.props.getLanguages()

    axios.get(`/category?languageId=${this.props.languageReducer.currentLanguage.id}`)
      .then(response => {
        this.props.setCategories(response.data)
      })
    axios.get(`/conference?languageId=${this.props.languageReducer.currentLanguage.id}`)
      .then(response => {
        this.props.setConferences(response.data)
      })
    axios.get(`/team?languageId=${this.props.languageReducer.currentLanguage.id}`)
      .then(response => {
        this.props.setTeams(response.data)
      })
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.languageReducer.currentLanguage.id !== this.props.languageReducer.currentLanguage.id) {
      axios.get(`/category?languageId=${this.props.languageReducer.currentLanguage.id}`)
        .then(response => {
          this.props.setCategories(response.data)
        })
      axios.get(`/conference?languageId=${this.props.languageReducer.currentLanguage.id}`)
        .then(response => {
          this.props.setConferences(response.data)
        })
      axios.get(`/team?languageId=${this.props.languageReducer.currentLanguage.id}`)
        .then(response => {
          this.props.setTeams(response.data)
        })
    }
  }

  render() {
    return (
      <App {...this.props}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    languageReducer: state.languageReducer,
    navigationReducer: state.navigationReducer
  }
}
export default connect(mapStateToProps, {
  setCurrentLanguage,
  setLanguages,
  setCategories,
  setConferences,
  setTeams,
  setHoveredCategory,
  setHoveredConference,
  getLanguages
})(AppContainer)


