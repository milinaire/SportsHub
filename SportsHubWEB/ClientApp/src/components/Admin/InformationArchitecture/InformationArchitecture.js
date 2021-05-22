import React, {Fragment} from "react";
import s from './InformationArchitecture.module.css'
import Select from "react-select";
import InputModal from "../../CustomModal/InputModal";
import {withAlert} from "react-alert";
import LocalizationTabs from "./LocalizationTabs";
import {useTranslation} from "react-i18next";


const InformationArchitecture = (props) => {
  const {t} = useTranslation();
  return (
    <Fragment>
      {<><InputModal
        isOpen={props.navigationReducer.isCategoryModalOpen}
        closeModal={() => {
          props.setIsCategoryModalOpen(false);
          props.setNewCategoryName('')
        }}
        closeBtn={t("Cancel")}
        confirmBtn={t("Add")}
        confirmModal={() => {
          if (props.navigationReducer.newCategoryName) {
            props.addCategory({
              languageId: props.languageReducer.languages.find(l => l.value === 'en').id,
              name: props.navigationReducer.newCategoryName,
              alert: () => props.alert.show({
                header: t("Success"),
                content: `${props.navigationReducer.newCategoryName} ${t("Admin/IA/WasSuccessfullyAdded")}`
              }, {type: 'success'})
            })
          } else {
            props.alert.show({
              header: t("Error"),
              content: t("Admin/IA/PleaseEnterCategoryName")
            }, {type: 'error'})
          }
        }}>
        <div className={s.ModalWrapper}>
          <h2>{t("Admin/IA/AddNewCategory")}</h2>
          <div className={s.ModalInfo}>
            <p>{t("Admin/IA/EnterCategoryName")}</p>
            <input type="text" value={props.navigationReducer.newCategoryName} className={s.Input}
                   onChange={e => props.setNewCategoryName(e.target.value)}/>
            <p>{t("Admin/IA/YouWillBeAble")}</p>
          </div>
        </div>
      </InputModal>
        <InputModal
          isOpen={props.navigationReducer.isCategoryLocalizationModalOpen}
          closeModal={() => {
            props.setIsCategoryLocalizationModalOpen(false);
            props.changeNewCategoryLocalizationName('')
          }}
          closeBtn={t("Cancel")}
          confirmBtn={t("Add")}
          confirmModal={() => props.postSelectedIACategoryLocalization({
              categoryId: props.navigationReducer.selectedIACategory,
              languageId: props.navigationReducer.newCategoryLocalizationLanguage.id,
              name: props.navigationReducer.newCategoryLocalizationName,
              alert: ()=>props.alert.show({
                header: t("Success"),
                content: t("Admin/IA/CategoryLocalizationWasSuccessfullyAdded")
              }, {type: 'success'}),
              currentLanguage: props.languageReducer.currentLanguage.id
            }
          )}>
          <div className={s.ModalWrapper}>
            <h2>{t("Add new localization")}</h2>
            <div className={s.ModalInfo}>
              <Select
                styles={{width: '100%'}}
                single
                options={props.languageReducer.languages.filter(lang =>
                  !props.navigationReducer.selectedIACategoryLocalization.find(l => l.languageId === lang.id))}
                onChange={({value}) => {
                  props.changeNewCategoryLocalizationLanguage(props.languageReducer.languages.find(l => l.value === value));
                }}

              />
              <p>{t("Enter category name")}</p>
              <input type="text" value={props.navigationReducer.newCategoryLocalizationName} className={s.Input}
                     onChange={e => props.changeNewCategoryLocalizationName(e.target.value)}/>
            </div>
          </div>
        </InputModal>
        <div className={s.InformationArchitectureWrapper}>
          <div className={s.CategoriesWrapper}>
            <button className={s.SimpleCategory} onClick={() => props.setIsCategoryModalOpen(true)}>
              {t("Admin/IA/+AddCategory")}
            </button>
            {props.navigationReducer.categories.map(category => (
              <div key={category.id} onClick={() => props.setSelectedIACategory({
                categoryId: category.id,
                enId: props.languageReducer.languages.find(l => l.value === 'en').id
              })}>
                {category.id === props.navigationReducer.selectedIACategory
                  ? <div className={s.ActiveCategory}><p>{category.name}</p></div>
                  : <div className={s.SimpleCategory}><p>{category.name}</p></div>
                }
              </div>
            ))}
          </div>
          <div className={s.CategoriesWrapper}>

          </div>
          <div className={s.CategoriesWrapper}>

          </div>
          {props.navigationReducer.isDeleting
            ? t("Loading")
            : props.navigationReducer.selectedIACategory && <div className={s.Redactor}>
            <h2>{props.navigationReducer.selectedIACategory && props.navigationReducer.categories.find(c =>
              c.id === props.navigationReducer.selectedIACategory).name}</h2>
            <button onClick={() => props.deleteCategory({
              categoryId: props.navigationReducer.selectedIACategory,
              alert: ()=>props.alert.show({
                header: t("Success"),
                content: t("Category was successfully deleted")
              }, {type: 'success'}),
              currentLanguage: props.languageReducer.currentLanguage.id
            })}>{t("Delete")}
            </button>
            <div>
              <LocalizationTabs {...props}>
                {props.navigationReducer.selectedIACategoryLocalization.map(localization => (
                    <div {...localization} key={localization.categoryId}>
                      <input type="text" value={localization.name} className={s.Input}
                             onChange={e => props.changeSelectedIACategoryName({
                               languageId: localization.languageId,
                               name: e.target.value
                             })}/>

                      <button
                        onClick={() => props.deleteSelectedIACategoryLocalization({
                          ...localization,
                          alert: ()=>props.alert.show({
                            header: t("Success"),
                            content: t("Category localization was successfully deleted")
                          }, {type: 'success'}),
                          currentLanguage: props.languageReducer.currentLanguage.id
                        })}
                        disabled={props.languageReducer.languages.find(l => l.id === localization.languageId).value === 'en'}>
                        {t("Delete")}
                      </button>
                      <button onClick={() => props.saveSelectedIACategoryName({
                        ...localization,
                        alert: ()=>props.alert.show({
                          header: t("Success"),
                          content: t("Category name was successfully updated")
                        }, {type: 'success'}),
                        currentLanguage: props.languageReducer.currentLanguage.id
                      })}>{t("Save")}
                      </button>
                    </div>
                  )
                )}
              </LocalizationTabs>
            </div>
          </div>}
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
      </>}
    </Fragment>
  );

}
export default withAlert()(InformationArchitecture);
