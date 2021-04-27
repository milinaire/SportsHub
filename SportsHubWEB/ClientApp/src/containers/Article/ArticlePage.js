import 'bootstrap/dist/css/bootstrap.css';
import React, {Component, Fragment} from 'react';
import {PageLayout} from "../../components/Main/Layout/PageLayout";


export  class Article extends Component {
  state = {
    Article: {}
  }

  componentDidMount() {

    fetch(`https://localhost:5001/sportarticle/${this.props.match.params.article}`)
      .then(res => res.json())
      .then(
        (result) => {
          console.log(result)
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
      console.log("hi", this.props.match.params.category)
    }
  }

  componentWillUnmount() {
  }

  render() {
    return (
      <Fragment>
        <PageLayout MainArticles={[]}>
        <div style={{padding: '50px'}}>
          <div className="title-a" style={{textAlign: "center"}}>
            <h1>{this.state.Article.headline}</h1>
          </div>
          <div className="img-a">
            <img style={{
              width: "calc(100vw - 870px)"
            }}
                 src={this.state.Article.imageUri} alt={this.state.Article.alt}/>
          </div>
          <hr/>
          <div className="text-a">
            <h3 className="text-lg-left">{this.state.Article.text}</h3>
          </div>
          <hr/>
        </div>
        </PageLayout>
      </Fragment>
    )
  }
}
