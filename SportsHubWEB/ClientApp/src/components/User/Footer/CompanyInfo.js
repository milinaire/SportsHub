import React, {Component, Fragment} from "react";
import "./Footer.css";

export class CompanyInfo extends Component {
  state = {
    Headline: "Ssome headline from db",
    Text: "text from db",
  };

  render() {
    return (
      <Fragment>
        <div className="main-part-footer">
          <h1>{this.state.Headline}</h1>
          <p>{this.state.Text}</p>
        </div>
      </Fragment>
    );
  }
}
