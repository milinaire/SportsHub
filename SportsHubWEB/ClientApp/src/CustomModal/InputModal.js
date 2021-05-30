import ReactModal from 'react-modal';
import React from "react";
import style from './CustomModal.module.css';
import PropTypes from 'prop-types';

import {withRouter} from "react-router-dom";

ReactModal.setAppElement(document.getElementById('root'));

const InputModal = (props) => {

  const closeModal = () => {
    props.closeModal()
  }

  const confirmModal = () => {
    props.confirmModal()
    props.closeModal()
    props.link && props.history.push(props.link)
  }

  return (
    <ReactModal
      isOpen={props.isOpen}
      onRequestClose={closeModal}
      className={style.InputModal}
      overlayClassName={style.Overlay}
      contentLabel="Example Modal"
      shouldCloseOnOverlayClick={false}
    >
      <div className={style.InputContent}>
        {props.children}
      </div>
      <div className={style.Buttons}>
        <button className={style.CloseBTN} onClick={closeModal}>{props.closeBtn}</button>
        <button className={style.ConfirmBTN} onClick={confirmModal}>{props.confirmBtn}</button>
      </div>
    </ReactModal>
  )
}

InputModal.propTypes = {
  isOpen: PropTypes.bool.isRequired,
  closeModal: PropTypes.func.isRequired,
  confirmModal: PropTypes.func.isRequired,
  link: PropTypes.string,
  closeBtn: PropTypes.string.isRequired,
  confirmBtn: PropTypes.string.isRequired,
};
export default withRouter(InputModal)