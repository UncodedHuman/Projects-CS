const display = document.getElementById("display");
let previousAns = null;
let errorActive = false;
let resultScreen = false;
let equationScreen = false;
let numericSolution = null; 
let formattedSolution = ""; //stored formatted solution as string


function formatting(num){

    let strnum = num.toString();

    if (strnum.includes('.')){ //Removing trailing zeros and decimal
        strnum = strnum.replace(/\.?0+$/, '');
        if (strnum.endsWith('.')) strnum = strnum.slice(0,-1);
    }

    if (strnum.length > 15){
        if (num > 1e15 || num < 1e-15) { //Slice large numbers into 15 characters only
            return num.toExponential(10).slice(0, 15);
        }
        return strnum.slice(0, 15);
    }
    return strnum;
}

function generateEquation(solution) { //Generating random equation from the solution
    const forms = [
        () => { // ax +/- b = c
            const coefficient = Math.floor(Math.random() * 9) + 1;
            const b = Math.floor(Math.random() * 20);
            const operator = Math.random() > 0.5 ? '+' : '-'; //choosing operators and nums
            const c = operator === '+' ? coefficient * solution + b : coefficient * solution - b; //computing right-hand side from generated nums
            return `${coefficient}x ${operator} ${b} = ${formatting(c)}`;
        },

        () => { // (ax)/b = c
            const multiplier = Math.floor(Math.random() * 9) + 1; 
            const divisor = Math.floor(Math.random() * 9) + 1; 
            const c = (multiplier * solution) / divisor; //right hand
            return `(${multiplier}x)/${divisor} = ${formatting(c)}`;
        }
    ];
    return forms[Math.floor(Math.random() * forms.length)](); //cuts down number to lowest int from random generated
}


function appendToDisplay(input, type){
    checkSecretString(input); // check if snaking
    if (errorActive) return;
    if (resultScreen || equationScreen){ // returns to question like normal calculators if operator pressed
        if (type === 'operator'){
         clearDisplay();
         display.value = "ANS"
        }
        else if (type === 'num') clearDisplay();
    }
    

    display.value += input;
    display.scrollLeft = display.scrollWidth;
}

function clearDisplay(){ 
    display.value = "";
    errorActive = false;
    resultScreen = false;
    equationScreen = false;
    display.classList.remove('in_error');
}

function deleteChar(){
    if (errorActive || resultScreen || equationScreen) return;
    display.value = display.value.toString().slice(0,-1); 
}

function fetchAns(){
    if (errorActive) return; 
    if (resultScreen || equationScreen) clearDisplay();
    if (previousAns !== null){
         display.value += "ANS"
    }
    else{
        display.classList.add('in_error');
        display.value = "No previous answers stored\n[AC] to Cancel"
        errorActive = true;
        return;
    }
}

function calculate(){
    try {

        //Handling which screen to return to (equation or solution) to alter
        if (equationScreen) { 
        display.value = formattedSolution;
        equationScreen = false;
        resultScreen = true;
        return;
        }

        if (resultScreen) {
        const solValue = parseFloat(display.value);
        display.value = generateEquation(solValue);
        equationScreen = true;
        resultScreen = false;
        return;
        }


        //Checking for invalid expression
        if (errorActive) return;
        display.classList.remove('in_error');

        const InextOperators = /([+\-*/.]{2,})|(\dANS|ANS\d)/i; //invalid expression since many operators
        if (InextOperators.test(display.value)) throw new Error("Consecutive operators");

        const currentExpression = display.value.replace(/ANS/gi, previousAns);
        let result = eval(currentExpression);
        previousAns = result;
        // Starting to store and formatting results
        numericSolution = result;
        formattedSolution = formatting(result);

        display.value = generateEquation(numericSolution); // Generate if needed
        equationScreen = true;

    } catch (error) {
        display.classList.add('in_error');
        display.value = "Error\n[AC] to Cancel";
        errorActive = true;
        resultScreen = false;
        equationScreen = false;
    }
}

// SNAKE GAME
let secretString = "";
const secretCode = "/*-++-*/"
let isSnake = false;
let intervalTimer = null; // holds the id of interval to control game loop

function checkSecretString(string){
    secretString += string;
    if (secretString.length > secretCode.length){
        secretString = secretString.slice(-secretCode.length) //Keep only the last characters
    }
    if(secretString === secretCode){
        activateSnake();
    }
}

function activateSnake(){
    const calculator = document.getElementById('calculator');
    calculator.classList.add('snake-mode');

    // Generating the canvas for the snake game
    const canvas = document.createElement('canvas');
    canvas.id = 'snake-canvas';
    canvas.width = 300;
    canvas.height = 380;

    const info = document.createElement('div');
    info.id = 'game-info';
    info.innerHTML = 
    `<div>SCORE: <span id="snake-score">0</span></div>`;

    const container = document.createElement('div');
    container.id = "snake-container";

    container.appendChild(info);
    container.appendChild(canvas);
    calculator.appendChild(container);
    
    // Hides calculator
    document.querySelector('.display').style.display = 'none';
    document.querySelector('form').style.display = 'none';

    isSnake = true;
    startSnake(canvas);
}

function startSnake(d){
    const render = d.getContext('2d');
    const grid = 20;
    let score = 0;
    let SPEED = 200;
    const increaseSpeed = 5;
    const maxSpeed = 50;

    document.getElementById('snake-score').textContent = score;

    // snake is an array of segments with coordinates
    let snake = [{x: Math.floor(d.width/grid/2), //initializing mid of grid
                y: Math.floor(d.height/grid/2)}];
    let food;
    do{
        food = {x: Math.floor(Math.random() * (d.width/grid)), //inititizlng randomly and not on top of snake
                y: Math.floor(Math.random() * (d.height/grid))};
    } while (snake.some(segment => segment.x === food.x && segment.y === food.y));
    let dx = 1;
    let dy = 0;

    function draw(){ // The drawing logics (fillStyle() fillRect() beginPath() and arc() were AI aided, I researched and found out the methods using it, then implemented with help
        render.fillStyle = "#111111";
        render.fillRect(0,0,d.width,d.height);

        render.fillStyle = "#4dc952"; //snake
        snake.forEach((segment, index) => {
            if (index === 0){
                render.fillStyle = "#07b350";
            } else{
                render.fillStyle = "#4dc952";
            }
            const x = segment.x * grid;
            const y = segment.y * grid;
            render.fillRect(x, y, grid, grid);
            
            // Add 3D effort inside body
            render.fillStyle = index === 0 ? "#32cd7a" : "#5cd97a";
            render.fillRect(x + 2, y + 2, grid - 4, grid - 4);
        });


        render.fillStyle = '#ff1100'; //food
        render.beginPath();
        render.arc(
            food.x * grid + grid/2, 
            food.y * grid + grid/2, 
            grid/2 - 2, 
            0, 
            Math.PI * 2
        );
        render.fill();

        render.fillStyle = '#ff5555';
        render.beginPath();
        render.arc(
            food.x * grid + grid/3, 
            food.y * grid + grid/3, 
            grid/6, 
            0, 
            Math.PI * 2
        );
        render.fill();
        
        render.fillStyle = '#8B4513';
        render.fillRect(
            food.x * grid + grid/2 - 1, 
            food.y * grid - 3, 
            2, 
            6
        );

        render.fillStyle = '#32CD32';
        render.beginPath();
        render.ellipse(
            food.x * grid + grid/2 + 5, 
            food.y * grid - 1, 
            4, 
            2, 
            Math.PI/4, 
            0, 
            Math.PI * 2
        );
        render.fill();

        document.getElementById('snake-score').textContent = score;
        }
        document.addEventListener('keydown', e => { //Movement function to operate and changing coordinate of snake head
            if (!isSnake) return;
            if (e.key === 'ArrowUp' && dy === 0) {
                dx = 0;
                dy = -1;
            } else if (e.key === 'ArrowDown' && dy === 0) {
                dx = 0;
                dy = 1;
            } else if (e.key === 'ArrowLeft' && dx === 0) {
                dx = -1;
                dy = 0;
            } else if (e.key === 'ArrowRight' && dx === 0) {
                dx = 1;
                dy = 0;
            }
        });

        function movement(){
        const head = {x: snake[0].x + dx, y: snake[0].y + dy};
        snake.unshift(head); //shifting the head to move

        // eating
        if (head.x === food.x && head.y === food.y) {
            let newFood;
            score += 1;
            let collision;
            do {
                newFood = {x: Math.floor(Math.random() * (d.width/grid)), //generating new food once eaten 
                          y: Math.floor(Math.random() * (d.height/grid))};
                collision = snake.some(s => s.x === newFood.x && s.y === newFood.y);
            } while (collision);
            
            food = newFood;

            if (SPEED > maxSpeed) { //Increasing the speed once food is eaten
                SPEED -= increaseSpeed;
                clearInterval(intervalTimer);
                intervalTimer = setInterval(movement, SPEED);
            }
        } else {
            snake.pop(); // delete tail cuz didnt eat
        }


        //collisions
        for (let i = 1; i < snake.length; i++) {
            if (head.x === snake[i].x && head.y === snake[i].y) {
                Over();
                return;
            }
        }
        if (head.x < 0 || head.x >= Math.floor(d.width/grid) 
            || head.y < 0 || head.y >= Math.floor(d.height/grid)) {
            Over();
            return;
        }

        draw();
    }

        function Over(){
            // Cancels the repeated interval timer used
            clearInterval(intervalTimer); //https://developer.mozilla.org/en-US/docs/Web/API/Window/clearInterval
            isSnake = false;

            setTimeout(() => {
                if(confirm (`YA CRASHED! Score: ${score}\n\nPlay again?`)){ // Generating a pop up to ask user
                    const container = document.getElementById('snake-container');
                    container.remove();
                    activateSnake(); 
                }
                else{
                    const container = document.getElementById('snake-container'); //Back to calculator
                    if (container) container.remove();
                    
                    const calculator = document.getElementById('calculator');
                    calculator.classList.remove('snake-mode');
                    
                    document.querySelector('.display').style.display = '';
                    document.querySelector('form').style.display = '';

                    secretString = '';
                    clearDisplay();
                }
            }, 100);
    }
    draw();
    intervalTimer = setInterval(movement, SPEED); // Runs game with repeated interval timer
}