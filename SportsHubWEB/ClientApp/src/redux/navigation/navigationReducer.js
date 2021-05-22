import {
  SET_CATEGORIES,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CATEGORY,
  SET_HOVERED_CONFERENCE,
  SET_SELECTED_ADMIN_CATEGORY,
  SET_CURRENT_ADMIN_BUTTON_PANEL,
  SET_IS_LOADING,
  SET_IS_CATEGORY_MODAL_OPEN,
  SET_NEW_CATEGORY_NAME,
  SET_SELECTED_IA_CATEGORY,
  SET_SELECTED_LOCALIZATION_TAB,
  CHANGE_SELECTED_IA_CATEGORY_NAME,
  SET_IS_CATEGORY_LOCALIZATION_MODAL_OPEN,
  CHANGE_NEW_CATEGORY_LOCALIZATION_NAME, CHANGE_NEW_CATEGORY_LOCALIZATION_LANGUAGE, SET_IS_DELETING
} from './navigationActions'


let initialState = {
  categories: [],
  conferences: [],
  teams: [],
  isLoading: false,
  isDeleting: false,
  isCategoryModalOpen: false,
  isCategoryLocalizationModalOpen: false,
  newCategoryLocalizationName: '',
  newCategoryLocalizationLanguage: {},
  newCategoryName: '',
  selectedIACategory: null,
  selectedIACategoryLocalization: [],
  selectedLocalizationTab: null,
  hoveredCategory: null,
  hoveredConference: null,
  selectedAdminCategory: null,
  currentButtonPanel: null
}
const navigationReducer = (state = initialState, action) => {
  switch (action.type) {
    case SET_IS_LOADING:
      return {...state, isLoading: action.payload};
    case SET_IS_DELETING:
      return {...state, isDeleting: action.payload};
    case SET_SELECTED_IA_CATEGORY:
      return {
        ...state,
        selectedIACategory: action.payload.id,
        selectedIACategoryLocalization: action.payload.localization
      };
    case CHANGE_SELECTED_IA_CATEGORY_NAME:
      return {
        ...state,
        selectedIACategoryLocalization: state.selectedIACategoryLocalization.map(l => {
          if (l.languageId === action.payload.languageId) {
            return {...l, name: action.payload.name}
          } else {
            return l
          }
        })
      };
    case SET_SELECTED_LOCALIZATION_TAB:
      return {...state, selectedLocalizationTab: action.payload};
    case CHANGE_NEW_CATEGORY_LOCALIZATION_NAME:
      return {...state, newCategoryLocalizationName: action.payload};
    case CHANGE_NEW_CATEGORY_LOCALIZATION_LANGUAGE:
      return {...state, newCategoryLocalizationLanguage: action.payload};
    case SET_NEW_CATEGORY_NAME:
      return {...state, newCategoryName: action.payload};
    case SET_IS_CATEGORY_MODAL_OPEN:
      return {...state, isCategoryModalOpen: action.payload};
    case SET_IS_CATEGORY_LOCALIZATION_MODAL_OPEN:
      return {...state, isCategoryLocalizationModalOpen: action.payload};
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