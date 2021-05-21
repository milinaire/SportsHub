import {
  SET_CATEGORIES,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CATEGORY,
  SET_HOVERED_CONFERENCE,
  SET_SELECTED_ADMIN_CATEGORY,
  SET_CURRENT_ADMIN_BUTTON_PANEL,
  SET_IS_LOADING, SET_IS_CATEGORY_MODAL_OPEN, SET_NEW_CATEGORY_NAME
} from './navigationActions'


let initialState = {
  categories: [],
  conferences: [],
  teams: [],
  isLoading: false,
  isCategoryModalOpen: false,
  newCategoryName: '',
  hoveredCategory: null,
  hoveredConference: null,
  selectedAdminCategory: null,
  currentButtonPanel: null
}
const navigationReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_IS_LOADING:
      return {...state, isLoading: action.payload};
    case SET_NEW_CATEGORY_NAME:
      return {...state, newCategoryName: action.payload};
    case SET_IS_CATEGORY_MODAL_OPEN:
      return {...state, isCategoryModalOpen: action.payload};
    case SET_CURRENT_ADMIN_BUTTON_PANEL:
      return {...state, currentButtonPanel: action.payload};
    case SET_SELECTED_ADMIN_CATEGORY:
      return {...state, selectedAdminCategory: action.payload};
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