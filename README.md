# HangMan

A simple C# console-based Hangman game where you can guess letters, track wins/losses, and choose your word source. This project demonstrates clean separation of business logic (the game’s rules and state) from the UI (console interactions).

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [How to Play](#how-to-play)
- [Project Structure](#project-structure)
- [Installation & Running](#installation--running)
- [Contributing](#contributing)
- [License](#license)

## Overview

This repository showcases a console-based Hangman game written in **C#**. The game logic is encapsulated in a separate business logic layer (BLL), making the application easy to maintain and test.

## Features

- **Multiple Word Sources:** Choose automatically generated words or let players input their own.
- **Clear Game State Management:** Tracks remaining attempts, guessed letters, and reveals correct letters in the secret word.
- **Modular Design:** `GameManager` handles the core logic, while UI classes handle user interaction.
- **Easy to Extend:** Swap out or add new implementations for players, word sources, or the UI without touching core logic.

## Technologies Used

- **.NET 8.0** - Latest .NET framework version for building console applications.
- **C#** - Primary programming language.
- **NUnit** - Unit testing framework (in the `Hangman.Test` project).
- **Visual Studio / VSCode** - Recommended IDEs, though any editor and the .NET CLI will work.

## How to Play

1. **Run the Console Application**: You’ll be prompted to pick a word source or input your own.
2. **Guess Letters**: Type a letter each turn.
   - If the letter is in the word, it reveals itself in the correct positions.
   - If not, you lose one of your remaining attempts.
3. **Win or Lose**: Guess all letters before running out of attempts to win!

## Project Structure
- **Hangman.BLL**:  
  Houses the main game logic. The `GameManager` class manages the state of the game, including current word, guesses, and attempts.

- **HangMan.UI**:  
  The console UI that interacts with the user (prompts for guesses, displays results, etc.).  
  Relies on `GameManager` from the BLL.

- **Hangman.Test**:  
  Contains unit tests to verify the business logic independently of the UI.

## Installation & Running

### Option A: Using Visual Studio

1. **Clone the repository**:
   ```bash
   git clone https://github.com/ctoner2652/HangMan.git
2. **Open the solution (HangMan.sln) in Visual Studio.**
3. **Set HangMan.UI as the Startup Project:**
4. **Right-click HangMan.UI in Solution Explorer → Set as Startup Project.**
5. **Run the application (F5 for Debug, Ctrl+F5 for Release).**

### Option B: Using .NET CLI
1. **Clone the repository**:
    ```bash
    git clone https://github.com/ctoner2652/HangMan.git
2. **Go to HangMan.UI folder:**
    ```bash
    cd HangMan/HangMan.UI
3. **Run the console app:**
    ```bash
    dotnet run
