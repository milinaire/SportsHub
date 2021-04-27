import React, {Component, Fragment} from "react";
import "./Layout.css";
import {UpFooterPart} from "../Footer/UpFooterPart";
export class BaseLayout extends Component {

  render() {
    return (
      <Fragment>
        <div className="main-part">
          <div className="main-content">
            <div className="content">{this.props.children}</div>
          </div>
          <UpFooterPart/>
        </div>
      </Fragment>
    );
  }
}
