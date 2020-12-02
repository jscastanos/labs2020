const time = require('../main')

const sum = async (data, result) => {
    let answer = 0;

    for await (const num of data){
        answer += num
    }

    await time.delay(1000)

    return result.push({
        'operation': 'addition',
        'sum': answer
    })
}

module.exports.sum = sum;