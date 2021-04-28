import React, {Component, Fragment} from "react";
import "./style.css"
import {PageLayout} from "../../components/Main/Layout/PageLayout";
import {ListArticles} from "./ArticlesList";

export class CategoryArticles extends Component {
  componentDidMount() {
    fetch(`https://localhost:5001/sportarticle?categoryId=${this.props.match.params.category}`)
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
      fetch(`https://localhost:5001/sportarticle?categoryId=${this.props.match.params.category}`)
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
    Articles: []
  }

  render() {

    return (
      <Fragment>
        <PageLayout MainArticles={[]}>
          <div style={{minHeight: "1000px", zIndex: -2}}>
            {this.props.match.params.category}
            <ListArticles Articles={this.state.Articles}/>
          </div>
        </PageLayout>
      </Fragment>
    );
  }
}
