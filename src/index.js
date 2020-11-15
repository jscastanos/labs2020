import { bugAdded, bugRemoved } from './actions';
import store from './store';

const unsubscribe = store.subscribe(() => {
  console.log('Store changed!', store.getState());
});

store.dispatch(bugAdded('Bug 1'));

unsubscribe();

store.dispatch(bugRemoved(1));

console.log(store.getState());
