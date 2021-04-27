import React, {Component, Fragment} from "react";
import {Header} from "../Header/Header";
import "./Layout.css";
import {NavMenu} from "../NavBar/NavMenu";
import {DownFooterPart} from "../Footer/DownFooterPart";
import {UpFooterPart} from "../Footer/UpFooterPart";

export class Layout extends Component {

  render() {
    return (
      <Fragment>
        <Header/>
        <div className={"all-page"}>
          <NavMenu/>
          <div className="main-part">
            <div className="main-content">
              <div>{this.props.children}</div>
            </div>
            <UpFooterPart/>
          </div>
        </div>
        <DownFooterPart/>
      </Fragment>
    );
  }
}
