import React, { Fragment} from "react";
import Switch from "react-switch";
import {FaTrash} from "react-icons/fa";
import "./Languages.css"

const Languages = (props) => {


  return (
    <Fragment>
      <div className="languages-block">
        <div className="language-head">
          <div className="sub-language-head"><p>LANGUAGES</p></div>
          <div className="sub-language-head"><p>STATUS</p></div>
        </div>
        <div className="sub-language-block">
          <div className="sub-sub-language-block"><p>English</p></div>
          <div className="sub-sub-language-block">
            <div className="switch-icon-language-block">
              <label>
                <Switch className="custom-switch"
                        onChange={() => {
                        }}
                        checked={true}
                        height={20} width={40}
                        handleDiameter={15}
                        boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)'
                        uncheckedIcon={false}
                        checkedIcon={false}
                        offColor='#999'
                        onColor='#999'
                        offHandleColor='#f0f0f0'
                        onHandleColor='#f00'/>
              </label>

              <FaTrash/>
            </div>
          </div>
        </div>
        <div className="sub-language-block">
          <div className="sub-sub-language-block"><p>German</p></div>
          <div className="sub-sub-language-block">
            <div className="switch-icon-language-block">
              <label>
                <Switch className="custom-switch"
                        onChange={() => {
                        }}
                        checked={true}
                        height={20} width={40}
                        handleDiameter={15}
                        boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)'
                        uncheckedIcon={false}
                        checkedIcon={false}
                        offColor='#999'
                        onColor='#999'
                        offHandleColor='#f0f0f0'
                        onHandleColor='#f00'/>
              </label>
              <FaTrash/>
            </div>
          </div>
        </div>
        <div className="sub-language-block">
          <div className="sub-sub-language-block"><p>Spanish</p></div>
          <div className="sub-sub-language-block">
            <div className="switch-icon-language-block">
              <label>
                <Switch className="custom-switch"
                        onChange={() => {
                        }}
                        checked={true}
                        height={20} width={40}
                        handleDiameter={15}
                        boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)'
                        uncheckedIcon={false}
                        checkedIcon={false}
                        offColor='#999'
                        onColor='#999'
                        offHandleColor='#f0f0f0'
                        onHandleColor='#f00'/>
              </label>
              <FaTrash/>
            </div>
          </div>
        </div>
        <div className="sub-language-block">
          <div className="sub-sub-language-block"><p>French</p></div>
          <div className="sub-sub-language-block">
            <div className="switch-icon-language-block">
              <label>
                <Switch className="custom-switch"
                        onChange={() => {
                        }}
                        checked={true}
                        height={20} width={40}
                        handleDiameter={15}
                        boxShadow='0 0 8px 0 rgba(0, 0, 0, 0.3)'
                        uncheckedIcon={false}
                        checkedIcon={false}
                        offColor='#999'
                        onColor='#999'
                        offHandleColor='#f0f0f0'
                        onHandleColor='#f00'/>
              </label>
              <FaTrash/>
            </div>
          </div>
        </div>
      </div>
    </Fragment>
  );

}
export default Languages;