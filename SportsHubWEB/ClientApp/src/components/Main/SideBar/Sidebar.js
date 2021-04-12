import React, { Component } from "react";
import "./Sidebar.css";
import "./style.css";

export class Sidebar extends Component {
  state = {
    Banner: [
      // {
      //   title: "",
      //   show: true,
      //   url: "https://image.freepik.com/free-vector/sport-banner-template-with-photo_52683-15808.jpg",
      //   Category: "NBA",
      // },
      {
        title: "",
        show: true,
        url: "https://www.imgacademy.com/sites/default/files/styles/scale_1700w/public/2020-04/OG-soccer-school.jpg?itok=4IMSHCVp",
        Category: "KPD",
      },
      {
        title: "",
        show: true,
        url:
          "https://news.store.rambler.ru/img/56d9b68b9ffc92b7cfa482e3ca13b645?img-1-resize=width%3A430%2Cheight%3A320%2Cfit%3Acover&img-format=png%3Acomp%3A3",
        Category: "",
        text: "Люблю Карманського всім серцем своїм",
      },
      {
        title: "Facebook Video",
        HeadLine: "FacebookVideo",
        show: true,
        url:
          "https://i0.wp.com/www.respectability.org/wp-content/uploads/2018/02/muhammad-ali-wide.jpg?fit=900%2C506&ssl=1",
        text: "Люблю Карманського всім серцем своїм",
        Category: "predefined",
      },
      {
        title: "Dealbook",
        show: true,
        url:
          "https://www.iwf.org/wp-content/uploads/2020/06/shutterstock_106247474.jpg",
        text: "Люблю Шиманського всім серцем своїм",
        Category: "predefined",
      },
      {
        title: "Facebook Post",
        show: true,
        url: "https://fs01.vseosvita.ua/01009h47-5324/004.jpg",
        text: "Люблю Наркаманського всім серцем своїм",
        Category: "predefined",
      },
      {
        title: "Lifestyle",
        show: true,
        url: "https://www.cev.eu/NewsImages/25535/Original/182625__AIM1530.JPG",
        text: "Люблю Циганського всім серцем своїм",
        Category: "predefined",
      },
    ],
    index: 0,
    animated: "animated",
  };

  componentDidMount() {
    setInterval(() => {
      if (this.state.index === 1) {
        this.setState({ animated: "" });
        const temp = this.state.Banner.shift();
        this.setState({ index: this.state.index - 1 });
        this.setState({ Banner: [...this.state.Banner, temp] });
      } else {
        this.setState({ animated: "animated" });
        console.log(this.state.index);
        this.setState({ index: this.state.index + 1 });
      }
    }, 2500);
  }
  render() {
    return (
      <div className={"right-panel-wrapper"}>
        <div className="sidebar">
          <div
            className="slideshow"
            style={{ maxHeight: `${(this.state.Banner.length - 1) * 450}px` }}
          >
            <div
              className={`slideshowSlider ${this.state.animated}`}
              style={{
                transform: `translate3d(0, -${this.state.index * 450}px, 0)`,
              }}
            >
              {console.log(this.props.category)}
              {this.state.Banner.map((prebanner) => (
                
                (prebanner.Category === this.props.category || prebanner.Category === 'predefined'?
                (<div className="facebook-video slide">
                {prebanner.title ? (
                  <div className="tittle-wrapper">
                    <b>{prebanner.title}</b>
                  </div>
                ) : null}
                {prebanner.text ? (
                  <img
                    className="facebook-video-img"
                    src={prebanner.url}
                    alt="new"
                    
                  />
                ) : (
                  <img
                    className="facebook-video-img"
                    src={prebanner.url}
                    alt="new"
                    style={{ height: "320px" }}
                  />
                )}

                {prebanner.text ? (
                  <div className="description">
                    <p>{prebanner.text}</p>
                  </div>
                ) : null}
              </div>):null)
              ))}
            </div>
          </div>
        </div>
      </div>
    );
  }
}
