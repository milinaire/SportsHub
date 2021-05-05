import React, {Component, Fragment} from 'react';
import {ListArticles} from "./ArticlesList";
import {withRouter} from "react-router-dom";


class SubCategoryArticles extends Component {
  componentDidMount() {
    fetch(`/sportarticle?conferenceId=${this.props.match.params.subcategory}`)
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
    return this.props.match.params.subcategory
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.match.params.subcategory !== this.props.match.params.subcategory) {
      fetch(`/sportarticle?conferenceId=${this.props.match.params.subcategory}`)
        .then(res => res.json())
        .then(
          (result) => {
            this.setState({
              Articles: result
            });
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
        <div style={{minHeight: "1000px"}}>
          <ListArticles Articles={this.state.Articles.slice(1)}/>
        </div>
      </Fragment>
    )
  }
}
export default withRouter(SubCategoryArticles)