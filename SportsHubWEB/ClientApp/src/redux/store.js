import {combineReducers, createStore} from "redux";
import navigationReducer from "./navigation/navigationReducer";
import languageReducer from "./languages/languagesReducer";
import mainArticleReducer from "./mainArticles/mainArticlesReducer";

let reducers = combineReducers(
  {
    navigationReducer,
    languageReducer,
    mainArticleReducer
  }
)
let store = createStore(reducers);

export default store;