import React, {Component, Fragment} from "react";
import {Carousel} from "react-responsive-carousel";
import "./MainArticles.css";

const MainArticle = ({isSelected, alt, caption, headLine, img, published, category, setIndex, length, index, changeIndex, articles}) => {
  let buttons = []
  buttons.push(<button
    style={{borderRadius: "50%", width: "2vw", border: "3px solid #eee", background: 'white', height: "2vw",}}
    onClick={() => changeIndex(-1, length)}>
    {"<"}
  </button>)
  for (let i = 0; i < length; i++) {
    if (i === index) {
      buttons.push(<button
        style={{borderRadius: "50%", width: "2vw", border: "0px solid #e00",color:"#f00", background: 'white', height: "2vw",}}
        onClick={() => setIndex(i)}>
        {"0"+ (i + 1)}
      </button>)
    } else {
      buttons.push(<button style={{
        borderRadius: "50%",
        width: "2vw",
        height: "2vw",
        border: "0px solid #ccc",
        background: 'white',
        color:"#aaa"

      }} onClick={() => setIndex(i)}>
        {'0'+(i + 1)}
      </button>)
    }

  }
  buttons.push(<button
    style={{borderRadius: "50%", width: "2vw", border: "3px solid #eee", background: 'white', height: "2vw",}}
    onClick={() => changeIndex(1, length)}>
    {">"}
  </button>)
  return (
    <Fragment>
      <div style={{display: "flex", width: "100%"}}>
        <img src={img} alt={alt} style={{width: "64%", height:'calc((100vw - 300px) * 0.36)',zIndex: -2}}/>
        <div style={{marginTop: '33%', marginLeft:"2%"}}>{buttons}</div>
        <div style={{
          background: '#333', position: 'absolute', color: 'white', width: '10%', display: "flex",
          textAlign: "center",
          height:"3vw",
          justifyContent: "center",
          alignItems: "center",
          fontSize: "1vw",
          zIndex:-1
        }}>
          {category}
        </div>
        <div style={{
          background: '#eee',
          position: 'absolute',
          color: 'white',
          height: 'calc((100vw - 300px) * 0.26)',
          width: 'calc((100% - 300px) * 0.4)',
          marginTop:'calc((100% - 300px) * 0.05)',
          marginLeft:'calc((100% - 300px) * 0.50)',
          overflow: "hidden",
          zIndex: -1,
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
          }}>
            <b style={{fontSize: "1vw", padding: 0, display: "block"}}>More</b></div>
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
      {/*<div style={{position: "relative", display: "inline-block", marginTop: "70px", width: "100%", zIndex: '-1'}}>*/}
      {/*  <img src={img} alt={alt} style={{width: "calc(64vw)", height: '36vw',}}/>*/}
      {/*  <div style={{*/}
      {/*    background: '#333', position: 'absolute', color: 'white', top: 0, width: '10%', display: "flex",*/}
      {/*    height: '10%',*/}
      {/*    textAlign: "center",*/}
      {/*    justifyContent: "center",*/}
      {/*    alignItems: "center",*/}
      {/*    fontSize: "1vw",*/}
      {/*  }}>{category}</div>*/}
      {/*  <div style={{display:'flex'}}>*/}

      {/*    <div style={{*/}
      {/*      background: '#eee',*/}
      {/*      position: 'absolute',*/}
      {/*      color: 'white',*/}
      {/*      height: '60%',*/}
      {/*      width: '35%',*/}
      {/*      top: '20%',*/}
      {/*      left: '55%',*/}
      {/*      paddingTop: '0px',*/}
      {/*      overflow: "hidden"*/}
      {/*    }}>*/}
      {/*      <button style={{zIndex:20000000}}>rrr</button>*/}
      {/*      <div style={{*/}
      {/*        background: '#f22',*/}
      {/*        position: 'absolute',*/}
      {/*        display: "flex",*/}
      {/*        color: 'white',*/}
      {/*        bottom: '0',*/}
      {/*        width: '40%',*/}
      {/*        height: '20%',*/}
      {/*        textAlign: "center",*/}
      {/*        justifyContent: "center",*/}
      {/*        alignItems: "center"*/}
      {/*      }}><b style={{fontSize: "1vw", padding: 0, display: "block"}}>More</b></div>*/}
      {/*      <p style={{color: '#666', textAlign: 'left', marginLeft: '50px', marginRight: '30px', fontSize: "1vw"}}>*/}
      {/*        <b>Published/ {published}</b></p>*/}
      {/*      <h5 style={{color: 'red', textAlign: 'left', marginLeft: '50px', marginTop: '10px', fontSize: "1vw"}}>*/}
      {/*        <b>{headLine}</b></h5>*/}
      {/*      <h2 style={{*/}
      {/*        color: '#222',*/}
      {/*        textAlign: 'left',*/}
      {/*        marginLeft: '50px',*/}
      {/*        marginRight: '30px',*/}
      {/*        fontWeight: 500,*/}
      {/*        fontSize: "1vw"*/}
      {/*      }}>{caption}</h2>*/}

      {/*    </div>*/}
      {/*    {buttons}</div>*/}


      {/*</div>*/}

      {/*<div style={{*/}
      {/*  position: 'absolute', color: 'white', top: '80%', width: '10%', left: "70%", display: "flex",*/}
      {/*  height: '10%',*/}
      {/*  textAlign: "center",*/}
      {/*  justifyContent: "center",*/}
      {/*  alignItems: "center",*/}
      {/*  fontSize: "1vw",*/}
      {/*  zIndex: 0*/}
      {/*}}>*/}

      {/*</div>*/}

    </Fragment>)

  // <img src={img} alt={alt}/>
};

export class MainArticles extends Component {
  componentDidMount() {
    setInterval(() => {

      this.setState({index: (this.state.index+1)%this.props.articles.length});

    }, 5500);
  }

  state = {
    index: 0,
  }
  setIndex = index => {
    this.setState({index: index})
  }
  changeIndex = (index, length)=> {
    if (this.state.index + index > length -1){this.setState({index: 0})}
    else if(
    this.state.index + index<0)
    {this.setState({index: length - 1})}
    else{
      this.setState({index: this.state.index + index})
    }

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
                         changeIndex={this.changeIndex.bind(this)}
                         length={this.props.articles.length}
                         index={this.state.index}
                         articles={this.props.articles}
            />
          </div> : null}
      </Fragment>
    );
  }
}
