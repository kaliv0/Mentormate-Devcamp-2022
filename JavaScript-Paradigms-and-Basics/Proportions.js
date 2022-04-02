function getRatios(numbers) {

    let positive = 0;
    let negative = 0;
    let zeros = 0;

    numbers.forEach(num => {
        if (num > 0) {
            positive++;

        } else if (num < 0) {
            negative++;

        } else {
            zeros++;
        }
    });

    let result = [];
    
    result.push(Number.parseFloat(positive / numbers.length).toFixed(6));
    result.push(Number.parseFloat(negative / numbers.length).toFixed(6));
    result.push(Number.parseFloat(zeros / numbers.length).toFixed(6));

    return result;
}

const input1 = [1, 1, 0, -1, -1];
const output1 = getRatios(input1);
console.log(output1);

const input2 = [10, 10000, 2888, -19, -2, -888888888888888888];
const output2 = getRatios(input2);
console.log(output2);
