import {
  SET_BREAKDOWN,
  CLEAR_BREAKDOWN
} from './breakdownActions'

let initialState = {
  breakdown: [],
}
const breakdownReducer = (state = initialState, action) => {
  switch (action.type) {
    case CLEAR_BREAKDOWN:
      return {
        ...state,
        breakdown: []
      };
    case SET_BREAKDOWN:
      return {
        ...state,
        breakdown: [...state.breakdown, {articles: action.articles, name: action.name}]
      };
    default:
      return state;
  }
}
export default breakdownReducer;