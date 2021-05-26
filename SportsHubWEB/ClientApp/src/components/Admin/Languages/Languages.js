import React, {Fragment} from "react";
//import {FaTrash,} from "react-icons/fa";
//import {AiFillEdit} from "react-icons/ai";
import "./Languages.css"
import s from './Languages.module.css'
//import {BiSave} from "react-icons/bi";
import InputModal from "../../../CustomModal/InputModal";
import Select from "react-select";
import {withAlert} from "react-alert";
import {useTranslation} from "react-i18next";


const Languages = (props) => {
  const {t} = useTranslation();
  const onChange = (value, {action, removedValue}) => {
    props.setNewLanguages(value)
    switch (action) {
      case 'remove-value':
        break;
      case 'pop-value':
        break;
      case 'clear':
        break;
    }
  }
  return (

    <Fragment>
      <InputModal
        isOpen={props.languageReducer.isModalOpen}
        closeModal={() => {
          props.setNewLanguages(null);
          props.setIsModalOpen(false);
        }}
        closeBtn={'Cancel'}
        confirmBtn={'Add'}
        type={'delete'}
        confirmModal={() => {
          if (props.languageReducer.newLanguages) {
            props.addLanguages({
              languages: props.languageReducer.newLanguages,
              alert: props.alert
            })
          }
        }}>
        <div className={s.ModalWrapper}>
          <h2>Add language</h2>
          <div className={s.ModalSelect}>
            <Select
              isMulti
              className="basic-multi-select"
              classNamePrefix="select"
              defaultValue={[]}
              name="languages"
              options={props.languageReducer.supportedLngs.filter(language =>
                !(props.languageReducer.languages.find(l => l.value === language.value)))}
              onChange={onChange}
            />
          </div>
        </div>
      </InputModal>
      <div className="languages-block">
        <div className="language-head">
          <div className="sub-language-head"><p>{t("Admin/Languages/LanguagesCategoryTranslation").toUpperCase()}</p></div>
        </div>
        {props.languageReducer.languages.map(l =>
          (<div key={l.id} className="sub-language-block">
            <div className="sub-sub-language-block"><p>{l.label}</p></div>
            <div className="sub-sub-language-block">
              <div className="switch-icon-language-block">
                {/*<AiFillEdit onClick={() => {*/}
                {/*  //props.addChangeLanguage(l.id)*/}
                {/*}}/>*/}
                {l.value !== 'en' ? <div onClick={() => props.deleteLanguage({
                    language: l,
                    alert: props.alert
                  })}
                  >Delete</div> :
                  <div style={{color: '#ccc'}}>Delete</div>}
              </div>
            </div>
          </div>)
        )}
      </div>

      {/*  {props.language.newLanguage ? <div>*/}
      {/*      <div className="new-language">*/}
      {/*        <input type="text" value={props.language.newLanguage.languageName} onChange={(e) => {*/}
      {/*          props.changeNewLanguage(e.target.value)*/}
      {/*        }}/>*/}
      {/*        <BiSave onClick={() => {*/}
      {/*          if (props.language.newLanguage.languageName) {*/}
      {/*            props.postNewLanguage(props.language.newLanguage)*/}
      {/*          } else {*/}
      {/*            alert('Enter name!')*/}
      {/*          }*/}

      {/*        }*/}
      {/*        }/>*/}
      {/*        <FaTrash onClick={props.deleteNewLanguage}/>*/}

      {/*      </div>*/}
      {/*    </div>*/}

      {/*    : <button onClick={props.addNewLanguage}>ADD new language</button>}*/}
      {/*  {props.language.changingLanguage ? <div>*/}
      {/*      <div className="new-language">*/}
      {/*        <input type="text" value={props.language.changingLanguage.languageName} onChange={(e) => {*/}
      {/*          props.changeLanguage(e.target.value)*/}
      {/*        }}/>*/}
      {/*        <BiSave onClick={() => {*/}
      {/*          if (props.language.changingLanguage.languageName) {*/}
      {/*            props.putLanguage(props.language.changingLanguage)*/}
      {/*          } else {*/}
      {/*            alert('Enter name!')*/}
      {/*          }*/}

      {/*        }*/}
      {/*        }/>*/}
      {/*        <FaTrash onClick={props.deleteNewLanguage}/>*/}

      {/*      </div>*/}
      {/*    </div>*/}

      {/*    : null}*/}
      {/*</div>*/}
    </Fragment>
  );

}
export default withAlert()(Languages);

