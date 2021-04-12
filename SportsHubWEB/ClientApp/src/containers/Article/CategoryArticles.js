import React, { Component, Fragment } from "react";

export class CategoryArticles extends Component {
  componentDidMount(){
    this.props.setCategory(this.props.match.params.category)
  }
  getSnapshotBeforeUpdate(prevProps, prevState){
    return this.props.match.params.category
  }
  componentDidUpdate(prevProps, prevState, snapshot) {
    if(prevProps.match.params.category!==this.props.match.params.category){
      this.props.setCategory(this.props.match.params.category)
      console.log("hi",this.props.match.params.category)
    }
}
  componentWillUnmount(){
    this.props.setCategory('')
  }
  
  render() {
    
    return (
      <Fragment>
        <div style={{ minHeight: "1000px" }}>
          {this.props.match.params.category}
          {}
        </div>
      </Fragment>
    );
  }
}
