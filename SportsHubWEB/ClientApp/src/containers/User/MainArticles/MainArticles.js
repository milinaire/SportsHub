import React, {Fragment} from "react";
import UserLayout from "../../../components/User/UserLayout/UserLayout";
import {connect} from "react-redux";
import {setCurrentLanguage, setLanguages} from "../../../redux/languages/languageActionCreator";
import axios from 'axios'
import MainArticles from "../../../components/User/MainArticles/MainArticles";
import {setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";

class MainArticlesAPI extends React.Component {
  componentDidMount() {

  }

  render() {
    console.log(this.props.navigation.categories)
    return (
      <MainArticles categories={this.props.navigation.categories} mainArticles={this.props.mainArticles} setCurrentArticle={this.props.setCurrentArticle}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    mainArticles: state.mainArticleReducer,
    navigation: state.navigationReducer
  }
}
const MainArticlesContainer = connect(mapStateToProps, {setCurrentArticle})(MainArticlesAPI)


export default MainArticlesContainer;