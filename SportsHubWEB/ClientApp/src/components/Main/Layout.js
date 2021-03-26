import React, {Component} from 'react';
import {Header} from "./Header";
import './Styles.css';
import {NavMenu} from "./NavMenu";
import {Sidebar} from "./Sidebar";
import {Footer} from "./Footer";

export class Layout extends Component {


    static displayName = Layout.name;

    render() {
        return (
            <div>
                <Header/>
                <div className={"page-wrapper"}>
                    <NavMenu/>
                    <div className="content-wrapper">
                        <div className="content">
                            {this.props.children}
                        </div>
                    </div>
                    <Sidebar/>
                </div>
                <Footer/>
            </div>
        );
    }
}