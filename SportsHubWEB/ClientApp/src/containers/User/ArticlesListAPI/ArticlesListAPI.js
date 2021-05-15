import React from "react";
import axios from 'axios'
import ArticlesList from "../../../components/User/ArticlesList/ArticlesList";
import {getBanners} from "../SideBar/getBunners";


const getArticles = (url, language, setMainArticles, setArticlesList) => {
  axios.get(`/sportarticle?${url}&count=100&languageId=${language}`)
    .then(response => {
      if (response.data.length) {
        setMainArticles([response.data[0]], `/nav/${response.data[0].categoryId}/${response.data[0].conferenceId}/${response.data[0].teamId}`);
        setArticlesList(response.data.slice(1));
      } else {
        setMainArticles([]);
        setArticlesList([]);
      }
    })
}

class ArticlesListAPI extends React.Component {
  componentDidMount() {
    getArticles(this.props.url, this.props.language.currentLanguage.id,
      this.props.setMainArticles, this.props.setArticlesList)
    getBanners(`categoryId=${this.props.category}&`, this.props.language.currentLanguage.id, this.props.setBanners)

  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.url !== this.props.url) {
      getArticles(this.props.url, this.props.language.currentLanguage.id,
        this.props.setMainArticles, this.props.setArticlesList)
    }
    if (prevProps.category !== this.props.category) {
      getBanners(`categoryId=${this.props.category}&`, this.props.language.currentLanguage.id, this.props.setBanners)
    }
  }

  componentWillUnmount() {
    this.props.setMainArticles([]);
    this.props.setArticlesList([]);
    this.props.setBanners([])
  }

  render() {
    return (
      <ArticlesList articles={this.props.articlesList.articlesList}/>
    )
  }
}

export default ArticlesListAPI;