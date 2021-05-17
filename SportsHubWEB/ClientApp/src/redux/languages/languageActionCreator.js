import {
  ADD_CHANGE_LANGUAGE,
  ADD_NEW_LANGUAGE, CHANGE_LANGUAGE,
  CHANGE_NEW_LANGUAGE, DELETE_LANGUAGE, DELETE_NEW_LANGUAGE, GET_LANGUAGES,
  POST_NEW_LANGUAGE, PUT_LANGUAGE,
  SET_CURRENT_LANGUAGE,
  SET_LANGUAGES
} from "./languageActions";


export const setCurrentLanguage = (id) => ({type: SET_CURRENT_LANGUAGE, id})
export const addChangeLanguage = (id) => ({type: ADD_CHANGE_LANGUAGE, id})
export const addNewLanguage = () => ({type: ADD_NEW_LANGUAGE})
export const deleteNewLanguage = () => ({type: DELETE_NEW_LANGUAGE})
export const changeNewLanguage = (name) => ({type: CHANGE_NEW_LANGUAGE, name})
export const changeLanguage = (name) => ({type: CHANGE_LANGUAGE, name})
export const setLanguages = (languages) => ({type: SET_LANGUAGES, languages})


export const postNewLanguage = (newLanguage) => {
  return async dispatch => {

    const Language = {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        languageName: newLanguage.languageName
      })
    };


    await fetch(`/language`, Language)
    dispatch({type: POST_NEW_LANGUAGE})
    const response = await fetch(`/language`)
    const json = await response.json()
    dispatch({type: GET_LANGUAGES, payload: json})
  }
}
export const deleteLanguage = (id) => {
  return async dispatch => {
    const deleteLanguage = {
      method: 'DELETE',

    };
    await fetch(`/language/${id}`, deleteLanguage)
    const response = await fetch(`/language`)
    const json = await response.json()
    dispatch({type: DELETE_LANGUAGE, payload: json})
  }
}
export const putLanguage = (changingLanguage) => {
  return async dispatch => {
    const changedLanguage = {
      method: 'PUT',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify({
        languageName: changingLanguage.languageName
      })
    };
    await fetch(`/language/${changingLanguage.id}`, changedLanguage)
    const response = await fetch(`/language`)
    const json = await response.json()
    dispatch({type: PUT_LANGUAGE, payload: json})
  }
}
export const getLanguages = () => {
  return async dispatch => {
    const response = await fetch(`/language`)
    const json = await response.json()
    dispatch({type: GET_LANGUAGES, payload: json})
  }
}