function delay(cb, delayTime) {
    let bool = Math.random() >= 0.5;
    setTimeout(() => { cb(bool) }, delayTime);
}

delay((err) => {
    if (err) {
        console.log('Whoops! Something went wrong');
    } else {
        console.log('🎉');
    }
}, 1000);


