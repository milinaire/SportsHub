import React, {Component, Fragment} from "react";
import "./Footer.css";
import {BaseLayout} from "../Layout/BaseLayout";

export class ContactUs extends Component {
  state = {
    Headline: "some headline from db",
    Address: "address from db",
    Tel: "Tel from db",
    Email: "Email from db",
  };
  render() {
    return (

      <Fragment>
        <BaseLayout>
          <div>
            <h1>{this.state.Headline}</h1>
            <p>{this.state.Address}</p>
            <p>{this.state.Tel}</p>
            <p>{this.state.Email}</p>
          </div>
        </BaseLayout>
      </Fragment>
    );
  }
}
