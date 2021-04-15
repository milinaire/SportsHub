import React, {Component, Fragment} from "react";
import {Carousel} from "react-responsive-carousel";
import "./MainArticles.css";

const MainArticle = ({isSelected, alt, caption, headLine, img, published, category, setIndex, length, index}) => {
  let buttons = []
  for (let i = 0; i < length; i++) {
    if (i === index) {
      buttons.push(<button style={{borderRadius: "50%", width: "100%", border: "4px solid #e00", background:'white'}} onClick={() => setIndex(i)}>
        {i + 1}
      </button>)
    }
    else {
      buttons.push(<button style={{borderRadius: "50%", width: "100%", border: "4px solid #ccc",background:'white', zIndex:1}} onClick={() => setIndex(i)}>
        {i + 1}
      </button>)
    }

  }
  return (
<Fragment>
    <div style={{position: "relative", display: "inline-block", marginTop: "70px", width: "100%", zIndex:'-1'}}>
      <img src={img} alt={alt} style={{width: "calc(64vw)", height:'36vw',}}/>
      <div style={{
        background: '#333', position: 'absolute', color: 'white', top: 0, width: '10%', display: "flex",
        height: '10%',
        textAlign: "center",
        justifyContent: "center",
        alignItems: "center",
        fontSize: "1vw",
      }}>{category}</div>
      <div style={{
        background: '#eee',
        position: 'absolute',
        color: 'white',
        height: '60%',
        width: '35%',
        top: '20%',
        left: '55%',
        paddingTop: '0px',
        overflow: "hidden"
      }}>
        <div style={{
          background: '#f22',
          position: 'absolute',
          display: "flex",
          color: 'white',
          bottom: '0',
          width: '40%',
          height: '20%',
          textAlign: "center",
          justifyContent: "center",
          alignItems: "center"
        }}><b style={{fontSize: "1vw", padding: 0, display: "block"}}>More</b></div>
        <p style={{color: '#666', textAlign: 'left', marginLeft: '50px', marginRight: '30px', fontSize: "1vw"}}>
          <b>Published/ {published}</b></p>
        <h5 style={{color: 'red', textAlign: 'left', marginLeft: '50px', marginTop: '10px', fontSize: "1vw"}}>
          <b>{headLine}</b></h5>
        <h2 style={{
          color: '#222',
          textAlign: 'left',
          marginLeft: '50px',
          marginRight: '30px',
          fontWeight: 500,
          fontSize: "1vw"
        }}>{caption}</h2>

      </div>



    </div>
  <div style={{
    position: 'absolute', color: 'white', top: '80%', width: '10%', left: "70%", display: "flex",
    height: '10%',
    textAlign: "center",
    justifyContent: "center",
    alignItems: "center",
    fontSize: "1vw",
    zIndex:0
  }}>
    {buttons}
  </div>
</Fragment>)

  // <img src={img} alt={alt}/>
};

export class MainArticles extends Component {
  state = {
    index: 0,
  }
  setIndex = index => {
    this.setState({index: index})
  }

  render() {
    return (
      <Fragment>
        {this.props.articles.length ?
          <div className="main-articles">
            <MainArticle key={this.props.articles[this.state.index].id}
                         alt={this.props.articles[this.state.index].Alt}
                         caption={this.props.articles[this.state.index].Caption}
                         headLine={this.props.articles[this.state.index].HeadLine}
                         img={this.props.articles[this.state.index].Image}
                         published={this.props.articles[this.state.index].Published}
                         category={this.props.articles[this.state.index].Category}
                         setIndex={this.setIndex.bind(this)}
                         length={this.props.articles.length}
                         index={this.state.index}
            />
          </div> : null}
      </Fragment>
    );
  }
}
