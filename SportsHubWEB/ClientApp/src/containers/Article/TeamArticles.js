import React, { Component, Fragment } from "react";

export class TeamArticles extends Component {
  render() {
    return (
      <Fragment>
        <div style={{ minHeight: "1000px" }}>
          {this.props.match.params.category}>
          {this.props.match.params.subcategory}>{this.props.match.params.team}
        </div>
      </Fragment>
    );
  }
}
