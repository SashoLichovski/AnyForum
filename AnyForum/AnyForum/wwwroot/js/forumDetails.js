function ToggleSection(event) {
    var tag = document.getElementById(`replySection-${event.target.id}`);
    var btn = document.getElementById(`${event.target.id}`);
    if (tag.classList.contains("hide")) {
        tag.classList.remove("hide")
        btn.innerText = "hide"
    } else {
        tag.classList.add("hide")
        btn.innerText = "See reply section"
    }
    console.log(event.target.id);
}

function CheckInput(event) {
    //var tag = document.getElementById("commentInput");
    //var btn = document.getElementById()
    console.log(event.target.id)
}