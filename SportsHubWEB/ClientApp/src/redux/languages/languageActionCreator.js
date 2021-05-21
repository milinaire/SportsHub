import {
  SET_CURRENT_LANGUAGE, SET_IS_LOADING, SET_IS_MODAL_OPEN,
  SET_LANGUAGES, SET_NEW_LANGUAGES
} from "./languageActions";
import {languageAPI} from "../../api/languageAPI";
import i18next from "i18next";
import React from "react";


export const setIsLoading = (payload) => ({type: SET_IS_LOADING, payload})
export const setLanguages = (payload) => ({type: SET_LANGUAGES, payload})
export const getLanguages = () => async dispatch => {
  dispatch(setIsLoading(true))
  await languageAPI.getLanguages().then(data => {
    dispatch(setLanguages(data))
  })
  dispatch(setIsLoading(false))
}
export const setCurrentLanguage = (payload) => async dispatch => {
  dispatch(setIsLoading(true))
  await i18next.changeLanguage(payload)
  dispatch({type: SET_CURRENT_LANGUAGE, payload})
  dispatch(setIsLoading(false))
}
export const addLanguages = (payload) => async dispatch => {
  dispatch(setIsLoading(true))
  for (let i = 0; i < payload.languages.length; i++) {
    await languageAPI.addLanguage(payload.languages[i].value).then(response => response.status === 201
      ?
      payload.alert.show({
        header: 'Success!',
        content: `${payload.languages[i].label} language is successfully added.`
      }, {type: 'success'})
      :
      payload.alert.show({
        header: 'Error!',
        content: 'Something got wrong.'
      }, {type: 'error'})
    )
  }
  await languageAPI.getLanguages().then(data => {
    dispatch(setLanguages(data))
  })
  dispatch(setIsLoading(false))
}
export const setIsModalOpen = (payload) => ({type: SET_IS_MODAL_OPEN, payload})
export const setNewLanguages = (payload) => ({type: SET_NEW_LANGUAGES, payload})
export const deleteLanguage = (payload) => {
  return async dispatch => {
    dispatch(setIsLoading(true))
    await languageAPI.deleteLanguage(payload.language.id).then(response => response.status === 200
      ?
      payload.alert.show({
        header: 'Success!',
        content: `${payload.language.label} language is successfully deleted.`
      }, {type: 'success'})
      :
      payload.alert.show({
        header: 'Error!',
        content: 'Something got wrong.'
      }, {type: 'error'})
    )
    await languageAPI.getLanguages().then(data => {
      dispatch(setLanguages(data))
    })
    dispatch(setIsLoading(false))
  }
}






