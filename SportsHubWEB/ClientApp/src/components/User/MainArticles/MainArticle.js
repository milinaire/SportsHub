import React, {Fragment} from "react";
import style from './MainArticle.module.css'
import {Link} from "react-router-dom";

const MainArticle = (props) => {

  return (
    <Fragment>
      <div className={style.mainArticleWrapper}>
        <div className={style.mainArticleImg}>
          <div style={{
            backgroundImage: `url(${props.article.imageUri})`,
            width: '100%',
            height: '100%',
            backgroundRepeat: 'no-repeat',
            backgroundSize: '100% 100%',
          }}>
            <div className={style.mainArticleCategory}>
              {props.categories.length ? props.categories.find(c => c.id === props.article.categoryId).name : 'Loading...'}
            </div>
            <div className={style.mainArticleInfo}>
              Published / {new Date(props.article.datePublished).toLocaleDateString()}
              <div>{props.article.headline}</div>
              <div>{props.article.caption}</div>
              {props.link?<Link to={`${props.link}/${props.article.articleId}`}>More</Link>:'share'}
            </div>
            <div className={style.mainArticleButtons}>
              {props.buttons}
            </div>
          </div>
        </div>
      </div>
    </Fragment>
  );
}

export default MainArticle;
