import React, { Component, Fragment } from "react";
import "./home.css"
import {PageLayout} from "../../components/Main/Layout/PageLayout";


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
        Category: "NBA",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine2",
        Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://markateur.com/wp-content/uploads/2017/04/articles.jpg",
        Category: "UFC",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine3",
        Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7pfEljy7X0eBed-8PpZwT3X4tqY_LCZbDLnNGAk3qldHhF3YOnfY_1NYyWzumMYwpuws&usqp=CAU",
        Category: "QTV",
      },
      {
        Id: 4,
        Alt: "Alt",
        HeadLine: "HeadLine4",
        Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        Category: "NBA",
      },
      {
        Id: 5,
        Alt: "Alt",
        HeadLine: "HeadLine5",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit. Adipisci consectetur culpa cumque eligendi, id incidunt iste itaque nihil unde.",
        Published: "20.09.2019",
        Image:
          "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        Category: "ATB",
      },
    ],
    BreakDown: [
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption1 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
          Image:
            "https://img.bleacherreport.net/img/images/photos/002/062/823/hi-res-85160433_crop_exact.jpg?w=3072&h=2048&q=75",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption1 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "http://3.bp.blogspot.com/-fRlqj8qr958/T-mKCxcDoUI/AAAAAAAAAvY/hbAq8vCEhuw/s1600/HvGame9.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption1 Lorem ipsum dolor sit amet, consectetur adipisicing elit..",
          Image:
            "https://m0.joe.co.uk/wp-content/uploads/2017/07/03132858/5.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption1 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Youth-soccer-indiana.jpg/1200px-Youth-soccer-indiana.jpg",
        },
      ],
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption2 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption3 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
      [
        {
          Id: 1,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 2,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 3,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
        {
          Id: 4,
          Alt: "Alt",
          HeadLine: "HeadLine",
          Caption: "Caption4 Lorem ipsum dolor sit amet, consectetur adipisicing elit. ",
          Image:
            "https://ichef.bbci.co.uk/news/976/cpsprodpb/143D5/production/_117710928_tv066419238.jpg",
        },
      ],
    ],
    PhotoOfTheDay: [{ 
      Image:
        "https://images.ctfassets.net/u0haasspfa6q/2xl0w4P7lIAVEESotMPxlF/12eb1aba070dfbbbd0d0c1127798abec/AMA_EVERTON_LIVERPOOL_RJB_27",
      Alt: "Alt",
      Title: "Title",
      Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse aliquet ac felis sit amet molestie. Nam fringilla eros lectus, eu gravida dolor volutpat ut.",
      Author: "Author",
    
    }],
    MostPopular: [
      {
        Id: 1,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
        Image:
          "https://www.bodo.ua/resize/upload/files/cm-experience/3/2252/images_file/all_all_big-t1559721362-r1w768h425q90zc1.jpg",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
        Image:
          "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/summer-running-1597413181.jpg?crop=1xw:0.75xh;center,top&resize=1200:*",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
        Image:
          "https://res.cloudinary.com/grohealth/image/upload/f_auto,fl_lossy,q_auto/v1581678662/DCUK/Content/iStock-959080376.jpg",
      },
    ],
    MostCommented: [
      {
        Id: 1,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
        Image:
          "https://img.tsn.ua/cached/1616658801/tsn-e4d2bbace79d9196864837254e47d00a/thumbs/1200x630/3d/89/74cd30d92f6b60cb58b5b5f7c641893d.jpeg",
      },
      {
        Id: 2,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
        Image:
        "https://www.denverpost.com/wp-content/uploads/2017/08/aedf4990d9ac4ac9a4f0ff4fee2b51bf.jpg",
      },
      {
        Id: 3,
        Alt: "Alt",
        HeadLine: "HeadLine",
        Caption: "Caption5 Lorem ipsum dolor sit amet, consectetur adipisicing elit.",
        Image:
        "https://www.denverpost.com/wp-content/uploads/2017/08/aedf4990d9ac4ac9a4f0ff4fee2b51bf.jpg",
      },
    ],
    MainArticles: []

  };


  componentDidMount() {
    fetch("https://localhost:5001/article")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({MainArticles: result})
        },
        (error) => {
          this.setState({
            error
          });
        }
      )
  }

  componentWillUnmount() {
    // this.props.setArticles([])

  }
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

      <Fragment>
        <PageLayout MainArticles={this.state.MainArticles}>
          <div className="breakwrap3">
            <div className="break-line-wrap">
              <hr className="hr1"/>
              <div className="break-line"><b>BREAKDOWN</b></div>
              <hr className="hr1"/>
            </div>
            {this.state.BreakDown.map((com) => (
              <div key={com[0].Id} className="breakdown">
                <div className="big-a">
                  <img className="big-i" src={com[0].Image} alt={com[0].Alt}/>
                  <div className="pop-text1">
                    <p>{com[0].Caption}</p>
                  </div>
                </div>
                <div className="com">
                  <div className="pop-card">
                    <img className="small-i" src={com[1].Image} alt={com[1].Alt}/>
                    <div className="pop-text">
                      <b><p>{com[1].HeadLine}</p></b>
                      <p>{com[1].Caption}</p>
                    </div>
                  </div>
                  <div className="pop-card">
                    <img className="small-i" src={com[2].Image} alt={com[2].Alt}/>
                    <div className="pop-text">
                      <b><p>{com[2].HeadLine}</p></b>
                      <p>{com[2].Caption}</p>
                    </div>
                  </div>
                  <div className="pop-card">
                    <img className="small-i" src={com[3].Image} alt={com[3].Alt}/>
                    <div className="pop-text">
                      <b><p>{com[3].HeadLine}</p></b>
                      <p>{com[3].Caption}</p>
                    </div>
                  </div>
                </div>



            </div>
          ))}

        </div>

        {this.state.PhotoOfTheDay.map((photo) => (
        <div className="breakwrap">

            <div className="break-line-wrap">  
              <hr class="hr1"/><div className="break-line"><b>PHOTO OF THE DAY</b></div><hr class="hr1"/>
            </div>
            <div className="photo-arrow">
            <div className="arrow-right">
              <p><span className="bb">photo</span> of the <span className="bb">day</span></p>
            </div>
            <img className="photo-of-the-day" src={photo.Image}></img>
            <div className="description-of-the-day">
              <h3>{photo.Title}</h3>
              <p >{photo.Description}</p>
              <p className="text-of-the-day">{photo.Author}</p>
            </div>
            </div>
        </div>
         ))}
  
        <div className="breakwrap1">


            <div className="flex-most">
              <div className="break-line-wrap1">
                <b>MOST POPULAR</b>
                <hr className="hr2"/>
              </div>
              <div className="pop">
                {this.state.MostPopular.map((pop) => (
                  <div key={pop.Id} className="pop-card">
                    <img src={pop.Image} alt={pop.Alt}/>
                    <div className="pop-text">
                      <b><p>{pop.HeadLine}</p></b>
                      <p>{pop.Caption}</p>
                    </div>
                  </div>
                ))}
              </div>
            </div>
            <div className="flex-most">
              <div className="break-line-wrap1">
                <b>MOST COMENTED</b>
                <hr className="hr2"/>
              </div>
              <div className="pop">
                {this.state.MostCommented.map((com) => (
                  <div key={com.Id} className="pop-card">
                    <img src={com.Image} alt={com.Alt}/>
                    <div className="pop-text">
                      <b><p>{com.HeadLine}</p></b>
                      <p>{com.Caption}</p>
                    </div>
                  </div>



              ))}
                  </div>
            </div>


        </div>
        </PageLayout>

      </Fragment>

    );
  }
}
