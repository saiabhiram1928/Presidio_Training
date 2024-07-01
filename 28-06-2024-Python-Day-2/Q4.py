# cow_and_bull_game.py

import random

def generate_secret_word():
    # A predefined list of words or generate randomly
    words = ["apple", "banjo", "crane", "drive", "eagle"]
    return random.choice(words)

def get_cows_and_bulls(secret_word, guessed_word):
    cows = 0
    bulls = 0
    secret_word_counts = {}
    guessed_word_counts = {}

    for i in range(len(secret_word)):
        if guessed_word[i] == secret_word[i]:
            bulls += 1
        else:
            secret_word_counts[secret_word[i]] = secret_word_counts.get(secret_word[i], 0) + 1
            guessed_word_counts[guessed_word[i]] = guessed_word_counts.get(guessed_word[i], 0) + 1

    for char in guessed_word_counts:
        if char in secret_word_counts:
            cows += min(secret_word_counts[char], guessed_word_counts[char])

    return cows, bulls

def play_game():
    secret_word = generate_secret_word()
    attempts = 0
    print("Welcome to the Cow and Bull game!")

    while True:
        guessed_word = input("Enter your guess: ")
        if len(guessed_word) != len(secret_word):
            print(f"Your guess must be {len(secret_word)} letters long.")
            continue

        attempts += 1
        cows, bulls = get_cows_and_bulls(secret_word, guessed_word)
        print(f"{bulls} Bulls, {cows} Cows")

        if bulls == len(secret_word):
            print(f"Congratulations! You've guessed the word '{secret_word}' in {attempts} attempts.")
            break

if __name__ == "__main__":
    play_game()
