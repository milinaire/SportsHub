import React, {Fragment} from "react";
import style from './Home.module.css'
import './../../../containers/Main/home.css'
import {Link} from "react-router-dom";
const Home = (props) => {
  console.log(props)
  return (
    <Fragment>
      <div className={style.homeWrapper}>
        {props.breakdown.breakdown.length ? <div className="break-line-wrap">
          <hr className="hr1"/>
          <div className="break-line"><b>BREAKDOWN</b></div>
          <hr className="hr1"/>
        </div> : null}
        <div className={style.homeBreakdownContainer}>
          {props.breakdown.breakdown.length ? (props.breakdown.breakdown.map((com) => (

              <div key={com.name} className={style.homeBreakdownArticleContainer}>
                <Link to={`/nav/${com.articles[0].categoryId}/${com.articles[0].conferenceId}/${com.articles[0].teamId}/${com.articles[0].articleId}`}
                      className={style.homeBreakdownOneArticleContainer}>
                  <div className={style.homeBreakdownArticleBackground}
                       style={{backgroundImage: `url(${com.articles[0].imageUri})`}}>
                    <div className={style.homeBreakdownOneArticleCaption}>
                      <p>{com.articles[0].headline}</p>
                    </div>
                  </div>
                </Link>
                <div className={style.homeBreakdownThreeArticleContainer}>
                  <Link to={`/nav/${com.articles[1].categoryId}/${com.articles[1].conferenceId}/${com.articles[1].teamId}/${com.articles[1].articleId}`}
                    className={style.homeBreakdownThreeArticleEachArticle}>
                    <div className={style.homeBreakdownThreeArticleEachArticleImg}>
                      <div className={style.homeBreakdownArticleBackground}
                           style={{backgroundImage: `url(${com.articles[1].imageUri})`}}>

                      </div>
                    </div>
                   <div className={style.homeBreakdownThreeArticleEachArticleCaption}>
                     <p>{com.articles[1].headline}</p>
                   </div>
                  </Link>
                  <Link to={`/nav/${com.articles[2].categoryId}/${com.articles[2].conferenceId}/${com.articles[2].teamId}/${com.articles[2].articleId}`}
                    className={style.homeBreakdownThreeArticleEachArticle}>
                    <div className={style.homeBreakdownThreeArticleEachArticleImg}>
                      <div className={style.homeBreakdownArticleBackground}
                           style={{backgroundImage: `url(${com.articles[2].imageUri})`}}>

                      </div>
                    </div>
                    <div className={style.homeBreakdownThreeArticleEachArticleCaption}>
                      <p>{com.articles[2].headline}</p>
                    </div>
                  </Link>
                  <Link to={`/nav/${com.articles[3].categoryId}/${com.articles[3].conferenceId}/${com.articles[3].teamId}/${com.articles[3].articleId}`}
                        className={style.homeBreakdownThreeArticleEachArticle}>
                    <div className={style.homeBreakdownThreeArticleEachArticleImg}>
                      <div className={style.homeBreakdownArticleBackground}
                           style={{backgroundImage: `url(${com.articles[3].imageUri})`}}>

                      </div>
                    </div>
                    <div className={style.homeBreakdownThreeArticleEachArticleCaption}>
                      <p>{com.articles[3].headline}</p>
                    </div>
                  </Link>
                </div>
              </div>


            )
          )) : 'Loading..'}
        </div>

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
          <img style={{width:'100%'}} className="photo-of-the-day" src={'https://images.ctfassets.net/u0haasspfa6q/2xl0w4P7lIAVEESotMPxlF/12eb1aba070dfbbbd0d0c1127798abec/AMA_EVERTON_LIVERPOOL_RJB_27'} alt={'alt'}/>
          <div className="description-of-the-day">
              <h3>{'Title'}</h3>
              <p>{'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse aliquet ac felis sit amet molestie. Nam fringilla eros lectus, eu gravida dolor volutpat ut.'}</p>
              <p className="text-of-the-day">{'this.state.PhotoOfTheDay.Author'}</p>
          </div>
      </div>
      {/*<div className="breakwrap1">*/}
      {/*    <div className="flex-most">*/}
      {/*        <div className="break-line-wrap1">*/}
      {/*            <b>MOST POPULAR</b>*/}
      {/*            <hr className="hr2"/>*/}
      {/*        </div>*/}
      {/*        <div className="pop">*/}
      {/*            {this.state.MostPopular.map((pop) => (*/}
      {/*              <div key={pop.Id} className="pop-card">*/}
      {/*                  <img src={pop.Image} alt={pop.Alt}/>*/}
      {/*                  <div className="pop-text">*/}
      {/*                      <b><p>{pop.HeadLine}</p></b>*/}
      {/*                      <p>{pop.Caption}</p>*/}
      {/*                  </div>*/}
      {/*              </div>*/}
      {/*            ))}*/}
      {/*        </div>*/}
      {/*    </div>*/}
      {/*    <div className="flex-most">*/}
      {/*        <div className="break-line-wrap1">*/}

      {/*            <b>MOST COMENTED</b>*/}
      {/*            <hr className="hr2"/>*/}
      {/*        </div>*/}
      {/*        <div className="pop">*/}
      {/*            {this.state.MostCommented.map((com) => (*/}
      {/*              <div key={com.Id} className="pop-card">*/}
      {/*                  <img src={com.Image} alt={com.Alt}/>*/}
      {/*                  <div className="pop-text">*/}
      {/*                      <b><p>{com.HeadLine}</p></b>*/}
      {/*                      <p>{com.Caption}</p>*/}
      {/*                  </div>*/}
      {/*              </div>*/}
      {/*            ))}*/}
      {/*        </div>*/}
      {/*    </div>*/}
      {/*</div>*/}
    </Fragment>
  );
}
export default Home;