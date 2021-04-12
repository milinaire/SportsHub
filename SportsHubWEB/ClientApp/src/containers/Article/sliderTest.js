import React, {Component, Fragment} from "react";


export class Slideshow extends Component {
  state = {
    colors: ["#0088FE", "#00C49F", "#FFBB28", "#dd32aa", "#3ab7d1"],
    delay: 500,
    index: 0,
    animated: 'animated',
  }

  constructor(props) {
    super(props);

  }

  componentDidMount(){
    setInterval(() => {
      if(this.state.index === 1){
        this.setState({animated:''})
        const temp = this.state.colors.shift()
        this.setState({index:this.state.index-1})
        this.setState({colors:[...this.state.colors, temp]})


      }else{
        this.setState({animated:'animated'})
        console.log(this.state.index)
        this.setState({index:this.state.index+1})
      }


    }, 2500)
  }
  render() {
    return (
      <div className="slideshow">
        <div
          className={`slideshowSlider ${this.state.animated}`}
          style={{
            transform: `translate3d(0, -${this.state.index*100}px, 0)`,
          }}
        >
          {this.state.colors.map((backgroundColor, index) => (
            <div
              className="slide"
              key={index}
              style={{backgroundColor}}
            />
          ))}
        </div>
      </div>
    );
  }
}


