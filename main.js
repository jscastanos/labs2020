const fs = require('fs');
const util = require('util')
const readdir = util.promisify(fs.readdir)

let data = [2, 4, 3];
let result = [];

const read_and_execute = async (folder) => { 
    let files = await readdir(folder); //get all files in the folder

    for await(const file of files){ // loop through all files
        let funcs = require(folder + '/' + file.split('.')[0]) // get exported functions

        for await(const fn of Object.keys(funcs)){ // loop through all exported functions
            await funcs[fn](data, result) // execute func and wait to resolved
            console.log("Solved the " + fn + "!") // print after resolve
        }
    }
}
const delay = ms => new Promise(resolve => setTimeout(resolve, ms)) // fake delay

const print_when_all_done = async () => { // print result
    await delay(3000)

    console.log({
        "result" : result
    })
}

const run = async() => {
    // execute one after another when resolved
    await read_and_execute('./folder1') 
    await read_and_execute('./folder2') 
    await read_and_execute('./folder3') 
    await print_when_all_done() 
}

run();

module.exports.delay = delay