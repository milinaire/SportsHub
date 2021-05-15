import React, {Fragment} from "react";
import style from './NavMenu.module.css'
import {NavLink} from "react-router-dom";

const NavMenu = (props) => {
  return (
    <Fragment>
      <div className={`${style.grayBox} ${props.navigation.hoveredCategory &&
      props.navigation.conferences.filter(c => c.categoryId === props.navigation.hoveredCategory).length
        ? style.grayBoxActive : ''}`}/>
      <div
        className={`${style.teams} ${props.navigation.hoveredConference &&
        props.navigation.teams.filter(t => t.conferenceId === props.navigation.hoveredConference).length
          ? style.thirdPosition + ' ' + style.coverFooter : props.navigation.hoveredCategory &&
          props.navigation.conferences.filter(c => c.categoryId === props.navigation.hoveredCategory).length ?
            style.secondPosition + ' ' + style.coverFooter : style.defaultPosition}`}
        onMouseEnter={() => {
          props.setHoveredCategory(props.navigation.hoveredCategory);
          props.setHoveredConference(props.navigation.hoveredConference);
        }}
        onMouseLeave={() => {
          props.setHoveredCategory(null);
          props.setHoveredConference(null);
        }}>
        {props.navigation.teams.map(team => {
          if (team.conferenceId === props.navigation.hoveredConference) {
            return (
              <NavLink activeClassName={style.teamsItemActive}
                       to={`/nav/${props.navigation.hoveredCategory}/${props.navigation.hoveredConference}/${team.teamId}`}
                       key={team.teamId} className={style.teamsItem}>
                {team.name}
              </NavLink>
            )
          }
          return null
        })}
      </div>
      <div
        className={`${style.conferences} ${props.navigation.hoveredCategory &&
        props.navigation.conferences.filter(c => c.categoryId === props.navigation.hoveredCategory).length ?
          style.firstPosition + ' ' + style.coverFooter
          : style.defaultPosition}`}
        onMouseEnter={() => {
          props.setHoveredCategory(props.navigation.hoveredCategory);
        }}
        onMouseLeave={() => {
          props.setHoveredCategory(null);
        }}>
        {props.navigation.conferences.map(conference => {
          if (conference.categoryId === props.navigation.hoveredCategory) {
            return (
              <NavLink
                activeClassName={style.conferencesItemActive}
                to={`/nav/${props.navigation.hoveredCategory}/${conference.conferenceId}`}
                onMouseEnter={() => {
                  props.setHoveredCategory(conference.categoryId);
                  props.setHoveredConference(conference.conferenceId);
                }}
                onMouseLeave={() => {
                  props.setHoveredConference(null);
                }}
                key={conference.conferenceId}
                className={`${style.conferencesItem} ${props.navigation.hoveredConference ===
                conference.conferenceId ? style.hoveredConference : ''}`}>
                {conference.name}
              </NavLink>
            )
          }
          return null
        })}
      </div>
      <div
        className={`${style.categories} ${props.navigation.hoveredCategory &&
        props.navigation.conferences.filter(c => c.categoryId === props.navigation.hoveredCategory).length ?
          style.coverFooter : style.defaultPosition}`}>
        {props.navigation.categories.map(category => (
          <NavLink
            activeClassName={style.categoriesItemActive}
            to={`/nav/${category.id}`}
            onMouseEnter={() => {
              props.setHoveredCategory(category.id)
            }}
            onMouseLeave={() => {
              props.setHoveredCategory(null)
            }}
            className={`${style.categoriesItem} ${props.navigation.hoveredCategory ===
            category.id ? style.hoveredCategory : ''}`}
            key={category.id}>
            {category.name}
          </NavLink>
        ))}
      </div>
    </Fragment>
  );
}
export default NavMenu;

