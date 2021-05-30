import ReactModal from 'react-modal';
import React from "react";
import style from './CustomModal.module.css';
import PropTypes from 'prop-types';
import {withRouter} from "react-router-dom";
//import {RiDeleteBin5Line, IoWarning} from "react-icons/all";

ReactModal.setAppElement(document.getElementById('root'));

const AlertModal = (props) => {

  const closeModal = () => {
    props.closeModal()
  }

  const confirmModal = () => {
    props.closeModal()
    props.confirmModal()
    props.link && props.history.push(props.link)
  }

  return (
    <ReactModal
      isOpen={props.isOpen}
      //onAfterOpen={afterOpenModal}
      onRequestClose={closeModal}
      className={style.AlertModal}
      overlayClassName={style.Overlay}
      contentLabel="Example Modal"
      shouldCloseOnOverlayClick={false}
    >
      <div className={style.AlertTypeCircle}>
        {props.type === 'delete'
          ? '<RiDeleteBin5Line/>'
          : '<IoWarning/>'
        }
      </div>
      <div className={style.AlertContent}>
        {props.children}
      </div>
      <div className={style.Buttons}>
        <button className={style.CloseBTN} onClick={closeModal}>{props.closeBtn}</button>
        <button className={style.ConfirmBTN} onClick={confirmModal}>{props.confirmBtn}</button>
      </div>
    </ReactModal>
  )
}

AlertModal.propTypes = {
  isOpen: PropTypes.bool.isRequired,
  closeModal: PropTypes.func.isRequired,
  confirmModal: PropTypes.func.isRequired,
  link: PropTypes.string,
  closeBtn: PropTypes.string.isRequired,
  confirmBtn: PropTypes.string.isRequired,
  type: PropTypes.string.isRequired,
};
export default withRouter(AlertModal)