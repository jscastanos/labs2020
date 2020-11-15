import { compose, pipe } from 'lodash/fp';

let input = ' JavaScript   ';
let output = '<div>' + input.trim() + '</div>';

const trim = (str) => str.trim();
const wrapInDiv = (str = `<div>${str}</div>`);
const toLowerCase = (str) => str.toLowerCase();

// compose is equivalent to
// const result = wrapInDiv(toLowerCase(trim(input)))
// but much cleaner
const transform = compose(wrapInDiv, toLowerCase, trim);
transform(input);

// same with compose but the order is flipped
const transformPipe = pipe(trim, toLowerCase, wrapInDiv);
transformPipe(input);
