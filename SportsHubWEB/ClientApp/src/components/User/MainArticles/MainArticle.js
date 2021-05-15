import React, {Component, Fragment} from "react";
import {Link} from "react-router-dom";
import style from './MainArticle.module.css'

const MainArticle = (props) => {
  return (
    <Fragment>
      <div className={style.mainArticleWrapper}>

        <div className={style.mainArticleImg}>
          <div style={{backgroundImage: `url(${props.article.imageUri})`, width:'100%', height:'100%', backgroundRepeat: 'no-repeat', backgroundSize:'100% 100%', transition: 'background 400ms'}}>
            <div className={style.mainArticleCategory}>
              {props.categories.find(c=>c.id === props.article.categoryId).name}
            </div>
            <div className={style.mainArticleInfo}>

            </div>
            <div className={style.mainArticleButtons}>
              {props.buttons}
            </div>
          </div>
        </div>


      </div>
      {/*<div className="main-articles"*/}
      {/*     style={{backgroundImage: `url(${props})`}}*/}
      {/*     */}
      {/*>*/}
      {/*  */}
      {/*      <div className="cat">*/}
      {/*        {this.state.Categories && this.state.Categories.find(category => String(category.id) === String(this.props.articles[this.state.index].categoryId)).name}*/}
      {/*      </div>*/}
      {/*      */}
      {/*  <div className="info">*/}
      {/*    <div className="table">*/}
      {/*      <div className="text-table">*/}
      {/*        <p className="published">Published / {this.props.articles[this.state.index].datePublished}</p>*/}
      {/*        <b className="head">{this.props.articles[this.state.index].headline}</b>*/}
      {/*        <b className="caption">{this.props.articles[this.state.index].caption}</b>*/}
      {/*      </div>*/}
      {/*      */}
      {/*        <div className="link-more">*/}
      {/*          <b>Share</b>*/}
      {/*        </div>*/}
      {/*      */}
      {/*    </div>*/}
      {/*    */}
      {/*  </div>*/}
      {/*</div>*/}
    </Fragment>
  );
}

export default MainArticle;
