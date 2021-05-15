import {combineReducers, createStore} from "redux";
import navigationReducer from "./navigation/navigationReducer";
import languageReducer from "./languages/languagesReducer";
import mainArticleReducer from "./mainArticles/mainArticlesReducer";
import articleListReducer from "./articlesList/articlesListReducer";
import sideBarReducer from "./sideBar/sideBarReducer";
import breakdownReducer from "./breakdown/breakdownReducer";

let reducers = combineReducers(
  {
    navigationReducer,
    languageReducer,
    mainArticleReducer,
    articleListReducer,
    sideBarReducer,
    breakdownReducer
  }
)
let store = createStore(reducers);

export default store;