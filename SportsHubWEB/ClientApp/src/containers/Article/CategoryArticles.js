import React, {Component, Fragment} from "react";
import "./style.css"
import {PageLayout} from "../../components/Main/Layout/PageLayout";
import {ListArticles} from "./ArticlesList";

export class CategoryArticles extends Component {
  componentDidMount() {
    fetch(`/sportarticle?categoryId=${this.props.match.params.category}`)
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
  }

  state = {
    Articles: [],

  }

  render() {

    return (
      <Fragment>
        <PageLayout MainArticles={this.state.Articles.length > 0 &&[this.state.Articles[0]]} link={this.state.Articles.length > 0 && `nav/${this.state.Articles[0].categoryId}/${this.state.Articles[0].conferenceId}/${this.state.Articles[0].teamId}`} Category={this.props.match.params.category}>
          <div style={{minHeight: "1000px", zIndex: -2}}>
            <ListArticles Articles={this.state.Articles.slice(1)}/>
          </div>
        </PageLayout>
      </Fragment>
    );
  }
}
