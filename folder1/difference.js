const time = require('../main')

const difference = async (data, result) => {
     let answer = 0;

     for await (const num of data){
        answer -= num
    }

     await time.delay(3000)

     return result.push({
         'operation' : 'subtration',
         'difference' : answer
     })
}

module.exports.difference = difference