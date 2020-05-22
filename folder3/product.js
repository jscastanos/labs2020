const time = require('../main')

const product = async (data, result) => {
    let answer = 1;

    for await (const num of data){
        answer *= num
    }

    await time.delay(3000)

    return result.push({
        'operation' : 'multiplication',
        'product' : answer
    })
}

module.exports.product = product;