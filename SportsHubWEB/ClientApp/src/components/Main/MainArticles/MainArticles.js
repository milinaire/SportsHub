import React, {Component, Fragment} from "react";
import "./MainArticles.css";
import {Link} from "react-router-dom";

export class MainArticles extends Component {
  state = {
    index: 0,
    Categories: []
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
    fetch("/category?languageId=1")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({Categories: result, index: 0})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
    this.interval = setInterval(() => {
      this.setState({index: (this.state.index + 1) % this.props.articles.length});
    }, 6000);
    if (!this.state.index && this.state.index !== 0) {
      this.setState({index: 0})
    }
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (!this.state.index && this.state.index !== 0) {
      this.setState({index: 0})
    }
    console.log(this.props.articles,this.state.index)
    if(this.state.index > this.props.articles.length-1 && this.state.index !== 0){
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
    buttons.push(
      <button key={0} onClick={() => this.changeIndex(-1, this.props.articles.length)} className={"arrow-btn"}>
        {"<"}
      </button>
    )
    for (let i = 0; i < this.props.articles.length; i++) {
      if (i === this.state.index) {
        buttons.push(
          <div key={i + 2} className={"act-btn"} onClick={() => this.setIndex(i)}>
            {"0" + (i + 1)}
          </div>
        )
      } else {
        buttons.push(
          <div key={i + 2} className={"btn"} onClick={() => this.setIndex(i)}>
            {"0" + (i + 1)}
          </div>)
      }
    }
    buttons.push(
      <button key={1} className={"arrow-btn"} onClick={() => this.changeIndex(1, this.props.articles.length)}>
        {">"}
      </button>
    )
    return (
      <Fragment>
        {console.log(this.props.articles,this.state.index)}
        {this.props.articles.length > 0 &&
        <div className="main-articles"
             style={{backgroundImage: `url(${this.props.articles[this.state.index].imageUri})`}}
             onMouseEnter={() => this.stopSliding()}
             onMouseLeave={() => this.startSliding()}
        >
          {
            this.props.showCategory ?
              <div className="cat">
                {this.state.Categories && this.state.Categories.find(category => String(category.id) === String(this.props.articles[this.state.index].categoryId)).name}
              </div>
              :
              <div style={{width: "12%"}}/>
          }
          <div className="info">
            <div className="table">
              <div className="text-table">
                <p className="published">Published / {this.props.articles[this.state.index].datePublished}</p>
                <b className="head">{this.props.articles[this.state.index].headline}</b>
                <b className="caption">{this.props.articles[this.state.index].caption}</b>
              </div>
              {this.props.link ?
                <div className="more">
                  <Link to={`/${this.props.link}/${this.props.articles[this.state.index].articleId}`}>
                    <div className="link-more">
                      <b>More</b>
                    </div>
                  </Link>
                </div>
                :
                <div className="link-more">
                  <b>Share</b>
                </div>
              }
            </div>
            <div className="buttons">
              {this.props.articles.length > 1 && buttons}
            </div>
          </div>
        </div>}
      </Fragment>
    );
  }
}
