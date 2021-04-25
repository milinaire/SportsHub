import React, {Component, Fragment} from "react";
import {Header} from "../Header/Header";
import "./Layout.css";
import {NavMenu} from "../NavBar/NavMenu";
import {Sidebar} from "../SideBar/Sidebar";
import {DownFooterPart} from "../Footer/DownFooterPart";
import {UpFooterPart} from "../Footer/UpFooterPart";
import {MainArticles} from "../MainArticles/MainArticles";

export class HomeLayout extends Component {
  static displayName = HomeLayout.name;

  render() {
    return (
      <Fragment>
        <Header/>
        <div className={"all-page"}>
          {this.props.layout === 'home' ? <NavMenu/> : null}
          <div className="main-part">
            <MainArticles articles={this.props.articles}/>
            <div className="main-content">


              <div className={"content"}>{this.props.children}</div>
              {this.props.layout === 'home' ? <Sidebar category={this.props.category}/> : null}
            </div>
            <UpFooterPart/>
          </div>

        </div>
        <DownFooterPart/>
      </Fragment>
    );
  }
}
