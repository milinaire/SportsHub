import {instance} from "./instance";


export const languageAPI = {
  getLanguages() {
    return instance.get(`/language`).then(response => response.data)
  },
  addLanguage(body) {
    return instance.post(`/language`, {languageName: body}).then(response => response)
  },
  deleteLanguage(id) {
    return instance.delete(`/language/${id}`).then(response => response)
  }
}