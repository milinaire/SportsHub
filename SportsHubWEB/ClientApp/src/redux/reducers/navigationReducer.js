import {ADD_CATEGORY} from '../actions/navigationActions'

let initialState = {
  categories:[
    {id: 1, name: 'Category1',},
  ]
}
const navigationReducer = (state = initialState, action) => {
  console.log('work')
  switch (action.type) {
    case ADD_CATEGORY:
      return {...state, categories: [...state.categories, {id: 10, name: action.name}]};
    default:
      return state;
  }
}
export default navigationReducer;