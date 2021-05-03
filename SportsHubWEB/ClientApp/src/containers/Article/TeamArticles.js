import React, { Component, Fragment } from "react";
import {ListArticles} from "./ArticlesList";
import {withRouter} from "react-router-dom";

class TeamArticles extends Component {
  componentDidMount(){
    fetch(`/sportarticle?teamId=${this.props.match.params.team}`)
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            Articles: result
          });
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }
  getSnapshotBeforeUpdate(prevProps, prevState){
    return this.props.match.params.category
  }
  componentDidUpdate(prevProps, prevState, snapshot) {
    if(prevProps.match.params.team!==this.props.match.params.team){
      fetch(`/sportarticle?teamId=${this.props.match.params.team}`)
        .then(res => res.json())
        .then(
          (result) => {
            this.setState({
              Articles: result
            });
          },
          (error) => {
            this.setState({
              error
            });
          }
        )
    }
  }
  componentWillUnmount(){

  }
  state={
    Articles: [

    ],
  }
  render() {
    return (
      <Fragment>
        <div style={{ minHeight: "1000px" }}>
          <ListArticles Articles={this.state.Articles.slice(1)}/>
        </div>
      </Fragment>
    );
  }
}
export default withRouter(TeamArticles)
