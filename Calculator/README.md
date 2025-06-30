# _Final Project for CS50x_
![Banner](https://i.ibb.co/V0FqzSLy/SWAG-Calculator.png)

![Javascript Language](https://img.shields.io/badge/Javascript-darkblue?logo=Javascript&logoColor=white&logoSize=5&label=made%20in)
![HTML & CSS Language](https://img.shields.io/badge/HTML&CSS-darkorange?logo=HTML&logoColor=white&logoSize=5&label=made%20in)

![Build Status](https://img.shields.io/badge/v0.1-yellow?label=ver)

# Video Demo
> https://www.youtube.com/watch?v=hlkZNjkgLak



## What's is it?
The project is an interactive calculator but with a twist and secret function (game!). Randomly generating equations upon getting answers (desgined as a fun second step) and unlocks a snake game upon receiving a secret sequence of characters.

### **Project structure:**

- index.js
- index.html
- styles.css
- README.md
> index.js contains the logics, index.html contains the webpage structure for calculator and styles.css is the asthetics customizations needed for the app to function

# Libraries / Objects or Methods
Highlights only the important ones. The particular methods being implemented would be put as foot note. 
1. [**MATH**](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math) : A namespace object contains static properties and methods for mathematical constants and functions. [^1]
2. [**CanvasRenderingContext2D**](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D) : part of the ==[**Canvas API**](https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API)==, provides the 2D rendering context for the drawing surface of a ==[**<canvas>**](https://developer.mozilla.org/en-US/docs/Web/HTML/Reference/Elements/canvas)== element. It is used for drawing shapes, text, images, and other objects. [^2]
4. [**Window**](https://www.w3schools.com/jsref/obj_window.asp): The window object represents an open window in a browser.  [^3]
5. Addtional methods [^4]


[^1]: with [Math.toExponential()](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Number/toExponential), [Math.floor()](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/floor) and [Math.random()](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Math/random)
[^2]: with [ getContext()](https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement/getContext), [fillStyle](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillStyle), [fillRect()](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillRect), [beginPath()](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/beginPath), [arc()](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/arc) and [elipse()](https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/ellipse)
[^3]: with [clearInterval()](https://developer.mozilla.org/en-US/docs/Web/API/Window/clearInterval), [setTimeout()](https://developer.mozilla.org/en-US/docs/Web/API/Window/setTimeout) and [confirm()](https://developer.mozilla.org/en-US/docs/Web/API/Window/confirm)
[^4]: [classList property methods](https://www.w3schools.com/jsref/prop_element_classlist.asp), [Array.unshift()](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array/unshift) and [Array.pop()](https://www.w3schools.com/jsref/jsref_pop.asp)

# Usage
>When operating (right click index.html) ```Open with Live Server```

# Calculator!
![startscreen](https://i.ibb.co/1tcMTNJq/Screenshot-2025-06-30-104241.png)
User greeted with a usual calculator interface, any *operators* and *numbers* can be pressed and added to display.

![equationScreen](https://i.ibb.co/d0B9CPM2/Screenshot-2025-06-30-105928.png)
Once *"="* is pressed, a randomly generated equation is shown instead of the answer. This is the **EQUATION SCREEN** (additional feature implemented).

![ansscreen](https://i.ibb.co/tpNK5Frc/Screenshot-2025-06-30-110152.png)
If pressed again, real answer shown. This is repeated if *"="* is clicked.

Else, the calculator functions normally,
Example showing normal operations of a calculator.
![playing](https://s14.gifyu.com/images/bHZL7.gif)

Operators all works 
>**AC**: clears display.
>**DEL**: deletes previous character
>**ANS**: stores previous answer
>**/**, **x**, **-**, **+** and **=**: mathematical operators


## Snake Game!
Game is activated *only if* user enter this sequence of characters consecutively : **"/ x - + + - x /"**

![initialize](https://s14.gifyu.com/images/bHZkq.gif)

Mini-game **start**, user move using *arrow keys* to move the snake. Eating the apple with increases the score, but also length and speed of snake.

![snakegame](https://s14.gifyu.com/images/bHZvZ.gif)
>Google snake game: https://www.google.com/search?q=snake+game


### Restart or rest:
Once game ended, calls for a choice to play again or not
- If **OK**: Restarts snake game and score
- If **Cancel**: Reset back to calculator screen.



# All functions
index.js contains 13 functions

## formatting(num)
- Function is used *convert* number to string.
- **Remove** trailing zeros and decimal of number.
- **Slice** only the *last sequence of characters* entered.
- **Format** large numbers.


## generateEquation(solution)
When *solution* is taken in, then generates either of the two forms of algebraic equations with **x** as the real answer: 

- ax +/- b = c
- (ax)/b = c

Utilizing [formatting()](#formattingnum). The form is then returned cutting down to nearest int.

## appendToDisplay(input, type):
- Runs **checkSecretString()** [Ref](#checksecretstringstring) to check if snake game has started.
- **Depending** on the current screen (Error, Result or Equation), *returns immediately* or *allow appending* into a new display. 

## clearDisplay()
**Resets** display and screen states.

## deleteChar()
**Deletes** the **last** character on display.

## fetchAns()
Add currently stored **ANS** or display error screen.

## calculate():
Checking to see whether currently on *equationScreen* or *resultScreen* to know which to swap to.

If on:
- **equationScreen**: set display to real answer and state to *resultScreen*.
- **resultScreen**: runs [generateEquation()](#generateequationsolution) with the float value of the answer. Set to *equationScreen* and display the equation generated.

![checkerrors](https://i.ibb.co/chZ2crmw/carbon-1.png)

> The function checks for invalid expressions entered. e,g: consecutive operators using regex checking. If passes, replaces the **ANS** with stored answer and runs [eval()](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/eval) to return the answer.
- Stores answer and [formatting()](#formattingnum) it.
- If an *error* is caught: change state to **errorActive** and display message.

## checkSecretString(string)
- Continuously add character appended to secretString and see if **secretCode** is matched (if so runs [activateSnake()](#activatesnake).
>This is done by slicing only last sequence of characters if display value goes outside *secretCode's* length.

## activateSnake()
This function **transform** the calculator into the *format* of the snake game. This is done by:
1. *Enables* Snake Mode: Adds *snake-mode class* to calculator for visual transformation
2. Creates Game Elements with a **canvas** (300x380) for game rendering and a score display **container**

![canvas for snake game](https://i.ibb.co/R4spJZFM/Screenshot-2025-06-30-153809.png)
3. **Hides** Calculator UI: Conceals display and buttons
4. Initializes Game: Calls [startSnake()](#startsnaked) with the canvas to begin gameplay


## startSnake(d)
*Main core* function of the game. Takes in parameters **d** which is the canvas of the snake game.
- *Intitialize* variables to rendering context *2D*, grid, score, speed, constant speed increase and max possible speed. 
- *Initialize*s the snake as an *array with one segment* (the snake's head). Generates *food* at a **random** position on the grid.

![code](https://i.ibb.co/twFMM4YH/carbon-2.png)

- *Contains and coordinate* [draw()](#draw()), [movement()](#movement) and [Over()](#over). Then runs the game with a repeated interval timer.

## draw()
- **Clear** the canvas with a dark background for each frame.
- *Drawing snake*: *looping* over each segment of the snake and *draws* outer rectangle and a smaller inner rectangle. 
>With head and body different colors.
- *Draw food*: draw red circle with inner glow then brown stem and leaf. [Ref](#startsnaked)
- Handles keyboard arrow keys to **change snake direction** and preventing reversing direction.

## movement()
- *Calculates* the new head position then adds new head at the start of the snake array to *move forward* (deletes tail on the way).
- *Check* if food is eaten then either add score (and increases speed if not **maxSpeed** is reached) or generate new.
- *Check* for collisions with body or with the walls, if yes, triggers [Over()](#over).

## Over()
- Stops game loop by clearing interval timer.
- Show **'Game over'** pop-up.

If user clicks:
- Ok: *triggers* [activateSnake()](#activatesnake).
- Cancel: *remove* the snake-container and restores the UI of **Calculator**.

>In **index.html** is the initial display of the calculator and in **styles.css** is all the visual formatings and stylings.
# So Long....
``` _____ _     _      __        __           ____ ____ ____   ___       _ 
|_   _| |__ (_)___  \ \      / /_ _ ___   / ___/ ___| ___| / _ \__  _| |
  | | | '_ \| / __|  \ \ /\ / / _` / __| | |   \___ \___ \| | | \ \/ / |
  | | | | | | \__ \   \ V  V / (_| \__ \ | |___ ___) |__) | |_| |>  <|_|
  |_| |_| |_|_|___/    \_/\_/ \__,_|___/  \____|____/____/ \___//_/\_(_)
  ```

Thank you so much for taking a look at my project. Thank you the whole CS50x team for this experience!

## Written by: Son Thanh Nguyen
https://github.com/UncodedHuman
https://profile.edx.org/u/BrightLight07