import React, {Fragment} from "react";
import MainArticle from "./MainArticle";
import style from './MainArticle.module.css'

const MainArticles = (props) => {
  let buttons = []
  for (let i = 0; i < props.mainArticles.mainArticles.length; i++) {
    if (props.mainArticles.mainArticles[i].articleId === props.mainArticles.currentArticle) {
      buttons.push(
        <button key={i + 2} className={style.activeBtn}
                onClick={() => props.setCurrentArticle(props.mainArticles.mainArticles[i].articleId)}>
          {"0" + (i + 1)}
        </button>
      )
    } else {
      buttons.push(
        <button key={i + 2} className={style.simpleBtn}
                onClick={() => props.setCurrentArticle(props.mainArticles.mainArticles[i].articleId)}>
          {"0" + (i + 1)}
        </button>)
    }
  }

  return (
    <Fragment>
      {props.mainArticles.mainArticles.map(article => {
          return (article.articleId === props.mainArticles.currentArticle &&
            <MainArticle link={props.mainArticles.link} key={article.articleId}
                         buttons={props.mainArticles.mainArticles.length > 1 ? buttons : null} article={article}
                         categories={props.categories}/>)
        }
      )}
    </Fragment>
  );
}

export default MainArticles;
