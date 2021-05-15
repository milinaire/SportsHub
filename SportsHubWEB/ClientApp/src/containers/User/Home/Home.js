import React from "react";
import {connect} from "react-redux";
import axios from 'axios'
import Home from "../../../components/User/Home/Home";
import {setMainArticles, setCurrentArticle} from "../../../redux/mainArticles/mainArticlesActionCreator";
import {getBanners} from "../SideBar/getBunners";
import {setBanners} from "../../../redux/sideBar/sideBarActionCreator";
import {clearBreakdown, setBreakdown} from "../../../redux/breakdown/breakdownActionCreator";
import breakdownReducer from "../../../redux/breakdown/breakdownReducer";

class HomeAPI extends React.Component {
  componentDidMount() {
    axios.get(`/article/main/display?languageId=${this.props.language.currentLanguage.id}`)
      .then(response => {
        this.props.setMainArticles(response.data, '/main-article')
      });
    axios.get(`breakdown`)
      .then(response => {
        response.data.map(breakdown => {
          console.log(breakdown)
          let url
          let name
          if (breakdown.teamId) {
            url = `teamId=${breakdown.teamId}&`
            name = breakdown.teamName
          } else if (breakdown.conferenceId) {
            url = `conferenceId=${breakdown.conferenceId}&`
            name = breakdown.conferenceName
          } else if (breakdown.categoryId) {
            url = `categoryId=${breakdown.categoryId}&`
            name = breakdown.categoryName
          }
          axios.get(`/sportarticle?${url}count=4&languageId=${this.props.language.currentLanguage.id}`)
            .then(response => {
              this.props.setBreakdown(response.data, name)
            })


        })
      });
    getBanners('', this.props.language.currentLanguage.id, this.props.setBanners)
  }

  componentWillUnmount() {
    this.props.setMainArticles([])
    this.props.setBanners([])
    this.props.clearBreakdown()
  }

  render() {
    console.log(this.props.breakdown)
    return (
      <Home breakdown={this.props.breakdown}/>
    )
  }
}

let mapStateToProps = (state) => {
  return {
    mainArticles: state.mainArticleReducer,
    language: state.languageReducer,
    breakdown: state.breakdownReducer
  }
}
const HomeContainer = connect(mapStateToProps, {
  setMainArticles,
  setCurrentArticle,
  setBanners,
  setBreakdown,
  clearBreakdown
})(HomeAPI)

export default HomeContainer;