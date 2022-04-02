let actionTags = document.querySelectorAll("a");

for (const action of actionTags) {
    action.addEventListener("click", onClick);
}

function onClick(event) {
    event.preventDefault();
    let currAction = event.target;
    let urlBar = document.getElementById("url-bar");

    actionTags.forEach(action => {
        if (action === currAction) {
            action.className = "active";
        } else {
            action.className = "";
        }
    });

    urlBar.innerText = currAction.href;
}