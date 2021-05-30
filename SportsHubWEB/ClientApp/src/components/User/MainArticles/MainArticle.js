import React, {Fragment} from "react";
import style from './MainArticle.module.css'
import {Link} from "react-router-dom";
import {useTranslation} from "react-i18next";


const MainArticle = (props) => {
  const {t}=useTranslation();
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
              <div>
                <div className={style.mainArticleInfoDate}>Published / {new Date(props.article.datePublished).toLocaleDateString()}</div>
                <div className={style.mainArticleInfoHeadline}>{props.article.headline}</div>
                <div className={style.mainArticleInfoCaption}>{props.article.caption}</div>
              </div>
              {props.link
                ?<Link className={style.mainArticleInfoMore} to={`${props.link}/${props.article.articleId}`}>{t('User/MainArticles/MainArticle/More')}</Link>
                :<div className={style.mainArticleInfoShare}>Share</div>
              }
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
