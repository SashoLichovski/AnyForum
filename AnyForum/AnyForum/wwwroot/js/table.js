function ToggleDetails(event) {
    var tag = document.getElementById(`row-${event.target.id}`);
    var btn = document.getElementById(`${event.target.id}`);
    if (tag.classList.contains("hide")) {
        tag.classList.remove("hide")
        btn.innerText = "hide"
    } else {
        tag.classList.add("hide")
        btn.innerText = "Details"
    }
    console.log(event.target.id);
}