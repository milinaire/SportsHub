import React, {Component, Fragment} from "react";
import {AdminHeader} from  "../AdminHeader/AdminHeader";
import "./Layout.css";
import "./AdminLayout.css";

export class AdminLayout extends Component {

  render() {
    return (
      <Fragment>
      <AdminHeader/>
        <div className="main-part">
          <div className="main-content">
            <div className="content">{this.props.children}</div>
          </div>
        </div>
    
      </Fragment>
    );
  }
}
