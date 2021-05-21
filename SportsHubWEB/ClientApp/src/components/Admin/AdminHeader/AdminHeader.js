import React from "react";
import "./AdminHeader.css";
import {NavLink, withRouter} from "react-router-dom";
import Header from "../../User/Header/Header";


const AdminHeader = (props) => {
  return (
    <div className="head-wrap">
      <Header languageReducer={props.languageReducer} setCurrentLanguage={props.setCurrentLanguage}/>
      <div className="head-title">
        <div className="hdt">
          <b style={{fontSize: "200%"}}>{props.navigationReducer.selectedAdminCategory}</b>
        </div>
        <div className="head-func">
          {props.navigationReducer.currentButtonPanel}
        </div>
      </div>
      <div style={{display: 'flex', justifyContent: 'space-around', alignItems: 'center', height: '60px'}}>
        <span/>
        {props.navigationReducer.categories.map(c => (
          <span key={c.id}>
            <NavLink
              activeStyle={{textDecoration: "none", color: '#F44'}}
              style={{textDecoration: "none", color: '#666'}}
              to={`/admin/${c.id}`}>{c.name}
            </NavLink>
          </span>
        ))}
        <span/>
      </div>
    </div>
  );
}
export default withRouter(AdminHeader)