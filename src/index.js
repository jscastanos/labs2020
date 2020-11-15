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

const transformPipe = pipe(trim, toLowerCase, wrap('div'));
console.log(transformPipe(input));
