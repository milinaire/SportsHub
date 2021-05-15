import React from "react";
import {connect} from "react-redux";
import {setMainArticles, setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";
import {withRouter} from "react-router-dom";
import ArticlesListAPI from "../ArticlesListAPI/ArticlesListAPI";
import {setArticlesList} from "../../../redux/articlesList/articlesListActionCreator";
import {setBanners} from "../../../redux/sideBar/sideBarActionCreator";

const ConferenceArticles = (props) => {
  return (
    <ArticlesListAPI articlesList={props.articlesList} setArticlesList={props.setArticlesList}
                     setMainArticles={props.setMainArticles} language={props.language}
                     category={props.match.params.category}
                     setBanners={props.setBanners}
                     url={`conferenceId=${props.match.params.conference}`}/>
  )
}

let mapStateToProps = (state) => {
  return {
    mainArticles: state.mainArticleReducer,
    language: state.languageReducer,
    articlesList: state.articleListReducer
  }
}
const ConferenceArticlesContainer = connect(mapStateToProps, {
  setMainArticles,
  setCurrentArticle,
  setArticlesList,
  setBanners
})(withRouter(ConferenceArticles))


export default ConferenceArticlesContainer;