import React from "react";
import {connect} from "react-redux";
import MainArticles from "../../../components/User/MainArticles/MainArticles";
import {setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";

class MainArticlesAPI extends React.Component {
  render() {
    return (
      <MainArticles categories={this.props.navigation.categories} mainArticles={this.props.mainArticles}
                    setCurrentArticle={this.props.setCurrentArticle}/>
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