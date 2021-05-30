import React, {Component} from 'react';
import PropTypes from 'prop-types';
import s from './InformationArchitecture.module.css'

const LocalizationTab = (props) => {
  return (
    <li
      className={props.activeTab === props.languageId ? `${s.TabListItem} ${s.TabListActive}` : s.TabListItem}
      onClick={() => props.setSelected(props.languageId)}>
      {props.label}
    </li>
  );
}

export default LocalizationTab;