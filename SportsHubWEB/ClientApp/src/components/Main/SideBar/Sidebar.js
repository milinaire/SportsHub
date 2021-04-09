import React, { Component } from "react";
import "./Sidebar.css";


export class Sidebar extends Component {

  state = {

    Banner: [
      { name: "", show: true, url: "https://image.freepik.com/free-vector/sport-banner-template-with-photo_52683-15808.jpg" },
    ],

    PredefinedBanner: [
      { title: "Facebook Video", HeadLine: "acebookVideo", show: true, url: "https://i0.wp.com/www.respectability.org/wp-content/uploads/2018/02/muhammad-ali-wide.jpg?fit=900%2C506&ssl=1", text: "Люблю Карманського всім серцем своїм" },
      { title: "Dealbook", show: true, url: "https://www.iwf.org/wp-content/uploads/2020/06/shutterstock_106247474.jpg", text: "Люблю Шиманського всім серцем своїм" },
      { title: "Facebook Post", show: true, url: "https://fs01.vseosvita.ua/01009h47-5324/004.jpg", text: "Люблю Наркаманського всім серцем своїм" },
      { title: "Lifestyle", show: true, url: "https://www.cev.eu/NewsImages/25535/Original/182625__AIM1530.JPG", text: "Люблю Циганського всім серцем своїм" },
    ]

  };

  render() {
    return (

      <div className={"right-panel-wrapper"}>

        <div className="sidebar">

          {this.state.Banner.map(banner => (
            <div className="facebook-video">
              <img className="facebook-video-img" src={banner.url} alt="new" />
            </div>))
          }

          {this.state.PredefinedBanner.map(prebanner => (<div className="facebook-video">
            <div className="tittle-wrapper">
              <b>{prebanner.title}</b>
            </div>
            <img className="facebook-video-img" src={prebanner.url} alt="new" />
            <div className="description">
              <p>{prebanner.text}</p>
            </div>
          </div>))
          }
        </div>
      </div>
    );
  }
}
