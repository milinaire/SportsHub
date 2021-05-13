import React, {Component, Fragment} from "react";
import {withRouter} from "react-router-dom";

class MainArticle extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Article: {}
    }
  }

  componentDidMount() {
    fetch(`/article/main/display`)
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            Article: result.find(a => String(a.articleId) === String(this.props.match.params.article))
          });
          this.props.setMainArticles(result.filter(a => String(a.articleId) === String(this.props.match.params.article)), false, '')
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
        <div style={{padding: '50px'}}>
          <div className="text-a">
            <h3 className="text-lg-left">{this.state.Article.text}</h3>
          </div>
          <hr/>
        </div>
      </Fragment>
    )
  }
}

export default withRouter(MainArticle)