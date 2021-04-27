import React, {Component, Fragment} from "react";
import "./style.css"
import {Link} from "react-router-dom";

function ArticleItem(props) {
  return (
    <Fragment>
      <div className="link">
        <Link
          to={`/nav/${props.Article.categoryId}/${props.Article.conferenceId}/${props.Article.teamId}/${props.Article.articleId}`}>
          <div className={"article"} style={{display: "flex", margin: "15px"}}>
            <img src={props.Article.imageUri} style={{width: "40%", height: "240px", padding: "10px"}}
                 alt={props.Article.alt}/>
            <div>
              <h2>{props.Article.headline}</h2>
              <p>{props.Article.caption}</p>
            </div>
          </div>
        </Link>
      </div>
    </Fragment>
  )

}


export class ListArticles extends Component {


  render() {
    let list = []
    for (let i = 0; i < this.props.Articles.length; i++) {
      if (i < this.props.Articles.length - 1) {
        list.push(
          <div key={this.props.Articles[i].articleId}>
            <ArticleItem Article={this.props.Articles[i]}/>
            <hr key={i + 100} style={{border: "1px solid #eee", margin: 0}}/>
          </div>
        )
      } else {
        list.push(
          <div key={this.props.Articles[i].articleId}>
            <ArticleItem Article={this.props.Articles[i]}/>
          </div>
        )
      }
    }

    return (
      <Fragment>
        {list}
      </Fragment>
    );
  }
}
