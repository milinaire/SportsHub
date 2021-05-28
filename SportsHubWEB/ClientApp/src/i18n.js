import i18next from "i18next";
import HttpBackend from "i18next-http-backend";
import LanguageDetector from "i18next-browser-languagedetector";
import {initReactI18next} from "react-i18next";
import {supportedLngs} from "./supportedLngs";
import {languageAPI} from "./api/languageAPI";

const apiKey = "PH5JvF2LhdKvH5RKbCFjWQ";
const loadPath = `https://api.i18nexus.com/project_resources/translations/{{lng}}/{{ns}}.json?api_key=${apiKey}`;

i18next
  .use(HttpBackend)
  .use(LanguageDetector)
  .use(initReactI18next)
  .init({
    fallbackLng: localStorage.i18nextLng || 'en',
    debug: true,
    detection: {
      order: ["cookie"],
      cache: ["cookie"]
    },
    ns: ["default"],
    defaultNS: "default",
    interpolation: {
      escapeValue: false
    },
    supportedLngs: supportedLngs.map(language => language.value),
    backend: {
      loadPath: loadPath
    }
  })
