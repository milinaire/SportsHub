import React, {Fragment} from 'react'
import Loader from "../../../CustomLoader/Loader";

const Article = (props) => {
  return (
    <Fragment>
      <p>
        {props.mainArticles.mainArticles.length ? props.mainArticles.mainArticles.find(a => a.articleId === props.mainArticles.currentArticle).text
          : "Loading..."
        }
      </p>
    </Fragment>
  )
}
export default Article;