import {combineReducers, createStore} from "redux";
import navigationReducer from "./navigation/navigationReducer";
import languageReducer from "./languages/languagesReducer";
import mainArticleReducer from "./mainArticles/mainArticlesReducer";
import articleListReducer from "./articlesList/articlesListReducer";
import sideBarReducer from "./sideBar/sideBarReducer";

let reducers = combineReducers(
  {
    navigationReducer,
    languageReducer,
    mainArticleReducer,
    articleListReducer,
    sideBarReducer
  }
)
let store = createStore(reducers);

export default store;