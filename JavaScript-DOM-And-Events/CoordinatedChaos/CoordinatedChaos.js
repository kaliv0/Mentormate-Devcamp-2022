let successCounter = 0;
const startTime = Date.now();

function delay(delayTime) {

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


delay(1000)
    .then(onSuccess)
    .catch(onFailure)
    .finally(() => delay(1000)
        .then(onSuccess)
        .catch(onFailure))
    .finally(() => delay(2000)
        .then(onSuccess)
        .catch(onFailure))
    .finally(() => {
        console.log('final report:')
        onFinalCallEnd();
    });