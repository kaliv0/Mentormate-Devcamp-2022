let successCounter = 0;
//const startTime = Date.now();
let startTime;

function delay(delayTime) {
    startTime = Date.now();

    return new Promise((resolve, reject) => {
        if (Math.random() >= 0.5) {
            setTimeout(() => { resolve(); }, delayTime);

        } else {
            setTimeout(() => { reject(); }, delayTime);
        }
    });
}

function onSuccess() {
    console.log('🎉');
    successCounter++;
};

function onFinalCallEnd() {
    const endTime = Date.now();
    const successPercent = (successCounter / 3) * 100;
    console.log(`Tasks done in ${endTime - startTime}ms! ${successPercent.toFixed(2)}% were completed successfully`);
};

function onFailure() {
    console.log('Whoops! Something went wrong');
}

const shortest = delay(1000)
    .then(onSuccess)
    .catch(onFailure);

const mid = delay(1500)
    .then(onSuccess)
    .catch(onFailure);

const longest = delay(2000)
    .then(onSuccess)
    .catch(onFailure);


Promise.allSettled([shortest, mid, longest]).then(
    () => {
        console.log('final report:')
        onFinalCallEnd();
    }
);