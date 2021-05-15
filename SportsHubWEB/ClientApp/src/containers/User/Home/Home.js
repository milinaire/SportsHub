import React from "react";
import {connect} from "react-redux";
import axios from 'axios'
import Home from "../../../components/User/Home/Home";
import {setMainArticles, setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";

class HomeAPI extends React.Component {
  componentDidMount() {
    axios.get(`/article/main/display?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setMainArticles(response.data,'/main-article')
      })
  }

  componentWillUnmount() {
    this.props.setMainArticles([])
  }

  render() {
    return (
      <Home/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    mainArticles: state.mainArticleReducer,
    language: state.languageReducer,
  }
}
const HomeContainer = connect(mapStateToProps, {setMainArticles, setCurrentArticle})(HomeAPI)

export default HomeContainer;