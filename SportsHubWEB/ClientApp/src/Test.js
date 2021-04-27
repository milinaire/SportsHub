import React, {Component, Fragment} from 'react'
import "./custom.css"
import {Link} from "react-router-dom";


export default class Test extends Component {
  state = {
    hoveredCategory: false,
  }
  setHovered = (id, left) => {
    for (let i = 0; i < id.length; i++) {
      document.getElementById(id[i]).style.marginLeft = `${left[i]}px`;
    }
    clearTimeout(this.timeout)
     document.getElementById("box").style.zIndex = "5";
    document.getElementById("box").style.backgroundColor = "rgba(0, 0, 0, 0.8)";
  }
  unsetHovered = (id, left) => {
    for (let i = 0; i < id.length; i++) {
      document.getElementById(id[i]).style.marginLeft = `${left[i]}px`;
    }

    document.getElementById("box").style.backgroundColor = "rgba(0, 0, 0, 0.0)";
    this.timeout = setTimeout(()=> document.getElementById("box").style.zIndex = "-1", 400)
  }

  render() {
    return (
      <Fragment>
        <div id="box" className="gray-box">

        </div>
        <div id="1" className={`custom-nav `}
             onMouseEnter={() => this.setHovered([1, 2], [200, 100])}
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0])}
        >
          1
        </div>
        <div id="2" className={`custom-nav `}
             onMouseEnter={() => this.setHovered([1, 2], [200, 100])}
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0])}
        >
          2
        </div>
        <div id="3" className={`custom-nav `}
             onMouseEnter={() => this.setHovered([1, 2], [100, 100])}
             onMouseLeave={() => this.unsetHovered([1, 2], [0, 0])}
        >
          3
        </div>


        <div className="content">

          <div className="child">
            <Link to="rrr">
              <div className="for-link">

              </div>
            </Link>
          </div>

          <div className="child">

          </div>
          <div className="child">

          </div>
          <div className="child">

          </div>
        </div>
      </Fragment>
    )
  }
}