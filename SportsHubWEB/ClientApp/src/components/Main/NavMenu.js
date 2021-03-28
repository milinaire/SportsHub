import React, {Component} from "react";
import "./NavMenu.css";
import {Category} from "./NavMenuCategory";
import {NavLink} from "react-router-dom";

export class NavMenu extends Component {
    state = {
        isOpenSubcategory: false,
        Categories: [
            {
                title: "NBA",
                key: 1,
                show: true,
                url: "/NBA",
                subCategories: [
                    {title: "1s", url:"1", teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"2",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"3",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"4",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                ],
            },
            {
                title: "NBA",
                key: 2,
                show: true,
                url: "/article",
                subCategories: [
                    {title: "1s", url:"1", teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"2",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"3",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"4",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                ],
            },
            {
                title: "NBA",
                key: 3,
                show: true,
                url: "/category",
                subCategories: [
                    {title: "1s", url:"1", teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"2",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"3",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                    {title: "1s", url:"4",teams:[{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},{title:"team",url:"1"},]},
                ],
            },
        ],
        follow: [{show: true}, {show: true}, {show: true}, {show: true}],
    };

    render() {
        return (
            <div className={"left-panel-wrapper"}>
                <div className="scrollbar" id="style-1">
                    <ul className="categories">
                        <NavLink
                            className="not-active"
                            exact
                            to={""}
                            activeClassName={"active"}
                        >
                            <li className="category">HOME</li>
                        </NavLink>
                        {this.state.Categories.map((category) => (
                            <Category
                                title={category.title}
                                show={category.show}
                                url={category.url}

                                subcategories={category.subCategories}
                            />
                        ))}
                    </ul>
                </div>
                <div className="follow">
                    <p>Follow</p>
                    <button type="submit">
                        <i className="fa fa-facebook-f "/>
                    </button>
                    <button type="submit">
                        <i className="fa fa-twitter "/>
                    </button>
                    <br/>
                    <button type="submit">
                        <i className="fa fa-google"/>
                    </button>
                    <button type="submit">
                        <i className="fa fa-youtube-play "/>
                    </button>
                </div>
            </div>
        );
    }
}
