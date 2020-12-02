import { Map } from 'immutable';

// From this code
// let book = { title: 'Harry Potter' };

// function publish(book) {
//   book.isPublished = true;
// }

// publish(book);

// using Map immutable
let book = Map({ title: 'Harry Potter' });

function publish(book) {
  return book.set('isPublished', true);
}

book = publish(book);

console.log(book.toJS());
