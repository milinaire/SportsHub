import React, { Component, Fragment } from "react";

export class CategoryArticles extends Component {
  render() {
    return (
      <Fragment>
        <div style={{ minHeight: "1000px" }}>
          {this.props.match.params.category}
        </div>
      </Fragment>
    );
  }
}
