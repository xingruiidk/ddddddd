// Define variables
let catPaw;
let catTime = 10;
let sauces = [];
let points = [];
let userList = [];
let aiList = [];
let catMoving = false;
let currentIndex = 0;
let MaxMoves = 3;
let CurrentMoves = 0;
let userTurn = false;
let round = 1;
let sec = 90;
let gamestarted = false;
let heartsGO = [];
let hearts = 3;

function startGame() {
    gamestarted = true;
    userTurnFlag = false;
    updateRoundDisplay();
    playSimonSays();
}

// Function to update round display
function updateRoundDisplay() {
    document.getElementById('round-display').innerText = `Round: ${round}`;
}

// Function to play Simon Says
function playSimonSays() {
    aiList = [];
    CurrentMoves = 0;
    catMoving = true;
    for (let i = 0; i < MaxMoves; i++) {
        let randomIndex = Math.floor(Math.random() * 5);
        aiList.push(randomIndex);
        moveCatPaw(randomIndex);
    }
    setTimeout(() => {
        catMoving = false;
        userTurnFlag = true;
    }, catTime * 1000 + 500);
}

// Function to move the cat paw
function moveCatPaw(targetPosition) {
    currentIndex = targetPosition;
    // Assuming there's a function to move the cat paw visually
    // Show sauce at the current position
    // Wait for a short delay to display the sauce
    setTimeout(() => {
        // Hide the sauce
        setTimeout(() => {
            // Wait for another short delay
        }, 500);
    }, 500);
}

// Function for user's turn
function userTurn() {
    userList = [];
}

// Event handler for button clicks
function handleButtonClick(index) {
    if (userTurnFlag) {
        userList.push(index);
        if (userList.length === MaxMoves) {
            if (checkUserInput()) {
                correct();
            } else {
                wrong();
            }
        }
    }
}

// Function to check user input
function checkUserInput() {
    for (let i = 0; i < MaxMoves; i++) {
        if (userList[i] !== aiList[i]) {
            return false;
        }
    }
    return true;
}

// Function for correct input
function correct() {
    // Provide visual/audio feedback for correct input
    alert("Correct!");
    round++;
    updateRoundDisplay();
    playSimonSays();
}

// Function for wrong input
function wrong() {
    // Provide visual/audio feedback for wrong input
    alert("Wrong!");
    hearts--;
    if (hearts === 0) {
        endGame();
    } else {
        playSimonSays();
    }
}

// Function to end the game
function endGame() {
    // Game over logic
    alert("Game Over!");
    gamestarted = false;
}

// Call startGame function to start the game
startGame();function startGame() {
    gamestarted = true;
    userTurnFlag = false;
    updateRoundDisplay();
    playSimonSays();
}

// Function to update round display
function updateRoundDisplay() {
    document.getElementById('round-display').innerText = `Round: ${round}`;
}

// Function to play Simon Says
function playSimonSays() {
    aiList = [];
    CurrentMoves = 0;
    catMoving = true;
    for (let i = 0; i < MaxMoves; i++) {
        let randomIndex = Math.floor(Math.random() * 5);
        aiList.push(randomIndex);
        moveCatPaw(randomIndex);
    }
    setTimeout(() => {
        catMoving = false;
        userTurnFlag = true;
    }, catTime * 1000 + 500);
}

// Function to move the cat paw
function moveCatPaw(targetPosition) {
    currentIndex = targetPosition;
    // Assuming there's a function to move the cat paw visually
    // Show sauce at the current position
    // Wait for a short delay to display the sauce
    setTimeout(() => {
        // Hide the sauce
        setTimeout(() => {
            // Wait for another short delay
        }, 500);
    }, 500);
}

// Function for user's turn
function userTurn() {
    userList = [];
}

// Event handler for button clicks
function handleButtonClick(index) {
    if (userTurnFlag) {
        userList.push(index);
        if (userList.length === MaxMoves) {
            if (checkUserInput()) {
                correct();
            } else {
                wrong();
            }
        }
    }
}

// Function to check user input
function checkUserInput() {
    for (let i = 0; i < MaxMoves; i++) {
        if (userList[i] !== aiList[i]) {
            return false;
        }
    }
    return true;
}

// Function for correct input
function correct() {
    // Provide visual/audio feedback for correct input
    alert("Correct!");
    round++;
    updateRoundDisplay();
    playSimonSays();
}

// Function for wrong input
function wrong() {
    // Provide visual/audio feedback for wrong input
    alert("Wrong!");
    hearts--;
    if (hearts === 0) {
        endGame();
    } else {
        playSimonSays();
    }
}

// Function to end the game
function endGame() {
    // Game over logic
    alert("Game Over!");
    gamestarted = false;
}

// Call startGame function to start the game
startGame();