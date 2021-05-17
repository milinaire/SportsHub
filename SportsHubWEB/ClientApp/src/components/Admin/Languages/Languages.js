import React, {Fragment} from "react";
import Switch from "react-switch";
import {FaTrash,} from "react-icons/fa";
import {AiFillEdit} from "react-icons/ai";
import "./Languages.css"
import {addNewLanguage} from "../../../redux/languages/languageActionCreator";
import {BiSave} from "react-icons/bi";

const Languages = (props) => {


  return (

    <Fragment>
      <div className="languages-block">
        <div className="language-head">
          <div className="sub-language-head"><p>LANGUAGES</p></div>
          <div className="sub-language-head"><p>STATUS</p></div>
        </div>
        {props.language.languages.map(l =>
          (<div key={l.id} className="sub-language-block">
            <div className="sub-sub-language-block"><p>{l.languageName}</p></div>
            <div className="sub-sub-language-block">
              <div className="switch-icon-language-block">
                <label>

                </label>
                <AiFillEdit onClick={() => props.addChangeLanguage(l.id)}/>
                {l.id!==1?<FaTrash onClick={() => props.deleteLanguage(l.id)}/>:<FaTrash style={{color:'#ccc'}}/>}
              </div>
            </div>
          </div>)
        )}

        {props.language.newLanguage ? <div>
            <div className="new-language">
              <input type="text" value={props.language.newLanguage.languageName} onChange={(e) => {
                props.changeNewLanguage(e.target.value)
              }}/>
              <BiSave onClick={() => {
                if (props.language.newLanguage.languageName) {
                  props.postNewLanguage(props.language.newLanguage)
                } else {
                  alert('Enter name!')
                }

              }
              }/>
              <FaTrash onClick={props.deleteNewLanguage}/>

            </div>
          </div>

          : <button onClick={props.addNewLanguage}>ADD new language</button>}
        {props.language.changingLanguage ? <div>
            <div className="new-language">
              <input type="text" value={props.language.changingLanguage.languageName} onChange={(e) => {
                props.changeLanguage(e.target.value)
              }}/>
              <BiSave onClick={() => {
                if (props.language.changingLanguage.languageName) {
                  props.putLanguage(props.language.changingLanguage)
                } else {
                  alert('Enter name!')
                }

              }
              }/>
              <FaTrash onClick={props.deleteNewLanguage}/>

            </div>
          </div>

          : null}
      </div>

      {console.log(props)}
    </Fragment>
  );

}
export default Languages;

