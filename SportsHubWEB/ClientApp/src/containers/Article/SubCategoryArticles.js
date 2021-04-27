import React, {Component, Fragment} from 'react';
import {PageLayout} from "../../components/Main/Layout/PageLayout";
import {ListArticles} from "./ArticlesList";


export class SubCategoryArticles extends Component {
  componentDidMount() {
    fetch(`https://localhost:5001/sportarticle?conferenceId=${this.props.match.params.subcategory}`)
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
      fetch(`https://localhost:5001/sportarticle?conferenceId=${this.props.match.params.subcategory}`)
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
        <PageLayout MainArticles={[]}>
        <div style={{minHeight: "1000px"}}>
          {this.props.match.params.category}~
          {this.props.match.params.subcategory}
          <ListArticles Articles={this.state.Articles}/>
        </div>
        </PageLayout>
      </Fragment>
    )
  }
}