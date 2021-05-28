import React, {Component, Fragment} from "react";

export class Users extends Component {
  componentDidMount() {
    this.props.setCurrentSection("Users")
  }

  render() {
    return (
      <Fragment>
        Users
      </Fragment>
    );
  }
}
