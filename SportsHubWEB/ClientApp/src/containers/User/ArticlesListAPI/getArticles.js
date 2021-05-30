import axios from "axios";

export const getArticles = (url, language, setMainArticles, setArticlesList) => {
  axios.get(`/sportarticle?${url}&count=100&languageId=${language}`)
    .then(response => {
      if (response.data.length) {
        setMainArticles([response.data[0]], `/nav/${response.data[0].categoryId}/${response.data[0].conferenceId}/${response.data[0].teamId}`);
        setArticlesList(response.data.slice(1));
      } else {
        setMainArticles([]);
        setArticlesList([]);
      }
    })
}