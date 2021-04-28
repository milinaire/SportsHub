import React, {Component, Fragment} from "react";
import "./MainArticles.css";
import {Link} from "react-router-dom";

export class MainArticles extends Component {
  state = {
    index: 0,
  }

  stopSliding() {
    clearInterval(this.interval)
  }

  startSliding() {
    clearInterval(this.interval)
    this.interval = setInterval(() => {
      this.setState({index: (this.state.index + 1) % this.props.articles.length});
    }, 6000);
  }

  componentDidMount() {
    this.setState({index: 0})
    this.interval = setInterval(() => {
      this.setState({index: (this.state.index + 1) % this.props.articles.length});
    }, 6000);
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (!this.state.index && this.state.index !== 0) {
      this.setState({index: 0})
    }

  }

  componentWillUnmount() {
    clearInterval(this.interval)
  }

  constructor(props) {
    super(props);
    this.state = {index: 0}
  }

  setIndex = index => {
    this.setState({index: index})
    clearInterval(this.interval)
    this.interval = setInterval(() => {
      this.setState({index: (this.state.index + 1) % this.props.articles.length});
    }, 6000);
  }
  changeIndex = (index, length) => {
    if (this.state.index + index > length - 1) {
      this.setState({index: 0})
    } else if (
      this.state.index + index < 0) {
      this.setState({index: length - 1})
    } else {
      this.setState({index: this.state.index + index})
    }
    clearInterval(this.interval)
    this.interval = setInterval(() => {
      this.setState({index: (this.state.index + 1) % this.props.articles.length});
    }, 6000);
  }

  render() {
    let buttons = []

    buttons.push(<button key={0}
                         onClick={() => this.changeIndex(-1, this.props.articles.length)} className={"arrow-btn"}>
      {"<"}
    </button>)
    for (let i = 0; i < this.props.articles.length; i++) {
      if (i === this.state.index) {
        buttons.push(<div key={i + 2}
                             className={"act-btn"}
                             onClick={() => this.setIndex(i)}>
          {"0" + (i + 1)}
        </div>)
      } else {
        buttons.push(<div key={i + 2}
                             className={"btn"}
                             onClick={() => this.setIndex(i)}>
          {"0" + (i + 1)}
        </div>)
      }

    }
    buttons.push(<button key={1}
                         className={"arrow-btn"}
                         onClick={() => this.changeIndex(1, this.props.articles.length)}>
      {">"}
    </button>)
    return (
      <Fragment>
        <div className="main-articles"
             style={{backgroundImage: `url(${this.props.articles[this.state.index].imageUri})`}}
             onMouseEnter={() => this.stopSliding()}
             onMouseLeave={() => this.startSliding()}>
          <div className="cat">

            {this.props.articles[this.state.index].categoryId}
          </div>
          <div className="info">
            <div className="table">
              <div className="text-table">
                <p className="published">Published / {this.props.articles[this.state.index].datePublished}</p>
                <b className="head">{this.props.articles[this.state.index].headline}</b>
                <b className="caption">{this.props.articles[this.state.index].caption}</b>
              </div>

              <div className="more">
                <Link to={`/art/${this.props.articles[this.state.index].articleId}`}>
                  <div className="link-more">
                    <b>More</b>
                  </div>
                </Link>
              </div>
            </div>
            <div className="buttons">
              {buttons}
            </div>
          </div>
        </div>
      </Fragment>
    );
  }


}
