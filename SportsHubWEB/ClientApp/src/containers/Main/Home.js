import React, {Component, Fragment} from "react";
import "./home.css"


export class Home extends Component {
  static displayName = Home.name;
  state = {
    index: 0,

    BreakDown: [
    ],
    PhotoOfTheDay: { 
      Image:
        "https://images.ctfassets.net/u0haasspfa6q/2xl0w4P7lIAVEESotMPxlF/12eb1aba070dfbbbd0d0c1127798abec/AMA_EVERTON_LIVERPOOL_RJB_27",
      Alt: "Alt",
      Title: "Title",
      Description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse aliquet ac felis sit amet molestie. Nam fringilla eros lectus, eu gravida dolor volutpat ut.",
      Author: "Author",
    
    },
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
    fetch("/article/main/display")
      .then(res => res.json())
      .then(
        (result) => {
          //this.setState({MainArticles: result})
          this.props.setMainArticles(result, true, 'main-article')
        },
        (error) => {
          this.setState({
            error
          });
        }
      )

    let str=""
    fetch("/breakdown")
      .then(res => res.json())
      .then(
        (result) => {
          for (let i = 0; i < result.length; i++) {
            if(result[i].categoryId){
              str = `/sportarticle?categoryId=${result[i].categoryId}`
            }else if(result[i].conferenceId) {
              str = `/sportarticle?conferenceId=${result[i].conferenceId}`
            }else if(result[i].teamId){
              str = `/sportarticle?teamId=${result[i].teamId}`
            }
            if(str){
              fetch(str)
                .then(res => res.json())
                .then(
                  (result) => {
                     this.setState({BreakDown: [...this.state.BreakDown, result]})

                  },
                  (error) => {
                    this.setState({
                      error
                    });
                  }
                )
            }
          }


        },
        (error) => {
          this.setState({
            error
          });
        }
      )



  }

  componentWillUnmount() {
    this.props.setMainArticles([])
  }
  render() {

    return (

      <Fragment>
          <div className="breakwrap3">
            <div className="break-line-wrap">
              <hr className="hr1"/>
              <div className="break-line"><b>BREAKDOWN</b></div>
              <hr className="hr1"/>
            </div>
            {this.state.BreakDown.map((com) => (
              <div key={com[0].articleId+com[1].articleId+com[2].articleId+com[3].articleId} className="breakdown">
                <div className="big-a">
                  <img className="big-i" src={com[0].imageUri} alt={com[0].alt}/>
                  <div className="pop-text1">
                    <p>{com[0].headline}</p>
                  </div>
                </div>
                <div className="com">
                  <div className="pop-card">
                    <img className="small-i" src={com[1].imageUri} alt={com[1].alt}/>
                    <div className="pop-text">
                      <b><p>{com[1].headline}</p></b>
                      <p>{com[1].caption}</p>
                    </div>
                  </div>
                  <div className="pop-card">
                    <img className="small-i" src={com[2].imageUri} alt={com[2].alt}/>
                    <div className="pop-text">
                      <b><p>{com[2].headline}</p></b>
                      <p>{com[2].caption}</p>
                    </div>
                  </div>
                  <div className="pop-card">
                    <img className="small-i" src={com[3].imageUri} alt={com[3].alt}/>
                    <div className="pop-text">
                      <b><p>{com[3].headline}</p></b>
                      <p>{com[3].caption}</p>
                    </div>
                  </div>
                </div>
            </div>
          ))}

        </div>
              
          <div className="breakwrap">
            <div className="break-line-wrap">
              <hr className="hr1"/>
              <div className="break-line"><b>PHOTO OF THE DAY</b></div>
              <hr className="hr1"/>
            </div>
            <div className="arrow-right">
              <p><span className="bb">photo</span> of the <span className="bb">day</span></p>
            </div>
            <img className="photo-of-the-day" src={this.state.PhotoOfTheDay.Image} alt={this.state.PhotoOfTheDay.Alt}/>
            <div className="description-of-the-day">
              <h3>{this.state.PhotoOfTheDay.Title}</h3>
              <p>{this.state.PhotoOfTheDay.Description}</p>
              <p className="text-of-the-day">{this.state.PhotoOfTheDay.Author}</p>
            </div>
          </div>
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
      </Fragment>
    );
  }
}
