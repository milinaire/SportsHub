import {applyMiddleware, combineReducers, compose, createStore} from "redux";
import navigationReducer from "./navigation/navigationReducer";
import languageReducer from "./languages/languagesReducer";
import mainArticleReducer from "./mainArticles/mainArticlesReducer";
import articleListReducer from "./articlesList/articlesListReducer";
import sideBarReducer from "./sideBar/sideBarReducer";
import breakdownReducer from "./breakdown/breakdownReducer";
import thunk from "redux-thunk";
import {composeWithDevTools} from "redux-devtools-extension";

let reducer = combineReducers(
  {
    navigationReducer,
    languageReducer,
    mainArticleReducer,
    articleListReducer,
    sideBarReducer,
    breakdownReducer
  }
)
// let store = createStore(reducers, composeWithDevTools(
//   applyMiddleware(thunk),)
// //   compose(applyMiddleware(
// //   thunk
// // ),window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())
// );
const composeEnhancers = composeWithDevTools({

  trace: true,
  traceLimit: 25
});
const store = createStore(reducer, {}, composeEnhancers(
  applyMiddleware(thunk)
));
export default store;