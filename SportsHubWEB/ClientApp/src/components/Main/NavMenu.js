import React, {Component} from 'react';
import './Styles.css';

export class NavMenu extends Component {
    state = {
        Categories: [
            {title: "NBA", key:1},
            {title: "NFL", key:2},
            {title: "FDS", key:3},
            {title: "JSX", key:4},
            {title: "FWT", key:5},
            {title: "BER", key:6},
            {title: "BQW", key:7},
            {title: "HWU", key:8},
            {title: "BDR", key:9},
            {title: "QNR", key:10},
            {title: "ASU", key:11},
        ],
        follow: [
            {show: true},
            {show: true},
            {show: true},
            {show: true},
        ]
    }

    render() {
        return (

            <div className={"left-panel-wrapper"}>
                <div className="scrollbar" id="style-1">
                    <div className={"categories"}>
                        <ul>
                            <div className={"category"}>
                                <a href={"/"}>
                                    <li>HOME</li>
                                </a>
                            </div>
                            {this.state.Categories.map((Category)=> (
                                <div key={Category.key} className={"category"}><a href={"/"}>
                                    <li>{Category.title}</li>
                                </a></div>
                            ))}
                            <div className={"category"}><a href={"/"}>
                                <li>TEAM HUB</li>
                            </a></div>
                            <div className={"category"}><a href={"/"}>
                                <li>LIFESTYLE</li>
                            </a></div>
                            <div className={"category"}><a href={"/"}>
                                <li>DEALBOOK</li>
                            </a></div>
                            <div className={"category"}><a href={"/"}>
                                <li>VIDEO</li>
                            </a></div>
                        </ul>
                    </div>
                </div>
                <div className={"follow"}>
                    <p>Follow</p>
                    <br/>
                    <button type="submit"><i className="fa fa-facebook-f "/></button>
                    <button type="submit"><i className="fa fa-twitter "/></button>
                    <br/>
                    <button type="submit"><i className="fa fa-google"/></button>
                    <button type="submit"><i className="fa fa-youtube-play "/></button>
                </div>
            </div>

        );
    }
}
