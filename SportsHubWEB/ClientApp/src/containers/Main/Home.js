import React, {Component} from "react";
import Card from "react-bootstrap/Card";
import "./home.css"
import {Carousel} from "react-responsive-carousel";

import "react-responsive-carousel/lib/styles/carousel.min.css";

const MainArticle = ({isSelected, alt, caption, headLine, img, published}) => (
  <div  title={alt} style={{backgroundImage:`url(${img})`, height:'548px', backgroundRepeat: 'no-repeat'}}>
    <div style={{background:'#333', position:'fixed', padding:'15px 50px', color:'white'}}>NBA</div>
    <div style={{background:'#eee', position:'relative', color:'white', height:'400px', width:'550px', top:'74px', left:'-600px', paddingTop:'0px'}}>
      <div style={{background:'#f22', position:'relative', padding:'15px 50px', color:'white', top:'345px', width:'200px', height:'55px'}}><b>More</b></div>
      <p style={{color:'#666', textAlign:'left', marginLeft:'50px', marginRight:'30px'}}><b>Published/ {published}</b></p>
      <h5 style={{color:'red', fontSize:20, textAlign:'left', marginLeft:'50px', marginTop:'10px'}}><b>{headLine}</b></h5>
      <h2 style={{color:'#222', textAlign:'left', marginLeft:'50px', marginRight:'30px', fontWeight:500}}>{caption}</h2>

    </div>

  </div>
  // <img src={img} alt={alt}/>
);

export class Home extends Component {
  static displayName = Home.name;
  state = {
    index:0,
    MainArticles: [
      {
        Id: 1,
        Alt: "Alt",
        HeadLine: "HeadLine1",
        Caption: "Caption1 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine2",
        Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine3",
        Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 4,
        Alt: "Alt",
        HeadLine: "HeadLine4",
        Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 5,
        Alt: "Alt",
        HeadLine: "HeadLine5",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
    ],
    BreakDown: [
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
    ],
    PhotoOfTheDay: {
      Image:
        "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      Alt: "Alt",
      Title: "Title",
      Description: "Description",
      Author: "Author",
    },
    MostPopular: [
      {
        Id: 1,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
    ],
    MostCommented: [
      {
        Id: 1,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
      },
    ],
  };

  arrowNext = () => {
    let b = []
    this.state.MainArticles.map((Article) => (
      b.push(<div>
        <img alt={Article.Alt} src={Article.Image}/>
        <p className="legend">{Article.HeadLine}</p>
      </div>)
    ))
    return (b)
  }
  arrowPrev = () => {
    let b = []
    this.state.MainArticles.map((Article) => (
      b.push(<div>
        <img alt={Article.Alt} src={Article.Image}/>
        <p className="legend">{Article.HeadLine}</p>
      </div>)
    ))
    return (b)
  }
  indicator = () => {
    let b = []
    this.state.MainArticles.map((Article) => (
      b.push(<div>
        <img alt={Article.Alt} src={Article.Image}/>
        <p className="legend">{Article.HeadLine}</p>
      </div>)
    ))
    return (b)
  }
  item = (item, props) => <item.type {...item.props} {...props} />;
  thumbs = (children) =>
    children.map((item) => {
      return <img src={item.props.img}  alt={item.props.alt}/>;
    });


  render() {
    return (
      <main>
        <Carousel showArrows={true} dynamicHeight={true} infiniteLoop={true} interval={6000} autoPlay={true}
                  transitionTime={1000} showThumbs={true} thumbWidth={900/this.state.MainArticles.length}
                  onClickThumb={index => this.setState({index:index})}
                  selectedItem={this.state.index}
                  //renderArrowNext={this.arrowNext}
                  //renderArrowPrev={this.arrowPrev}
                  //renderIndicator={this.indicator}

                  renderItem={this.item}
                  renderThumbs={this.thumbs}
        >
          {this.state.MainArticles.map((Article) => (
            <MainArticle key={Article.id} alt={Article.Alt} caption={Article.Caption} headLine={Article.HeadLine} img={Article.Image} published={Article.Published}/>
          ))}
        </Carousel>

      </main>
    );
  }
}
