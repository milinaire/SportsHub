import React, {Component, Fragment} from "react";
import "./Layout.css";
import {NavMenu} from "../NavBar/NavMenu";
import {UpFooterPart} from "../Footer/UpFooterPart";
import {MainArticles} from "../MainArticles/MainArticles";
import {Sidebar} from "../SideBar/Sidebar";

export class PageLayout extends Component {

  render() {
    return (
      <Fragment>
        <NavMenu/>
        <div className="main-part">
          {this.props.MainArticles.length > 0 && <MainArticles articles={this.props.MainArticles}/>}
          <div className="main-content">
            <div className="content">{this.props.children}</div>
            <div className="side">
              <Sidebar category={this.props.Category}/>
            </div>
          </div>
          <UpFooterPart/>
        </div>
      </Fragment>
    );
  }
}
