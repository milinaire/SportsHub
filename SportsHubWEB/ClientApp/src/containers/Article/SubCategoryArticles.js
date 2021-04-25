import React, {Component, Fragment} from 'react';
import Card from "react-bootstrap/Card";
import {Col, Row} from "react-bootstrap";
import {Link} from "react-router-dom";

export class SubCategoryArticles extends Component {
  componentDidMount() {
    this.props.setCategory(this.props.match.params.category)
  }

  getSnapshotBeforeUpdate(prevProps, prevState) {
    return this.props.match.params.category
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.match.params.category !== this.props.match.params.category) {
      this.props.setCategory(this.props.match.params.category)
      console.log("hi", this.props.match.params.category)
    }
  }

  componentWillUnmount() {
    this.props.setCategory('')
  }

  state={
    Articles: [
      {
        Id: 1,
        Alt: "Alt",
        HeadLine: "HeadLine1",
        Caption: "Caption1 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        Category: "NBA",
        Url: "1",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine2",
        Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://markateur.com/wp-content/uploads/2017/04/articles.jpg",
        Category: "UFC",
        Url: "2",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine3",
        Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7pfEljy7X0eBed-8PpZwT3X4tqY_LCZbDLnNGAk3qldHhF3YOnfY_1NYyWzumMYwpuws&usqp=CAU",
        Category: "QTV",
        Url: "3",
      },
      {
        Id: 4,
        Alt: "Alt",
        HeadLine: "HeadLine4",
        Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        Category: "NBA",
        Url: "4",
      },
      {
        Id: 5,
        Alt: "Alt",
        HeadLine: "HeadLine5",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        Category: "ATB",
        Url: "5",
      },
    ],
  }


  render() {
    let list = []
    for (let i = 0; i < this.state.Articles.length; i++) {

      list.push(
        <Link to={`${this.props.match.params.subcategory}/~/${this.state.Articles[i].Url}`}>
          <div className={"article"} style={{display: "flex", margin: "15px"}}>
            <img src={this.state.Articles[i].Image} style={{width: "40%", height: "240px", padding: "10px"}}
                 alt={this.state.Articles[i].Alt}/>
            <div>
              <h2>{this.state.Articles[i].HeadLine}</h2>
              <p>{this.state.Articles[i].Caption}</p>
            </div>
          </div>
        </Link>
      )
      list.push(<hr style={{border: "1px solid #eee", margin: 0}}/>)
    }
    ;
    list.pop()
    return (
      <Fragment>
        <div style={{minHeight: "1000px"}}>
          {this.props.match.params.category}~
          {this.props.match.params.subcategory}
          {list}
        </div>
      </Fragment>

    )
  }
}