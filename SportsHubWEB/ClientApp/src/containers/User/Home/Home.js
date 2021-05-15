import React from "react";
import {connect} from "react-redux";
import axios from 'axios'
import Home from "../../../components/User/Home/Home";
import {setMainArticles, setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";
import {getBanners} from "../SideBar/getBunners";
import {setBanners} from "../../../redux/sideBar/sideBarActionCreator";

class HomeAPI extends React.Component {
  componentDidMount() {
    axios.get(`/article/main/display?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setMainArticles(response.data,'/main-article')
      });
    getBanners('', this.props.language.currentLanguage.id, this.props.setBanners)
  }

  componentWillUnmount() {
    this.props.setMainArticles([])
    this.props.setBanners([])
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
const HomeContainer = connect(mapStateToProps, {setMainArticles, setCurrentArticle, setBanners})(HomeAPI)

export default HomeContainer;