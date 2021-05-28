import React, {Component, Fragment} from "react";

export class Teams extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Teams")
  }

  render() {
    return (
      <Fragment>
        Teams
      </Fragment>
    );
  }
}
