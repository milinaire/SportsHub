import React, {Component} from 'react';
import PropTypes from 'prop-types';
import s from './InformationArchitecture.module.css'
import LocalizationTab from "./LocalizationTab";

const LocalizationTabs = (props) => {
  return (
    <div className="tabs">
      <ol className={s.TabList}>
        {console.log(props)}
        {props.children.map((child) => {
          console.log(child.props)
          if (child) {
            return (
              <LocalizationTab
                //deleteTab={props.deleteTab}
                activeTab={props.navigationReducer.selectedLocalizationTab}
                key={child.props.languageId}
                languageId={child.props.languageId}
                label={props.languageReducer.languages.find(l => l.id === child.props.languageId).value}
                setSelected={props.setSelectedLocalizationTab}
              />);
          }
        })}
        {props.languageReducer.languages.length > props.navigationReducer.selectedIACategoryLocalization.length
          ? <button onClick={e => {
            e.preventDefault()
            props.setIsCategoryLocalizationModalOpen(true)
          }}>+</button>
          : null
        }
      </ol>
      <div className="tab-content" style={{height: '200px'}}>
        {props.children.map((child) => {
          if (child) {
            console.log(child.props.label, props.navigationReducer.selectedLocalizationTab)
            if (child.props.languageId !== props.navigationReducer.selectedLocalizationTab) return undefined;
            return child.props.children;
          }
        })}
      </div>
    </div>
  );

}
LocalizationTabs.propTypes = {}

export default LocalizationTabs;