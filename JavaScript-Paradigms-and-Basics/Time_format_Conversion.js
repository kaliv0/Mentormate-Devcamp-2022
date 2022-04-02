function formatTime(time) {
    let [currTime, delimiter] = time.split(' ');
    let timeArr = currTime.split(':');
    let hour = timeArr[0];

    if (hour === '12' && delimiter === 'AM') {
        hour = '00';
    }
    if (hour !== '12' && delimiter === 'PM') {
        let newHour = parseInt(hour, 10) + 12;
        hour = newHour.toString();
    }

    timeArr[0] = hour;
    return timeArr.join(':');
}

const input1 = "06:15:30 AM";
const input2 = "04:00:00 PM";
const input3 = "12:00:00 AM";
const input4 = "12:00:00 PM";
console.log(formatTime(input1));
console.log(formatTime(input2));
console.log(formatTime(input3));
console.log(formatTime(input4));
