import React from "react";
import {connect} from "react-redux";
import {setMainArticles, setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";
import {withRouter} from "react-router-dom";
import ArticlesListAPI from "../ArticlesListAPI/ArticlesListAPI";
import {setArticlesList} from "../../../redux/articlesList/articlesListActionCreator";
import {setBanners} from "../../../redux/sideBar/sideBarActionCreator";


const CategoryArticles = (props) => {
  return (
    <ArticlesListAPI articlesList={props.articlesList} setArticlesList={props.setArticlesList}
                     setMainArticles={props.setMainArticles} language={props.language}
                     category={props.match.params.category}
                     setBanners={props.setBanners}
                     link={props.match.params.category}
                     url={`categoryId=${props.match.params.category}`}/>
  )
}

let mapStateToProps = (state) => {
  return {
    mainArticles: state.mainArticleReducer,
    language: state.languageReducer,
    articlesList: state.articleListReducer
  }
}
const CategoryArticlesContainer = connect(mapStateToProps, {
  setMainArticles,
  setCurrentArticle,
  setArticlesList,
  setBanners

})(withRouter(CategoryArticles))


export default CategoryArticlesContainer;