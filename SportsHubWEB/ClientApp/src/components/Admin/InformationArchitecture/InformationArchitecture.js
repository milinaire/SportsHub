import React, {Fragment} from "react";
import s from './InformationArchitecture.module.css'
import Select from "react-select";
import InputModal from "../../CustomModal/InputModal";
import {withAlert} from "react-alert";


const InformationArchitecture = (props) => {
  return (
    <Fragment>
      <InputModal
        isOpen={props.navigationReducer.isCategoryModalOpen}
        closeModal={() => {
          props.setIsCategoryModalOpen(false);
        }}
        closeBtn={'Cancel'}
        confirmBtn={'Add'}
        confirmModal={() => {
          if (props.navigationReducer.newCategoryName) {
            props.addCategory({
              languageId: props.languageReducer.languages.find(l => l.value === 'en').id,
              name: props.navigationReducer.newCategoryName
            })
          } else {
            props.alert.show({
              header: 'Error!',
              content: 'Please enter category name!'
            }, {type: 'error'})
          }
        }}>
          <div className={s.ModalWrapper}>
          <h2>Add new category</h2>
          <div>
          <input type="text" value={props.navigationReducer.newCategoryName}
          onChange={e => props.setNewCategoryName(e.target.value)}/>
          </div>
          </div>
          </InputModal>
          <div className={s.InformationArchitectureWrapper}>
          <div className={s.CategoriesWrapper}>
          <button className={s.Category} onClick={() => props.setIsCategoryModalOpen(true)}>
          + Add Category
          </button>
        {props.navigationReducer.categories.map(category => (
          <div className={s.Category} key={category.id}>
        {category.name}
          </div>
          ))}
          </div>
          <div></div>
          <div></div>
          <div className={s.Redactor}>

          </div>
        {/*<div>*/}
        {/*  {props.navigationReducer.conferences.map(conference=>(*/}
        {/*    <div>*/}

        {/*    </div>*/}
        {/*  ))}*/}
        {/*</div>*/}
        {/*<div>*/}
        {/*  {props.navigationReducer.teams.map(team=>(*/}
        {/*    <div>*/}

        {/*    </div>*/}
        {/*  ))}*/}
        {/*</div>*/}

          </div>
          </Fragment>
          );

        }
export default withAlert()(InformationArchitecture);
