function reorder(people) {

    people.sort((firstPerson, secondPerson) => {

        let firstPersonCount = getScoreCount(firstPerson);
        let secondPersonCount = getScoreCount(secondPerson);

        if (firstPersonCount === secondPersonCount) {
            return firstPerson.name.localeCompare(secondPerson.name);
        }
        return secondPersonCount - firstPersonCount
    });

    return people;

    function getScoreCount(person) {
        let count = 0;
        person.scores.forEach(score => {
            if (typeof score === "string") {
                score = parseInt(score, 10);
                if (isNaN(score)) {
                    score = 0;
                }
            }
            count += score;
        });
        return count;
    }
}

const input1 = [
    { name: 'Bob', scores: [1, 2, 1] },
    { name: 'Alice', scores: [1, 2, 3] }
];
const input2 = [
    { name: 'Joe', scores: [1, 2, 3] },
    { name: 'Jane', scores: [1, 2, 3] },
    { name: 'John', scores: [1, 2, 3] }
];
const input3 = [
    { name: 'Joe', scores: [1, 2, "4.1"] },
    { name: 'Jane', scores: [1, null, 3] },
    { name: 'John', scores: [1, 2, 3] }
];
const input4 = [
    { name: 'Joe', scores: [1, 2, "4.1"] },
    { name: 'Jane', scores: [1, null, 3] },
    { name: 'John', scores: ["banana", "yes", "no"] }
];

console.log(reorder(input1));
console.log(reorder(input2));
console.log(reorder(input3));
console.log(reorder(input4));

