import { pipe } from 'lodash/fp';

let input = ' JavaScript   ';
let output = '<div>' + input.trim() + '</div>';

// const wrapInDiv = (str) => `<div>${str}</div>`;
// const wrapInSpan = (str) => `<span>${str}</span>`;

// currying
// instead of repeating the function
// we simplify it to
const trim = (str) => str.trim();
const wrap = (type) => (str) => `<${type}>${str}</${type}>`;
const toLowerCase = (str) => str.toLowerCase();

// here's a way currying works.
// without this we'll get undefined result for type
// and an error
const transformPipe = pipe(trim, toLowerCase, wrap('div'));
console.log(transformPipe(input));

// currying
// chaining/passing functions instead of adding parameters
function add(a) {
  return function (b) {
    return a + b;
  };
}

// pass a to b and perform the action
const add2 = (a) => (b) => a + b;

// this is how to use the new function
add(1)(5);
