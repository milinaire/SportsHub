import React, {Component, Fragment} from "react";
import "./style.css"
import {Link} from "react-router-dom";

export class CategoryArticles extends Component {
  componentDidMount() {
    this.props.setCategory(this.props.match.params.category)
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

      this.props.setCategory(this.props.match.params.category)
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
    this.props.setCategory('')
  }

  state = {
    Articles: []
  }

  render() {
    let list = []
    for (let i = 0; i < this.state.Articles.length; i++) {
      list.push(
        <Link to={`${this.props.match.params.category}/${this.state.Articles[i].categoryId}/${this.state.Articles[i].conferenceId}/${this.state.Articles[i].articleId}`}>
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
    };
    list.pop()
    return (
      <Fragment>
        <div style={{minHeight: "1000px", zIndex: -2}}>
          {this.props.match.params.category}
          {list}
        </div>
      </Fragment>
    );
  }
}
