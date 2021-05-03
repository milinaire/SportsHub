import React, {Component, Fragment} from "react";
import {Link} from "react-router-dom";

export function NotFound() {
  return (
    <Fragment>
      <div style={{display:"flex", justifyContent:"center", alignItems:"center", flexDirection:"column"}}>
        <h1>Not Found</h1>
        <Link to="/">
          Back to main page
        </Link>
      </div>
    </Fragment>
  );
}