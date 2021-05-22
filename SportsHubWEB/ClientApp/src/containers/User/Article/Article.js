import React from "react";
import {connect} from "react-redux";
import axios from 'axios'
import {
  setMainArticles,
  setCurrentArticle,
  getMainArticle
} from "../../../redux/mainArticles/mainArticlesActionCreator";
import {withRouter} from "react-router-dom";
import Article from "../../../components/User/Article/Article";
import {articleAPI} from "../../../api/articleAPI";

class ArticleAPI extends React.Component {
  componentDidMount() {
    this.props.getMainArticle(this.props.match.params.article, this.props.language.currentLanguage.id)
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.language.currentLanguage.id !== this.props.language.currentLanguage.id) {
      this.props.getMainArticle(this.props.match.params.article, this.props.language.currentLanguage.id)
    }
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
  {setMainArticles, setCurrentArticle, getMainArticle})(withRouter(ArticleAPI))

export default ArticleContainer;