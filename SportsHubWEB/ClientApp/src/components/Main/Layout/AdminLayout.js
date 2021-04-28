import React, {Component, Fragment} from "react";
import {AdminHeader} from  "../AdminHeader/AdminHeader";

import "./AdminLayout.css";

export class AdminLayout extends Component {

  render() {
    return (
      <Fragment>
      <AdminHeader/>
      <div className="wrap-shit">
        {this.props.children}
      </div>
      </Fragment>
    );
  }
}
