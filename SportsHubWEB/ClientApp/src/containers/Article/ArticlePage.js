import 'bootstrap/dist/css/bootstrap.css';
import React, {Component, Fragment} from 'react';
import {withRouter} from "react-router-dom";

class SportArticle extends Component {
  state = {
    Article: {}
  }

  componentDidMount() {

    fetch(`/sportarticle/${this.props.match.params.article}`)
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            Article: result
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
    }
  }

  componentWillUnmount() {
  }

  render() {
    return (
      <Fragment>
        <div style={{padding: '0 50px'}}>
          <div className="text-a">
            <h3 className="text-lg-left">{this.state.Article.text}</h3>
          </div>
          <hr/>
        </div>
      </Fragment>
    )
  }
}

export default withRouter(SportArticle)

