import React, {Component} from 'react';
import {Container} from 'reactstrap';
import {Header} from './Header';
import {Footer} from "./Footer";
import {Navbar} from "./NavMenu";
import {Sidebar} from "./Sidebar";
import './Styles.css';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <Header/>
                <div className={"page-wrapper"}>
                    <Navbar/>
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
