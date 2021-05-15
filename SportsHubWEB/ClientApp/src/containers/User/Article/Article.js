import React from "react";
import {connect} from "react-redux";
import axios from 'axios'
import {setMainArticles, setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";
import {withRouter} from "react-router-dom";
import Article from "../../../components/User/Article/Article";

class ArticleAPI extends React.Component {
  componentDidMount() {
    axios.get(`/article/${this.props.match.params.article}?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setMainArticles([response.data], '')
      })
  }

  componentWillUnmount() {
    this.props.setMainArticles([])
  }

  render() {
    return (
      <Article mainArticles={this.props.mainArticles}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    mainArticles: state.mainArticleReducer,
    language: state.languageReducer,
  }
}
const ArticleContainer = connect(mapStateToProps,
  {setMainArticles, setCurrentArticle})(withRouter(ArticleAPI))

export default ArticleContainer;