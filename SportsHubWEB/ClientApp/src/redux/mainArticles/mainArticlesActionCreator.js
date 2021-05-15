import {
SET_MAIN_ARTICLES, SET_CURRENT_ARTICLE
} from "./mainArticlesActions";

export const setMainArticles = (mainArticles, link) => ({type: SET_MAIN_ARTICLES, mainArticles, link})
export const setCurrentArticle = (id) => ({type: SET_CURRENT_ARTICLE, id})


