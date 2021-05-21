import {instance} from "./instance";


export const navigationAPI = {
  getCategories(languageId) {
    return instance.get(`/category?languageId=${languageId}`).then(response => response.data)
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
      }).then(r => console.log(r))

    })
  }
}