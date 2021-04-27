import React, {Component, Fragment} from 'react';
import {Link} from "react-router-dom";
import {PageLayout} from "../../components/Main/Layout/PageLayout";


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
    let list = []
    for (let i = 0; i < this.state.Articles.length; i++) {
      list.push(
        <Link
          to={`${this.props.match.params.subcategory}/${this.state.Articles[i].conferenceId}/${this.state.Articles[i].articleId}`}>
          <div className={"article"} style={{display: "flex", margin: "15px"}}>
            <img src={this.state.Articles[i].imageUri} style={{width: "40%", height: "240px", padding: "10px"}}
                 alt={this.state.Articles[i].alt}/>
            <div>
              <h2>{this.state.Articles[i].headline}</h2>
              <p>{this.state.Articles[i].caption}</p>
            </div>
          </div>
        </Link>
      )
      list.push(<hr style={{border: "1px solid #eee", margin: 0}}/>)
    }
    list.pop()
    return (
      <Fragment>
        <PageLayout MainArticles={[]}>
        <div style={{minHeight: "1000px"}}>
          {this.props.match.params.category}~
          {this.props.match.params.subcategory}
          {list}
        </div>
        </PageLayout>
      </Fragment>
    )
  }
}