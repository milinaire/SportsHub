import {
  POST_CATEGORY,
  SET_CATEGORIES,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CATEGORY,
  SET_HOVERED_CONFERENCE, SET_SELECTED_ADMIN_CATEGORY, SET_CURRENT_ADMIN_BUTTON_PANEL
} from './navigationActions'

let initialState = {
  categories: [],
  conferences: [],
  teams: [],
  hoveredCategory: null,
  hoveredConference: null,
  selectedAdminCategory: null,
  currentButtonPanel:null
}
const navigationReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_CURRENT_ADMIN_BUTTON_PANEL:
      return {...state, currentButtonPanel: action.payload};
      case SET_SELECTED_ADMIN_CATEGORY:
      return {...state, selectedAdminCategory: action.payload};
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