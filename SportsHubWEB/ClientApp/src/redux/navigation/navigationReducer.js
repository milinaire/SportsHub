import {
  POST_CATEGORY,
  SET_CATEGORIES,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CATEGORY,
  SET_HOVERED_CONFERENCE
} from './navigationActions'

let initialState = {
  categories: [],
  conferences: [],
  teams: [],
  hoveredCategory: null,
  hoveredConference: null
}
const navigationReducer = (state = initialState, action) => {
  switch (action.type) {
    case POST_CATEGORY:
      return {...state, categories: [...state.categories, {id: 10, name: action.name}]};
    case SET_CATEGORIES:
      return {...state, categories: action.categories};
    case SET_CONFERENCES:
      return {...state, conferences: action.conferences};
    case SET_TEAMS:
      return {...state, teams: action.teams};
    case SET_HOVERED_CATEGORY:
      return {...state, hoveredCategory: action.id};
    case SET_HOVERED_CONFERENCE:
      return {...state, hoveredConference: action.id};
    default:
      return state;
  }
}
export default navigationReducer;