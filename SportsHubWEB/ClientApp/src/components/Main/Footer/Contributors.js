import React, { Component } from "react";
import "./Footer.css";

export class Contributors extends Component {
  state = {
    Headline: "some headline from db",
    Text: "text from db",
  };
  componentDidMount(){
    this.props.setLayout('base')
  }
  componentWillUnmount(){
    this.props.setLayout('home')
  }
  render() {
    return (
      <div>
        {this.props.match.params.name}
        <h1>{this.state.Headline}</h1>
        <p>{this.state.Text}</p>
      </div>
    );
  }
}
