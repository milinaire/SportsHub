import React, { Component } from "react";
import "./Footer.css";

export class ContactUs extends Component {
  state = {
    Headline: "some headline from db",
    Address: "address from db",
    Tel: "Tel from db",
    Email: "Email from db",
  };
  render() {
    return (
      <div>
        <h1>{this.state.Headline}</h1>
        <p>{this.state.Address}</p>
        <p>{this.state.Tel}</p>
        <p>{this.state.Email}</p>
      </div>
    );
  }
}
