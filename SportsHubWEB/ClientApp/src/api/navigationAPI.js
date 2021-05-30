import {instance} from "./instance";


export const navigationAPI = {
  getCategories(languageId) {
    return instance.get(`/category?languageId=${languageId}`).then(response => response.data)
  },
  getCategoryLocalization(categoryId) {
    return instance.get(`/category/${categoryId}/localization`).then(response => response.data)
  },
  deleteCategory(categoryId) {
    return instance.delete(`/category/${categoryId}`)
  },
  putCategoryLocalization(categoryId, languageId, name) {
    return instance.put(`/category/${categoryId}/localization/${languageId}`, {
      id: categoryId,
      languageId: languageId,
      name: name
    })
  },
  postCategoryLocalization(categoryId, languageId, name) {
    return instance.post(`/category/${categoryId}/localization`, {
      id: categoryId,
      languageId: languageId,
      name: name
    })
  },
  deleteCategoryLocalization(categoryId, languageId) {
    return instance.delete(`/category/${categoryId}/localization/${languageId}`)
  },
  getConferences(languageId) {
    return instance.get(`/conference?languageId=${languageId}`).then(response => response.data)
  },
  getTeams(languageId) {
    return instance.get(`/team?languageId=${languageId}`).then(response => response.data)
  },
  addCategory(languageId, name) {
    console.log(languageId, name)
    return instance.post(`/category`, {show: true, isEditable: true}).then(response => {
      instance.post(`/category/${response.data.id}/localization`, {
        id: response.data.id,
        languageId: languageId,
        name: name
      }); return response.status
    })
  }
}