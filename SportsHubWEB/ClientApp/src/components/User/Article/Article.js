import React, {Fragment} from 'react'

const Article = (props) => {
  return (
    <Fragment>
      <p>{props.mainArticles.currentArticle
        ? props.mainArticles.mainArticles.find(a => a.articleId === props.mainArticles.currentArticle).text
        : 'Loading...'}
      </p>
    </Fragment>
  )
}
export default Article;