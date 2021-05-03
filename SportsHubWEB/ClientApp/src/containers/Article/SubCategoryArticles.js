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
        <div style={{minHeight: "1000px"}}>
          <ListArticles Articles={this.state.Articles.slice(1)}/>
        </div>
      </Fragment>
    )
  }
}
export default withRouter(SubCategoryArticles)