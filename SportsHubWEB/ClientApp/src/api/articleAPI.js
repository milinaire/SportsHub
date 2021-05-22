import {instance} from "./instance";


export const articleAPI = {
  getArticle(articleId, languageId) {
    return instance.get(`/article/${articleId}?languageId=${languageId}`).then(response => response.data)
  },

}