import { types } from '../../actions/types';

export default (action, state = []) => {
  switch (action.type) {
    case types.GET_POSTS:
      return action.payload;
    default:
      return state;
  }
};
