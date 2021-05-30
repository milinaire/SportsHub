import React, {Fragment} from "react";
import style from './Users.module.css'
import {withRouter} from "react-router-dom";
import InputModal from "../../../CustomModal/InputModal";
import AlertModal from "../../../CustomModal/AlertModal";

const Users = (props) => {
  const [modalIsOpen, setIsOpen] = React.useState(false);
  const openModal = () => {
    setIsOpen(true);
  }
  const closeModal = () => {
    setIsOpen(false);
  }
  return (
    <Fragment>
      <div>
        <button onClick={openModal}>Open Modal</button>
        <AlertModal isOpen={modalIsOpen}
                    closeModal={closeModal}
                    closeBtn={'Close'}
                    confirmBtn={'Add'}
                    type={'delete'}
                    confirmModal={() => {
                      alert('confirmed')
                    }} link={'/admin/banners'}>
          <div>
            hi
          </div>
        </AlertModal>
      </div>
    </Fragment>
  );

}
export default withRouter(Users);
