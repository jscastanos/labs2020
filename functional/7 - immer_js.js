import { produce } from 'immer';

// From using Map immutable
// let book = Map({ title: 'Harry Potter' });

// function publish(book) {
//   return book.set('isPublished', true);
// }

// book = publish(book);

let book = { title: 'Harry Potter' };

function publish(book) {
  return produce(book, (draftBook) => {
    draftBook.isPublished = true;
  });
}

let updated = publish(book);

console.log(book);
console.log(updated);
