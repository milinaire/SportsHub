import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import './Styles.css';

export class NavMenu extends Component {
    state = {
        Categories: [
            {
                title: "Category1"
            },
            {
                title: "Category2"
            },
            {
                title: "Category3"
            },
            {
                title: "Category1"
            },
            {
                title: "Category1"
            },
            {
                title: "Category2"
            },
            {
                title: "Category3"
            },
            {
                title: "Category1"
            },
            {
                title: "Category2"
            },
            {
                title: "Category2"
            },
            {
                title: "Category3"
            }
        ],
        follow: [
            {
                title: "Category1"
            },
            {
                title: "Category2"
            },
            {
                title: "Category3"
            },
            {
                title: "Category1"
            },

        ]
    }

    render() {
        return (

            <div className={"left-panel-wrapper"}>
                <div className="menu">
                    <div className={"categories"}>
                        <h3>Home</h3>
                        {this.state.Categories.map(Category => (
                            <h3>{Category.title}</h3>
                        ))}
                        <h3>TEAM HUB</h3>
                        <h3>LIFESTYLE</h3>
                        <h3>DEALBOOK</h3>
                        <h3>VIDEO</h3>
                    </div>
                </div>
            </div>

        );
    }
}
