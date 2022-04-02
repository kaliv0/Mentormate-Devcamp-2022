function delay(delayTime) {
    let myPromise = new Promise((resolve, reject) => {
        if (Math.random() >= 0.5) {
            setTimeout(() => { resolve(); }, delayTime);

        } else {
            setTimeout(() => { reject(); }, delayTime);
        }
    });
    return myPromise;
}

delay(1000)
    .then(() => {
        console.log('🎉');
    })
    .catch(() => {
        console.log('Whoops! Something went wrong');
    });


