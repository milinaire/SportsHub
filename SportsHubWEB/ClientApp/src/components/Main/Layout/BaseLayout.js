import React, {Component, Fragment} from "react";
import {Header} from "../Header/Header";
import "./Layout.css";
import {DownFooterPart} from "../Footer/DownFooterPart";
import {UpFooterPart} from "../Footer/UpFooterPart";


export class BaseLayout extends Component {
  static displayName = BaseLayout.name;

  render() {
    return (
      <Fragment>
        <Header/>
        <div className={"all-page"}>
          <div className="main-part">
            <div className="main-content">
              <div className={"content"}>{this.props.children}</div>
            </div>
            <UpFooterPart/>
          </div>
        </div>
        <DownFooterPart/>
      </Fragment>
    );
  }
}