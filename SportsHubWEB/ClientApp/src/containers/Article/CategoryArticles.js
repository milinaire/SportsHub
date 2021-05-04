import React, {Component, Fragment} from "react";
import "./style.css"
import {ListArticles} from "./ArticlesList";
import {withRouter} from "react-router-dom";

class CategoryArticles extends Component {
  componentDidMount() {
    fetch(`/sportarticle?categoryId=${this.props.match.params.category}`)
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            Articles: result
          });
          if(result.length>0){
            console.log(result[0])
            this.props.setMainArticles([result[0]], false, `nav/${result[0].categoryId}/${result[0].conferenceId}/${result[0].teamId}`)
          }
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  getSnapshotBeforeUpdate(prevProps, prevState) {
    return this.props.match.params.category
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.match.params.category !== this.props.match.params.category) {


      fetch(`/sportarticle?categoryId=${this.props.match.params.category}`)
        .then(res => res.json())
        .then(
          (result) => {
            this.setState({
               Articles: result
            });
            console.log(result)
            if(result.length>0){
              console.log(result)
              this.props.setMainArticles([result[0]], false, `nav/${result[0].categoryId}/${result[0].conferenceId}/${result[0].teamId}`)
            }else{
              this.props.setMainArticles([])
            }

          },
          (error) => {
            this.setState({
              error
            });
          }
        )
    }
  }


  componentWillUnmount() {
    this.props.setMainArticles([])
  }

  state = {
    Articles: [],

  }

  render() {

    return (
      <Fragment>
          <div style={{minHeight: "1000px", zIndex: -2}}>
            <ListArticles Articles={this.state.Articles.slice(1)}/>
          </div>
      </Fragment>
    );
  }
}
export default withRouter(CategoryArticles)