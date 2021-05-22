import React from "react";
import s from './Loader.module.css'
import loader from './Rolling-1s-200px.svg'

const Loader = () => {
  return (
    <div className={s.LoaderWrapper}>
      <div className={s.LoaderLimit}>
        {loader
          ? <img className={s.Loader} src={loader} alt={'Loading...'}/>
          : 'Loading...'
        }
      </div>
    </div>
  )
}
export default Loader