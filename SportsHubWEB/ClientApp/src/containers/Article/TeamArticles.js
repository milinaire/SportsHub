import React, { Component, Fragment } from "react";

import {PageLayout} from "../../components/Main/Layout/PageLayout";
import {ListArticles} from "./ArticlesList";

export class TeamArticles extends Component {
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
        <PageLayout MainArticles={[]}>
        <div style={{ minHeight: "1000px" }}>
          {this.props.match.params.category}~
          {this.props.match.params.subcategory}~{this.props.match.params.team}
          <ListArticles Articles={this.state.Articles}/>
        </div>
        </PageLayout>
      </Fragment>
    );
  }
}
