import {
  SET_CATEGORIES,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CONFERENCE,
  SET_HOVERED_CATEGORY,
  SET_SELECTED_ADMIN_CATEGORY,
  SET_CURRENT_ADMIN_BUTTON_PANEL,
  SET_IS_LOADING, SET_IS_CATEGORY_MODAL_OPEN, SET_NEW_CATEGORY_NAME
} from "./navigationActions";
import {navigationAPI} from "../../api/navigationAPI";


export const setIsLoading = (payload) => ({type: SET_IS_LOADING, payload})
export const setSelectedAdminCategory = (payload) => ({type: SET_SELECTED_ADMIN_CATEGORY, payload})
export const setCurrentAdminButtonPanel = (payload) => ({type: SET_CURRENT_ADMIN_BUTTON_PANEL, payload})
export const setCategories = (categories) => ({type: SET_CATEGORIES, categories})
export const setConferences = (conferences) => ({type: SET_CONFERENCES, conferences})
export const setTeams = (teams) => ({type: SET_TEAMS, teams})
export const setHoveredCategory = (id) => ({type: SET_HOVERED_CATEGORY, id})
export const setHoveredConference = (id) => ({type: SET_HOVERED_CONFERENCE, id})
export const setIsCategoryModalOpen = (payload) => ({type: SET_IS_CATEGORY_MODAL_OPEN, payload})
export const setNewCategoryName = (payload) => ({type: SET_NEW_CATEGORY_NAME, payload})
export const getNavigation = (languageId) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.getCategories(languageId)
    .then(response => {
      dispatch(setCategories(response))
    })
  await navigationAPI.getConferences(languageId)
    .then(response => {
      dispatch(setConferences(response))
    })
  await navigationAPI.getTeams(languageId)
    .then(response => {
      dispatch(setTeams(response))
    })
  dispatch(setIsLoading(false))
}
export const addCategory = ({languageId, name}) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.addCategory(languageId, name)
  await navigationAPI.getCategories(languageId)
    .then(response => {
      dispatch(setCategories(response))
    })

  dispatch(setIsLoading(false))
}
