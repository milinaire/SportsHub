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
        <PageLayout MainArticles={this.state.Articles.length > 0 &&[this.state.Articles[0]]} link={this.state.Articles.length > 0 && `nav/${this.state.Articles[0].categoryId}/${this.state.Articles[0].conferenceId}/${this.state.Articles[0].teamId}`} Category={this.props.match.params.category}>
        <div style={{ minHeight: "1000px" }}>
          <ListArticles Articles={this.state.Articles.slice(1)}/>
        </div>
        </PageLayout>
      </Fragment>
    );
  }
}
