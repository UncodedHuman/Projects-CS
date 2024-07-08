# _Final Project for CS50P_
![Banner](https://i.ibb.co/fQ8DkBg/Hangman-Project.png)
![Python Language](https://img.shields.io/badge/Python-darkblue?logo=Python&logoColor=white&logoSize=5&label=made%20in)
![Build Status](https://img.shields.io/badge/v0.1-orange?label=ver)

# Video Demo
> https://youtu.be/S6gXRAdIwbk



## What's is it?
The project is an interactive game, spliting into two parts, main and mini-game.

### **Project structure:**

- project.py
- test_project.py
- requirements.text
- README.md
- words.txt 
> words.txt contains a [list of 3000 most common English words](https://www.ef.edu/english-resources/english-vocabulary/top-3000-words/) to import for usage in project.py

# Libraries
To be installed by running this pip command:
```pip install -r requirements.txt```
1. [**RANDOM**](https://docs.python.org/3/library/random.html) : This module implements pseudo-random number generators for various distributions. [^1]
2. [**TIME**](https://docs.python.org/3/library/time.html) : This module provides various time-related functions. [^2]
3. [**KEYBOARD**](https://pypi.org/project/keyboard/) 0.13.5: Take full control of your keyboard with this small Python library. [^3]
4. [**OS**](https://docs.python.org/3/library/os.html#module-os): This module provides a portable way of using operating system dependent functionality.  [^4]

Libraries that will install depending on the user's operating system:
1. [**MSVCRT**](https://docs.python.org/3/library/msvcrt.html): These functions provide access to some useful capabilities on Windows platforms. [^5]
2. [**SYS**](https://docs.python.org/3/library/sys.html#module-sys): This module provides access to some variables used or maintained by the interpreter and to functions that interact strongly with the interpreter. [^6]
3. [**TERMIOS**](https://docs.python.org/3/library/termios.html#module-termios): This module provides an interface to the POSIX calls for tty I/O control. (Unix versions) [^7]

[^1]: with [random.choice()](https://docs.python.org/3/library/random.html#random.choice)
[^2]: with [ time.sleep()](https://docs.python.org/3/library/time.html#time.sleep)
[^3]: with [keyboard.is_pressed()](https://github.com/boppreh/keyboard?tab=readme-ov-file#keyboard.is_pressed)
[^4]: with [os.system()](https://docs.python.org/3/search.html?q=os.system) and [os.name()](https://docs.python.org/3/search.html?q=os.system)
[^5]: with [msvcrt.kbhit()](https://docs.python.org/3/library/msvcrt.html#msvcrt.kbhit) and [msvcrt.getch()](https://docs.python.org/3/library/msvcrt.html#msvcrt.getch)
[^6]: with [sys.stdin()](https://docs.python.org/3/library/sys.html#sys.stdin)
[^7]: with [termios.tcflush()](https://docs.python.org/3/library/termios.html#termios.tcflush) and TCIOFLUSH in queue.
# Usage
>When running ```python project.py```

## Hangman
![startscreen](https://i.ibb.co/1d179RP/Screenshot-2024-07-08-104510.png)
Any key aside from *spacebar* is rejected, until *spacebar* is pressed. Exit with *Ctrl + C*

![input](https://i.ibb.co/qW7rDTJ/Screenshot-2024-07-08-104925.png)

Screen cleared, repeatedly asking for input until **1-14** is inputted.

Game play **starts**, user continuously enter a guess (a letter or word) until out of tries.

![ScreenRecording](https://private-user-images.githubusercontent.com/109835189/346509415-0998c89b-161d-4ffe-9ba9-2905f3632f45.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjA0MzE4MTksIm5iZiI6MTcyMDQzMTUxOSwicGF0aCI6Ii8xMDk4MzUxODkvMzQ2NTA5NDE1LTA5OThjODliLTE2MWQtNGZmZS05YmE5LTI5MDVmMzYzMmY0NS5naWY_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjQwNzA4JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI0MDcwOFQwOTM4MzlaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT01OGM2OWUxZWMyMTZmNjk3YjU0ZTE4NTUyYTg2MmNhNDkxY2IzZTFhMzVjNzExMjZjMTUwYjBhZTJiNDBlZWFlJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCZhY3Rvcl9pZD0wJmtleV9pZD0wJnJlcG9faWQ9MCJ9.k1TRyyJ7Hx1V83M2GZeFz95a9ZKglYJY8SrBRZ9mhFY)

If game is won, user will be asked whether they would like to play again. 


## Scissors, Paper, Rock
If game is lost, program asks whether to activate a mini-game.

![initialize](https://i.ibb.co/pr72P05/Screenshot-2024-07-08-114244.png)

Mini-game **start**, user is asked to input "rock", "paper", or "scissors". Then computer's choice and player's choice is compared and animated.
![ScreenRecording](https://github-production-user-asset-6210df.s3.amazonaws.com/109835189/346518026-89c153b9-f574-449d-b338-3b7dce3c8006.gif?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAVCODYLSA53PQK4ZA%2F20240708%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20240708T100522Z&X-Amz-Expires=300&X-Amz-Signature=652054fd9b1c644320a1b48d7ae14fff968d6a00f299d83f8b5824b13c96720d&X-Amz-SignedHeaders=host&actor_id=109835189&key_id=0&repo_id=825364727)
### Depending on result:
- If **won**: User gets another try in their hangman game (sent back to hangman)
- If **tied**: User is prompted again for another choice (mini-game repeated)
- If **lost**: Directed to "You Lost!" screen 

![youlost](https://i.ibb.co/tYHZnBW/Screenshot-2024-07-08-121116.png)
If user don't want to play again, they're presented a "Thank you" screen.


# All functions
> project.py contains 9 functions *(including main())*. 4 are testable in test_project.py

## main()
- Function is used to initialize startscreen. [Ref](#hangman)
- Runs **is_space_pressed()** [Ref](#isspacepressed) and get_level(*Getting input from user*) [Ref](#getlevellevelnone)
- Generates **leveled_list** containing all words same length as inputted from user and select one randomly, storing in **word**.
- **initilize()** the Hangman game.
- Check whether user would like to play again, continuouesly clearing out terminal with **clear()**. Repeatedly asking until receving "Y" or "N". If "Y" **runs again**. If "N":

![no](https://i.ibb.co/CKHQwhJ/Screenshot-2024-07-08-164026.png)

## get_list()
 Creates a list, then reads **words.txt** while appending items into list (items seperated by lines). Returns the list.

## clear():
Function clears terminal screen, if operating system is:
- Window: cls
- MacOS or Linux: clear

## is_space_pressed()
Check whether spacebar is pressed, clears all the junk-inputs prior to a spacebar.
- Window: import msvcrt library. While there is key press (not space), prevent returning key to console.
- MacOS and Linux: import sys and termios. Flushes the input and output queues in terminal I/O.

## get_level(Level=None)
Checks data-type of Level, then check whether level is within range 1-14.
> Repeats in-case ValueError or TypeError, clearing out terminal, reprompt user and pass current input.

## inititalize(w)
Main core function of the game. Takes in parameters **w** which is word for playing.
- Intitialize variables to stores guessed letters, words, playing word needed, etc.
- **clear()**
- Repeatedly runs and prints out the **hangman_image()** according to the stage player is in.
- Also prints out the guessed words and letters in **letters_out** and **words_out**
- Checks whether user enters a letter or words, and appends accordingly to lists created above. If not **is.alpha()** or length of words (guess and from program) don't match, rejects and reprompt.
-- For letters: Checks whether letter is guessed, if not, check whether letter is in word or not.
-- For words: Checks whether word is guessed and wrong, if not, check length, if correct, declares win.
> Actions: 1.Reprompt if letters/words are guessed.
2.If letters not guessed and wrong, append to **letters_out**, 3.Else, append anyways and replaces the underscore inside **playing_word**.
4.If length word is wrong, raise **ValueError** and *pass*. 5. **guessed** == True if word is correct.
- If runs out of guesses and **not is_chance_used**, check whether user wants to play mini-game.
- If yes: activates **last_chance()** and handles results accordingly. If win, rollback one more chance, if tie, redo. If lost, breaks. [Here](#scissors-paper-rock)
- Iff **guesses** == 0 meaning lost, print lost frame from **hangman_image()**
- When game ends, print **"You Won"** or **"You Lost"** accordingly.

## hangman_image(guess_left)
Stores different frames of **Hangman-stages**

![examples](https://i.ibb.co/X450BQH/carbon-1.png)

> Example: Stage 1 (7 guesses left)

Taking in the amount guesses left and returns the according frame. In-case of IndexError or ValueError, raise.

## last_chance(player_input, computer input)
- Checks whether the inputs are valid, if not raise ValueError (in ("SCISSORS", "PAPER", "ROCK")).
- Runs **mini_chance_arts(player_input, computer_input)** and output the accordingly arts of scissors, paper, rock.
- Check the result of the game by comparing **player_input and computer_input**. Returns True, False or None accordingly.
- In-case of ValueError, raise Error message for programmer.

## mini_chance_arts(input_player, input_computer)
Stores different frames of **Mini-game-stages**.

![image](https://i.ibb.co/Ch1X23G/carbon-2.png) 

with lists, element [0] for player's input, element [1] for computer's input.
- Again raise Errors if inputs not in Options ("SCISSORS", "PAPER", "ROCK")
- Runs **sleep()** and print to create animation with wait time: "Scissors... Paper.... Rock!!!"
- Depending on **input_player** and **input_computer**, prints out the according images.



# So Long....
``` _____ _     _                            ____ ____ ____   ___  ____  _ 
    |_   _| |__ (_)___  __      ____ _ ___   / ___/ ___| ___| / _ \|  _ \| |
      | | | '_ \| / __| \ \ /\ / / _` / __| | |   \___ \___ \| | | | |_) | |
      | | | | | | \__ \  \ V  V / (_| \__ \ | |___ ___) |__) | |_| |  __/|_|
      |_| |_| |_|_|___/   \_/\_/ \__,_|___/  \____|____/____/ \___/|_|   (_)
```

Thank you so much for taking a look at my project. Thank you the whole CS50P team for this experience!

## Written by: Son Thanh Nguyen
https://github.com/UncodedHuman

https://profile.edx.org/u/BrightLight07