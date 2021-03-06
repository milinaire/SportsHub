import {
  SET_CURRENT_ARTICLE, SET_IS_LOADING,
  SET_MAIN_ARTICLES
} from './mainArticlesActions'

let initialState = {
  isLoading: false,
  mainArticles: [],
  link: '',
  currentArticle: null
}
const mainArticleReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_CURRENT_ARTICLE:
      return {...state, currentArticle: action.id};
    case SET_IS_LOADING:
      return {...state, isLoading: action.payload};
    case SET_MAIN_ARTICLES:
      return {
        ...state,
        mainArticles: action.mainArticles,
        link: action.link,
        currentArticle: action.mainArticles.length ? action.mainArticles[0].articleId : null
      };
    default:
      return state;
  }
}
export default mainArticleReducer;