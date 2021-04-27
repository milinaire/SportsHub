import React, {Component} from "react";
import "./Sidebar.css";
import "./style.css";

export class Sidebar extends Component {
  state = {
    Banner: [
    ],
    index: 0,
    animated: "animated",
    num:0
  };

  componentDidMount() {
    fetch("https://localhost:5001/banner")
      .then(res => res.json())
      .then(
        (result) => {

          if(this.props.category){
            result = result.filter(ban=> String(ban.categoryId) === String(this.props.category))
            result.push(result[0])
          }else{
            result.push(result[0])
          }
          this.setState({Banner: result})

        },
        (error) => {
          this.setState({
            error
          });
        }
      )


    this.interval = setInterval(() => {
      if (this.state.index === 1) {
        this.setState({animated: ""});
        this.state.Banner.shift()
        this.setState({index: this.state.index - 1});
        this.setState({Banner: [...this.state.Banner, this.state.Banner[0]]});
      } else {
        this.setState({animated: "animated"});

        this.setState({index: this.state.index + 1});
      }
    }, 2500);
  }
componentWillUnmount() {
  clearInterval(this.interval);
}

  render() {
    return (

      <div className="sidebar">
        <div
          className="slideshow"
          style={{maxHeight: `${(this.state.Banner.length - 1) * 450}px`}}
        >
          <div
            className={`slideshowSlider ${this.state.animated}`}
            style={{
              transform: `translate3d(0, -${this.state.index * 450}px, 0)`,
            }}
          >
            {this.state.Banner.map((banner, id) =>

                <div key={id} className="facebook-video slide">

                  {banner.headline ? (
                    <div className="tittle-wrapper">
                      <b>{banner.headline}</b>
                    </div>
                  ) : null}
                  {banner.headline ? (
                    <img
                      className="facebook-video-img"
                      src={banner.imageUri}
                      alt="new"

                    />
                  ) : (
                    <img
                      className="facebook-video-img"
                      src={banner.imageUri}
                      alt="new"
                      style={{height: "320px"}}
                    />
                  )}

                  {banner.headline ? (
                    <div className="description">
                      <p>{banner.headline}</p>
                    </div>
                  ) : null}
                </div>)
            }
          </div>
        </div>
      </div>

    );
  }
}
