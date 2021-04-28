import React, {Component, Fragment} from 'react';
import {PageLayout} from "../../components/Main/Layout/PageLayout";
import {ListArticles} from "./ArticlesList";


export class SubCategoryArticles extends Component {
  componentDidMount() {
    fetch(`/sportarticle?conferenceId=${this.props.match.params.subcategory}`)
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
        <div style={{minHeight: "1000px"}}>
          <ListArticles Articles={this.state.Articles.slice(1)}/>
        </div>
        </PageLayout>
      </Fragment>
    )
  }
}