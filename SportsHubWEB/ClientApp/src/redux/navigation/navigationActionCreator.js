import {
  SET_CATEGORIES,
  SET_CONFERENCES,
  SET_TEAMS,
  SET_HOVERED_CONFERENCE,
  SET_HOVERED_CATEGORY,
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
} from "./navigationActions";
import {navigationAPI} from "../../api/navigationAPI";


export const setIsLoading = (payload) => ({type: SET_IS_LOADING, payload})
export const setIsDeleting = (payload) => ({type: SET_IS_DELETING, payload})
export const setSelectedLocalizationTab = (payload) => ({type: SET_SELECTED_LOCALIZATION_TAB, payload})
export const changeSelectedIACategoryName = (payload) => ({type: CHANGE_SELECTED_IA_CATEGORY_NAME, payload})
export const setSelectedAdminCategory = (payload) => ({type: SET_SELECTED_ADMIN_CATEGORY, payload})
export const setCurrentAdminButtonPanel = (payload) => ({type: SET_CURRENT_ADMIN_BUTTON_PANEL, payload})
export const setCategories = (categories) => ({type: SET_CATEGORIES, categories})
export const setConferences = (conferences) => ({type: SET_CONFERENCES, conferences})
export const setTeams = (teams) => ({type: SET_TEAMS, teams})
export const setHoveredCategory = (id) => ({type: SET_HOVERED_CATEGORY, id})
export const setHoveredConference = (id) => ({type: SET_HOVERED_CONFERENCE, id})
export const setIsCategoryModalOpen = (payload) => ({type: SET_IS_CATEGORY_MODAL_OPEN, payload})
export const setIsCategoryLocalizationModalOpen = (payload) => ({
  type: SET_IS_CATEGORY_LOCALIZATION_MODAL_OPEN,
  payload
})
export const changeNewCategoryLocalizationName = (payload) => ({type: CHANGE_NEW_CATEGORY_LOCALIZATION_NAME, payload})
export const changeNewCategoryLocalizationLanguage = (payload) => ({
  type: CHANGE_NEW_CATEGORY_LOCALIZATION_LANGUAGE,
  payload
})
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
export const addCategory = ({languageId, name, alert}) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.addCategory(languageId, name).then(r=>{
    if(r===200){
      alert()
    }
  })
  await navigationAPI.getCategories(languageId)
    .then(response => {
      dispatch(setCategories(response))
    })

  dispatch(setIsLoading(false))
}
export const setSelectedIACategory = (payload) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.getCategoryLocalization(payload.categoryId).then(response => {
    dispatch({type: SET_SELECTED_IA_CATEGORY, payload: {id: payload.categoryId, localization: response}})
    dispatch({type: SET_SELECTED_LOCALIZATION_TAB, payload: payload.enId})
  })
  dispatch(setIsLoading(false))
}
export const saveSelectedIACategoryName = (payload) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.putCategoryLocalization(payload.categoryId, payload.languageId, payload.name).then(response => {
    if (response.status === 200) {
      payload.alert()
    }
  })
  await navigationAPI.getCategories(payload.currentLanguage)
    .then(response => {
      dispatch(setCategories(response))
    })
  dispatch(setIsLoading(false))
}
export const postSelectedIACategoryLocalization = (payload) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.postCategoryLocalization(payload.categoryId, payload.languageId, payload.name).then(response => {
    if (response.status === 200) {
      payload.alert()
    }
  })
  await navigationAPI.getCategories(payload.currentLanguage)
    .then(response => {
      dispatch(setCategories(response))
    })
  await navigationAPI.getCategoryLocalization(payload.categoryId).then(response => {
    dispatch({type: SET_SELECTED_IA_CATEGORY, payload: {id: payload.categoryId, localization: response}})
  })
  dispatch(setIsLoading(false))
}
export const deleteSelectedIACategoryLocalization = (payload) => async dispatch => {
  dispatch(setIsLoading(true))
  await navigationAPI.deleteCategoryLocalization(payload.categoryId, payload.languageId).then(response => {
    if (response.status === 200) {
      payload.alert()
    }
  })
  await navigationAPI.getCategories(payload.currentLanguage)
    .then(response => {
      dispatch(setCategories(response))
    })
  await navigationAPI.getCategoryLocalization(payload.categoryId).then(response => {
    dispatch({type: SET_SELECTED_IA_CATEGORY, payload: {id: payload.categoryId, localization: response}})
  })
  dispatch(setIsLoading(false))
}
export const deleteCategory = (payload) => async dispatch => {
  dispatch(setIsDeleting(true))
  dispatch({type: SET_SELECTED_IA_CATEGORY, payload: {id: null, localization: []}})
  await navigationAPI.deleteCategory(payload.categoryId).then(response => {
    if (response.status === 200) {
      payload.alert()
    }
  })

  dispatch(getNavigation(payload.currentLanguage))
  dispatch(setIsDeleting(false))
}