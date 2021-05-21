import React from "react";
import {transitions, positions, Provider as AlertProvider} from 'react-alert'
import s from './Alert.module.css'
import {CgClose, IoClose, IoIosWarning, TiTick} from "react-icons/all";


const options = {
  position: positions.BOTTOM_RIGHT,
  timeout: 5000,
  offset: '10px',
  transition: transitions.SCALE
}
const AlertTemplate = ({style, options, message, close}) => {
  let type;
  if (options.type === 'info') {
    type = s.Yellow;
  } else if (options.type === 'success') {
    type = s.Green;
  } else if (options.type === 'error') {
    type = s.Red;
  }
  return (
    <div style={style}>
      <div className={s.Alert}>
        <div className={`${s.AlertCircle} ${type}`}>
          {options.type === 'success' && <TiTick/>}
          {options.type === 'info' && <IoIosWarning style={{marginBottom: '5px'}}/>}
          {options.type === 'error' && <CgClose/>}
        </div>
        <div className={s.AlertContent}>
          <div>
            <div className={s.AlertHeaderTxt}>{message.header}</div>
            <div className={s.AlertContentTxt}>{message.content}</div>
          </div>
          <button className={s.AlertCloseBtn} onClick={close}>
            <IoClose/>
          </button>
        </div>
      </div>
    </div>
  )
}

const CustomAlertProvider = (props) => {
  return (
    <AlertProvider template={AlertTemplate} {...options}>
      {props.children}
    </AlertProvider>
  )
}
export default CustomAlertProvider;