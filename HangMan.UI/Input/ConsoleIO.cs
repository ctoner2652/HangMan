using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Enum;
using Hangman.BLL.Implementations;
using Hangman.BLL.Interfaces;

namespace HangMan.UI.Input
{
    public static class ConsoleIO
    {
        public static IPlayer GetPlayerType(int playerNumber)
        {
            System.Console.WriteLine($"Is player {playerNumber} a (h)uman or (c)omputer?");
            string reply = System.Console.ReadLine().ToUpper();
            if(reply == "H")
            {
                return new HumanPlayer();
            }
            else 
            {
                    return new ComputerPlayer();
            }
        }

        public static string GetPlayerName(int playerNumber)
        {
            System.Console.WriteLine($"Enter player {playerNumber}'s name:");
            return System.Console.ReadLine();
        }

        public static IWordSource GetWordSource(string name)
        {
            System.Console.WriteLine($"{name}, how would you like to choose your words?\r\n\r\n1. I will choose the word.\r\n2. Pick a random word from the dictionary for me.");
            var result = System.Console.ReadLine();
            if(result == "1")
            {
                return new Hangman.BLL.Implementations.Console();
            }
            else
            {
                return new Dictionary();
            }
        }

        public static void DisplayRound(int livesLeft, List<string> guesses, List<string> wordStatus)
        {
            System.Console.WriteLine($"Strikes Remaining: {livesLeft}");
            System.Console.Write("Previous Guesses: ");
            foreach (var guess in guesses) {
                System.Console.Write(guess + ",");
            }
            System.Console.WriteLine();
            System.Console.Write("Word: ");
            foreach(var letter in wordStatus)
            {
                System.Console.Write(letter + " ");
            }
            System.Console.WriteLine();
        }

        internal static void DisplayGuessResult(GuessResponse guessResponse, int correctLetters, string guesserName, string otherPlayerName, string correctWord)
        {
            switch (guessResponse)
            {
                case GuessResponse.Correct:
                    System.Console.WriteLine($"We found {correctLetters} of those!");
                    break;
                case GuessResponse.Incorrect:
                    System.Console.WriteLine("Sorry, that was not found!");
                    break;
                case GuessResponse.Duplicate:
                    System.Console.WriteLine("You already guessed that, try again!");
                    break;
                case GuessResponse.Win:
                    System.Console.WriteLine($"{guesserName} has guessed the word, they win!");
                    break;
                case GuessResponse.Loss:
                    System.Console.WriteLine($"{guesserName} has struck out, {otherPlayerName} wins!");
                    System.Console.WriteLine($"The word was : {correctWord}");
                    break;

            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadLine();

        }

        public static bool PlayAgain(IPlayer player1, IPlayer player2)
        {
            System.Console.WriteLine($"The score is:\r\n {player1.Name} - {player1.Wins}\r\n {player2.Name} - {player2.Wins}\r\n\r\nPlay another game (y/n): ");
            string result = System.Console.ReadLine().ToUpper();
            if(result == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
