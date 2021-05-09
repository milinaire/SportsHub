import React, {Component, Fragment} from "react";
import {withRouter} from "react-router-dom";

class Category extends Component {
  componentDidMount() {
    this.props.setCurrentSection(this.props.match.params.category)
  }

  componentDidUpdate(prevProps, prevState, snapshot) {
    if (prevProps.match.params.category !== this.props.match.params.category) {
      this.props.setCurrentSection(this.props.match.params.category)
    }
  }

  render() {
    return (
      <Fragment>
        Category
      </Fragment>
    );
  }
}

export default withRouter(Category)