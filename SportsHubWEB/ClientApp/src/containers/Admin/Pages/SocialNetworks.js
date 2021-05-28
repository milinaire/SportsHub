import React, {Component, Fragment} from "react";

export class SocialNetworks extends Component {

  componentDidMount() {
    this.props.setCurrentSection("Social Networks")
  }

  render() {
    return (
      <Fragment>
        SocialNetworks
      </Fragment>
    );
  }
}
