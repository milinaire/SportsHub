import React, {Component, Fragment} from "react";
import {Header} from "../Header/Header";
import "./Layout.css";
import {DownFooterPart} from "../Footer/DownFooterPart";

export class Layout extends Component {

  render() {
    return (
      <Fragment>
        <Header/>
        <div className={"all-page"}>
          {this.props.children}
        </div>
        <DownFooterPart/>
      </Fragment>
    );
  }
}
