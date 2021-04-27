import React, { Component, Fragment } from "react";
import "./Footer.css";
import {BaseLayout} from "../Layout/BaseLayout";

export class AboutSportHub extends Component {
  state = {
    Headline: "some headline from db",
    Text: "text from db",
  };
  render() {
    return (
      <Fragment>
        <BaseLayout>
          <div>
            <h1>{this.state.Headline}</h1>
            <p>{this.state.Text}</p>
          </div>
        </BaseLayout>
      </Fragment>

    );
  }
}
