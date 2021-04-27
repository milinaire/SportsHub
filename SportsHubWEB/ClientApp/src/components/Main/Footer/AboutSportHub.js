import React, { Component } from "react";
import "./Footer.css";

export class AboutSportHub extends Component {
  state = {
    Headline: "some headline from db",
    Text: "text from db",
  };
  render() {
    return (
      <div>
        <h1>{this.state.Headline}</h1>
        <p>{this.state.Text}</p>
      </div>
    );
  }
}
