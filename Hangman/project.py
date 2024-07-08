from random import choice
from os import system, name
from time import sleep
from keyboard import is_pressed


Length: int = 0



def main():
    print(
        r"""               
                                 _   _    _    _   _  ____   __  __    _    _   _ 
                                | | | |  / \  | \ | |/ ___| |  \/  |  / \  | \ | |
                                | |_| | / _ \ |  \| | |  _  | |\/| | / _ \ |  \| |
                                |  _  |/ ___ \| |\  | |_| | | |  | |/ ___ \| |\  |
                                |_| |_/_/   \_\_| \_|\____| |_|  |_/_/   \_\_| \_|"""
    )
    print("\nPress space-bar to continue.....")
    is_space_pressed()  # Continuously checking whether a key is pressed
    clear()
    while True:
        global Length
        if Length := get_level(
            input("Enter the number of letters of your word (1 to 14): ")
        ):
            leveled_list = [
                w for w in get_list() if len(w) == Length
            ]  # List will contain only words with certain ammount of letters
            word = choice(leveled_list).upper()
            initialize(word)  # Capitalize random word extracted from list)
            Next_or_not = input("Would you like to play again? (Y/N) ").upper()
            while not (Next_or_not == "Y" or Next_or_not == "N"):
                clear()
                Next_or_not = input("Would you like to play again? (Y/N) ").upper()
            if Next_or_not == "N":
                clear()
                print(
                    r"""      
                       
                                 _____ _                 _                         __            
                                |_   _| |__   __ _ _ __ | |   __  _   _  ___  _ _ / _| ___  _ __ 
                                  | | '_ \ / _` | '_ \| |/ / | | | |/ _ \| | | | | |_ / _ \| '__|
                                  | | | | | (_| | | | |   <  | |_| | (_) | |_| | |  _| (_) | |   
                                 _| |_| |_|\__,_|_| |_|_|\_\  \__, |\___/ \__,_| |_|  \___/|_|   
                                 _              _               |___/       _                      
                                | |_ _ __ _   _(_)_ __   __ _    ___  _   _| |_   _ __ ___  _   _  
                                | __| '__| | | | | '_ \ / _` |  / _ \| | | | __| | '_ ` _ \| | | | 
                                | |_| |  | |_| | | | | | (_| | | (_) | |_| | |_  | | | | | | |_| | 
                                \__|_|   \__, |_|_| |_|\__, |  \___/ \__,_|\__| |_| |_| |_|\__, | 
                                 ____ ___|___/_   ___  |___/             _           _   _ |___/  
                                / ___/ ___| ___| / _ \   _ __  _ __ ___ (_) ___  ___| |_| |       
                                | |   \___ \___ \| | | | | '_ \| '__/ _ \| |/ _ \/ __| __| |       
                                | |___ ___) |__) | |_| | | |_) | | | (_) | |  __/ (__| |_|_|       
                                \____|____/____/ \___/  | .__/|_|  \___// |\___|\___|\__(_)       
                                                        |_|           |__/                        """
                )
                break

def get_list():
    List_Words = []
    with open("words.txt", "r") as file:
        for line in file:
            List_Words.append(line.strip())
    return List_Words


def clear():
    system(
        "cls" if name == "nt" else "clear"
    )  # Clears the terminal screen depending on operating system


def is_space_pressed():
    while True:
        if is_pressed("space"):
            while is_pressed("space"):
                pass  # Avoid detecing multiple space-bars
            try:
                # For Windows and Unix-like systems (including macOS)
                if name == "nt":
                    from msvcrt import kbhit, getch
                    while kbhit():
                        getch()
                else:
                    from sys import stdin
                    from termios import tcflush, TCIOFLUSH

                    tcflush(stdin, TCIOFLUSH)
            except ImportError:
                pass
            break
        sleep(0.01)


def get_level(Level=None):
    try:
        Level = int(Level)
        if 0 < Level <= 14:
            return Level  # Returns the length of the words to challenge
        else:
            raise ValueError
    except (ValueError, TypeError):
        clear()
        print("Please ensure length is 1 to 14")  # Handling invalid length
        pass


def initialize(w):
    guessed = False
    playing_word = "_" * Length
    letters_out = []
    words_out = []
    guesses = 7
    is_chance_used = False
    clear()
    print("Hangman game started!")
    print(hangman_image(guesses), "\n", playing_word, end="\n")
    # Showing the hiden word in encrypted
    while not guessed and guesses != 0:  # playing starts
        try:
            print(f"\nGuessed letters: {letters_out}")
            print(f"Guessed words: {words_out}")
            guess = str(input("\nGuess a letter or a word: ")).upper().strip()
            if len(guess) == 1 and guess.isalpha():  # if guess is letter
                if guess in letters_out:
                    clear()
                    print(f"{guess} is already guessed!")  # if guessed
                elif guess not in w:
                    clear()
                    print(f"{guess} isn't in the word!")
                    guesses -= 1
                    letters_out.append(guess)
                else:
                    clear()
                    print(f"{guess} is in the word!")
                    letters_out.append(guess)
                    temp_list = list(playing_word)
                    for x in [
                        i
                        for i, letter_in_word in enumerate(w)
                        if letter_in_word == guess
                    ]:  # This lines append index into a list if letter is guessed correctly
                        temp_list[x] = (
                            guess  # Changing the underscore to the correctly guessed letter
                        )
                    playing_word = "".join(temp_list)
                    # after appending all guesses and underscores into temp_list, we join back into variable playing_word
                    if "_" not in playing_word:
                        guessed = True  # Signalling that game is won
            elif len(guess) == len(w) and guess.isalpha():
                if guess in words_out:
                    clear()
                    print(f"'{guess}' is already guessed!")
                elif guess != w:
                    clear()
                    print(f"{guess} is the wrong word!")
                    guesses -= 1
                    words_out.append(guess)
                else:
                    clear()
                    guessed = True
                    playing_word = w
            else:
                raise ValueError
            if guesses == 0 and not is_chance_used:
                clear()
                rescue = (
                    input(
                        "You lost, but do you want to play scissors, paper, rock for another chance? (Y/N) "
                    )
                    .upper()
                    .strip()
                )
                while not (rescue == "Y" or rescue == "N"):
                    clear()
                    rescue = (
                        input(
                            "You lost, but do you want to play scissors, paper, rock for another chance? (Y/N) "
                        )
                        .upper()
                        .strip()
                    )
                if rescue == "Y":  # Making sure user enters input correctly
                    while True:
                        Options = ("SCISSORS", "PAPER", "ROCK")
                        player = ""
                        while player not in Options:
                            player = input(
                                "\nWhat are you choosing? (Rock, Paper, Scissors): "
                            ).upper()
                        Game = last_chance(player, choice(Options)) 
                        if Game == True:
                            guesses = 1
                            is_chance_used = True
                            break
                        elif Game == None:
                            pass
                        else: 
                            break
            if not guesses == 0:
                print(hangman_image(guesses), "\n", playing_word, end="\n")
        except ValueError:
            print("\nNot Valid, please enter a letter or a word.")
            pass
    if guessed:
        clear()
        print(
            r"""
                         __   __           __        __          _ 
                        \ \ / /__  _   _  \ \      / /__  _ __ | |
                         \ V / _ \| | | |  \ \ /\ / / _ \| '_ \| |
                          | | (_) | |_| |   \ V  V / (_) | | | |_|
                          |_|\___/ \__,_|    \_/\_/ \___/|_| |_(_)
                      """
        )
        print(f"The word was '{w}'!")
    else:
        clear()
        print(hangman_image(0))
        print(
            r"""
                        __   __            _              _   _ 
                        \ \ / /__  _   _  | |    ___  ___| |_| |
                         \ V / _ \| | | | | |   / _ \/ __| __| |
                          | | (_) | |_| | | |__| (_) \__ \ |_|_|
                          |_|\___/ \__,_| |_____\___/|___/\__(_)
                      """
        )
        print(f"The word was '{w}'!")


def hangman_image(guess_left):
    try:
        frames = [  # stage 1
            """
                                                _________
                                                |/      |
                                                |      
                                                |      
                                                |      
                                                |      
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 2
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      
                                                |      
                                                |      
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 3
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |       |
                                                |       |
                                                |      
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 4
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|
                                                |       |
                                                |      
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 5
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|\\
                                                |       |
                                                |      
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 6
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|\\
                                                |       |
                                                |      / 
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 7
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|\\
                                                |       |
                                                |      / \\
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|""",
            # stage 8
            """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|\\
                                                |       |
                                                |      / \\
                                                _|_
                                                |   |______
                                                |     GAME OVER!
                                                |__________|""",
        ]
        if 0 <= guess_left <= 7:
            return frames[7 - guess_left]
        else:
            raise IndexError
    except (IndexError, ValueError):
        raise ValueError("Invalid number of guesses left.")


def last_chance(player_input, computer_input):
    try:
        if player_input not in ("SCISSORS", "PAPER", "ROCK") or computer_input not in (
            "SCISSORS",
            "PAPER",
            "ROCK",
        ):
            raise ValueError
        mini_chance_arts(player_input, computer_input)
        if (
            (player_input == "SCISSORS" and computer_input == "ROCK")
            or (player_input == "ROCK" and computer_input == "PAPER")
            or (player_input == "PAPER" and computer_input == "SCISSORS")
        ):
            print("\nToo bad!")
            sleep(3)
            return False
        elif player_input == computer_input:
            print("\nA tie! Let's try again!")
            return None
        else:
            print(
                "\nYou won the minigame! You get another chance! Press space-bar to continue....."
            )
            is_space_pressed()
            clear()
            return True
            # Comparing choices between player and computer and returns "True" or "False" accordingly
    except (ValueError, IndexError):
        raise ValueError("Input to function not in rock, paper, scissors")


def mini_chance_arts(input_player, input_computer):
    rock = [
        """             
         _______
      ---'   ____)
            (_____)
            (_____)
            (____)
      ---.__(___)
                """,
        """     
                 _______
                (____   '---
               (_____)
               (_____)
                (____)
                 (___)__.---
                 """,
    ]

    scissors = [
        """
            _______
        ---'   ____)____
                  ______)
               __________)
              (____)
        ---.__(___)
                """,
        """
                 _______
            ____(____   '---
           (______
           (__________
                 (____)
                  (___)__.---
                    """,
    ]

    paper = [
        """
                 _______
            ---'    ____)____
                       ______)
                      _______)
                     _______)
            ---.__________)
                        """,
        """
                 __________
                (__________ '---
              (_______
             (_______
             (__________ 
                    (_______.--- 
                        
                        """,
    ]
    try:
        if input_player not in ("SCISSORS", "PAPER", "ROCK") or input_computer not in (
            "SCISSORS",
            "PAPER",
            "ROCK",
        ):
            raise ValueError
    except (ValueError, IndexError, TypeError):
        raise ValueError("Input to function not in rock, paper, scissors")
    sleep(1)
    clear()
    print("\nScissors..........\n")
    print(rock[0], "            ", rock[1])
    sleep(1)
    clear()
    print("\nPaper.............\n")
    print(rock[0], "            ", rock[1])
    sleep(1)
    clear()
    print("\nRock!!!\n")
    if input_player == "ROCK":
        if input_computer == "ROCK":
            print(
                "\nYour choice:",
                "                 ",
                rock[0],
                "\nComputer's choice:",
                "            ",
                rock[1],
            )
        elif input_computer == "PAPER":
            print(
                "\nYour choice:",
                "                 ",
                rock[0],
                "\nComputer's choice:",
                "            ",
                paper[1],
            )
        else:
            print(
                "\nYour choice:",
                "                 ",
                rock[0],
                "\nComputer's choice:",
                "            ",
                scissors[1],
            )
    elif input_player == "PAPER":
        if input_computer == "ROCK":
            print(
                "\nYour choice:",
                "                 ",
                paper[0],
                "\nComputer's choice:",
                "            ",
                rock[1],
            )
        elif input_computer == "PAPER":
            print(
                "\nYour choice:",
                "                 ",
                paper[0],
                "\nComputer's choice:",
                "            ",
                paper[1],
            )
        else:
            print(
                "\nYour choice:",
                "                 ",
                paper[0],
                "\nComputer's choice:",
                "            ",
                scissors[1],
            )
    else:
        if input_computer == "ROCK":
            print(
                "\nYour choice:",
                "                 ",
                scissors[0],
                "\nComputer's choice:",
                "            ",
                rock[1],
            )
        elif input_computer == "PAPER":
            print(
                "\nYour choice:",
                "                 ",
                scissors[0],
                "\nComputer's choice:",
                "            ",
                paper[1],
            )
        else:
            print(
                "\nYour choice:",
                "                 ",
                scissors[0],
                "\nComputer's choice:",
                "            ",
                scissors[1],
            )


if __name__ == "__main__":
    main()
