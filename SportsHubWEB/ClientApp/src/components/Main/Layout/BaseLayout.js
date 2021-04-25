import React, {Component, Fragment} from "react";
import {Header} from "../Header/Header";
import "./Layout.css";
import {NavMenu} from "../NavBar/NavMenu";
import {Sidebar} from "../SideBar/Sidebar";
import {DownFooterPart} from "../Footer/DownFooterPart";
import {UpFooterPart} from "../Footer/UpFooterPart";
import {MainArticles} from "../MainArticles/MainArticles";

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
            <UpFooterPart />
          </div>

        </div>
        <DownFooterPart/>
      </Fragment>
    );
  }
}