import {SET_LANGUAGE} from '../actions/languageActions'

let initialState = {
  categories:[
    {id: 1, name: 'Category1',},
  ]
}
fetch("/language")
  .then(res => res.json())
  .then(
    (result) => {
      initialState = result
    },
    (error) => {
      this.setState({
        error
      });
    }
  )
const languageReducer = (state = initialState, action) => {
  console.log('work')
  switch (action.type) {
    case SET_LANGUAGE:
      let category = {
        id: 10,
        name: action.name
      }
      state.categories.push(category)
      return state;
    default:
      return state;
  }
}
export default navigationReducer;