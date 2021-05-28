import axios from "axios";

export const getBanners = (url, language, setBanners) => {
  axios.get(`/banner?${url}languageId=${language}`)
    .then(response => {
      setBanners(response.data)
    })
    .catch(err => {
      if (err.response.status === 404) {
        setBanners([]);
      }
    });
}