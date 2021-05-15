import React, {Fragment} from "react";
import {Link} from "react-router-dom";
import style from './ArticlesList.module.css'

function ArticleItem(props) {
  return (
    <Fragment>
      <div className={style.article}>
        <Link className={style.articleLink}
          to={`/nav/${props.Article.categoryId}/${props.Article.conferenceId}/${props.Article.teamId}/${props.Article.articleId}`}>
          <div className={"article"} style={{display: "flex", margin: "15px"}}>
            <img src={props.Article.imageUri} style={{width: "340px", height: "240px", padding: "10px"}}
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


const ArticlesList = (props) => {
  let list = []
  for (let i = 0; i < props.articles.length; i++) {
    if (i < props.articles.length - 1) {
      list.push(
        <div key={props.articles[i].articleId}>
          <ArticleItem Article={props.articles[i]}/>
          {/*<hr key={i + 100} style={{border: "1px solid #eee", margin: 0}}/>*/}
        </div>
      )
    } else {
      list.push(
        <div key={props.articles[i].articleId}>
          <ArticleItem Article={props.articles[i]}/>
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
export default ArticlesList;
