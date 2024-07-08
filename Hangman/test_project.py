from project import (
    get_level,
    hangman_image,
    last_chance,
    mini_chance_arts,
)
import pytest


def test_get_level():
    assert get_level(1) == 1
    assert get_level(10) == 10
    assert get_level(5) == 5
    assert get_level(14) == 14


def test_hangman_image():
    assert (
        hangman_image(1)
        == """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|\\
                                                |       |
                                                |      / \\
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|"""
    )
    assert (
        hangman_image(3)
        == """
                                                _________
                                                |/      |
                                                |      (_)
                                                |      /|\\
                                                |       |
                                                |      
                                                _|_
                                                |   |______
                                                |          |
                                                |__________|"""
    )

    with pytest.raises(ValueError):
        hangman_image(8)
        hangman_image(-1)
        hangman_image("a")
        hangman_image("")


def test_last_chance():
    assert last_chance("ROCK", "PAPER") == False
    assert last_chance("ROCK", "SCISSORS") == True
    assert last_chance("SCISSORS", "PAPER")
    assert last_chance("PAPER", "PAPER") == None
    with pytest.raises(ValueError):
        last_chance("ROCK", "boi")
        last_chance(1, "PAPER")
        last_chance("scissors")


def test_mini_chance_arts():
    with pytest.raises(ValueError):
        mini_chance_arts("ROCK", "boi")
        mini_chance_arts("Paper", "scissors")
    with pytest.raises(ValueError):
        mini_chance_arts(1, "PAPER")
        mini_chance_arts("scissors")

