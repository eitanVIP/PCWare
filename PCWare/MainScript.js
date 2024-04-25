const targetWord = "game";
let currentInput = "";
let timeoutId;

function checkWord() {
    if (currentInput === targetWord) {
        window.location.href = "Game.aspx";
    }
}

function resetInput() {
    currentInput = "";
}

document.addEventListener("keydown", function (event) {
    const key = event.key.toLowerCase();

    if (/^[a-z]$/.test(key)) {
        currentInput += key;
        checkWord();
        clearTimeout(timeoutId);
        timeoutId = setTimeout(resetInput, 500);
    }
});

timeoutId = setTimeout(resetInput, 500);