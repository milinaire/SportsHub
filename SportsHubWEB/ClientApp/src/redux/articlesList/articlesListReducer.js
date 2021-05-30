import {
SET_ARTICLES_LIST
} from './articlesListActions'

let initialState = {
  articlesList: []
}
const articleListReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_ARTICLES_LIST:
      return {...state, articlesList: action.articlesList};
    default:
      return state;
  }
}
export default articleListReducer;