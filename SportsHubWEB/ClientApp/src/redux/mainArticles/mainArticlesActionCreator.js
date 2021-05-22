import {
  SET_MAIN_ARTICLES, SET_CURRENT_ARTICLE, SET_IS_LOADING
} from "./mainArticlesActions";
import {articleAPI} from "../../api/articleAPI";

export const setMainArticles = (mainArticles, link) => ({type: SET_MAIN_ARTICLES, mainArticles, link})
export const setIsLoading = (payload) => ({type: SET_IS_LOADING, payload})
export const setCurrentArticle = (id) => ({type: SET_CURRENT_ARTICLE, id})


export const getMainArticle = (articleId, languageId) => async dispatch => {
  dispatch(setIsLoading(true))
  await articleAPI.getArticle(articleId, languageId).then(data => {
    dispatch(setMainArticles([data], ''))
  })
  dispatch(setIsLoading(false))
}