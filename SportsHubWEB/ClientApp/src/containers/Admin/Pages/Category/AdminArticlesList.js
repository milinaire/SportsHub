import React, {Component, Fragment} from "react";
import {Link, withRouter} from "react-router-dom";

function AdminArticleItem(props) {
  return (
    <Fragment>
      <div className="link">
        <Link
          to={`/admin/${props.Article.categoryId}/${props.Article.articleId}`}>
          <div className={"article"} style={{display: "flex", margin: "15px"}}>
            <img src={props.Article.imageUri} style={{width: "340px", height: "240px", padding: "10px"}}
                 alt={props.Article.alt}/>
            <div className="article-text">
              <div>
                <h3>{props.Article.headline}</h3>
                <p>{props.Article.caption}</p>
              </div>
              {props.Article.isPublished &&
              <div className="article-text-indicator">
                <p>{props.Article.conferenceName} / {props.Article.teamName}</p>
                <div className="published">
                  <div className="indicator"/>
                  Published
                </div>
              </div>}
            </div>
          </div>
        </Link>
      </div>
    </Fragment>
  )

}


class AdminArticlesList extends Component {

  state = {
    AllArticles: [],
    Articles: []
  }

  componentDidMount() {
    fetch(`sportarticle?languageId=1&categoryId=${this.props.category}&count=444`)
      .then(res => res.json())
      .then(
        (result) => {
          //console.log(result)
          this.setState({
            AllArticles: result
          })
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  componentDidUpdate(prevProps, prevState, snapshot) {

    if (prevProps.match.params.category !== this.props.match.params.category) {
      fetch(`sportarticle?languageId=1&categoryId=${this.props.category}&count=444`)
        .then(res => res.json())
        .then(
          (result) => {
            this.setState({
              AllArticles: result
            })
          },
          (error) => {
            this.setState({
              error
            });
          }
        )
    }
  }

  render() {

    let articles = this.state.AllArticles
    if (this.props.team != 0) {
      articles = this.state.AllArticles.filter(a => this.props.team == a.teamId)
    } else if (this.props.conference != 0) {
      articles = this.state.AllArticles.filter(a => this.props.conference == a.conferenceId)
    }
    if (this.props.published != 0) {
      if (this.props.published == 1) {
        articles = articles.filter(a => true === a.isPublished)
      } else {
        articles = articles.filter(a => false === a.isPublished)
      }

    }

    return (
      <Fragment>
        {
          articles.map(a => {
            return <AdminArticleItem key={a.articleId} Article={a}/>
          })
        }
      </Fragment>
    );
  }
}

export default withRouter(AdminArticlesList)