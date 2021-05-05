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
          this.props.setMainArticles([result], false, '')
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  componentWillUnmount() {
    this.props.setMainArticles([])
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

