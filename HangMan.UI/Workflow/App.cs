using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Enum;
using Hangman.BLL.Implementations;
using Hangman.BLL.Interfaces;
using Hangman.BLL.Management;
using HangMan.UI.Input;

namespace HangMan.UI.Workflow
{
    public static class App
    {
        public static void Run()
        {
            System.Console.WriteLine("===Welcome to Hang Man!!!");
            GameManager gm = new GameManager();
            IPlayer player1 = ConsoleIO.GetPlayerType(1);
            bool player1Turn = true;
            if (player1 is HumanPlayer)
            {
                player1.Name = ConsoleIO.GetPlayerName(1);
                player1.WordSource = ConsoleIO.GetWordSource(player1.Name);
            }
            else
            {
                player1.Name = "Player 1";
                System.Console.WriteLine("The computer has been assigned the name 'Player 1' and will pick a \r\nrandom word from the dictionary.");
                player1.WordSource = new Dictionary();
            }
            
            IPlayer player2 = ConsoleIO.GetPlayerType(2);
            if (player2 is HumanPlayer)
            {
                player2.Name = ConsoleIO.GetPlayerName(2);
                player2.WordSource = ConsoleIO.GetWordSource(player2.Name);
            }
            else
            {
                player2.Name = "Player 2";
                System.Console.WriteLine("The computer has been assigned the name 'Player 2' and will pick a \r\nrandom word from the dictionary.");
                player2.WordSource = new Dictionary();
            }
            do
            {
                gm.WordToGuess = player1.WordSource.SourceWord(player1.Name, player2.Name).ToLower();
                gm.StartRound();
                do
                {
                        System.Console.Clear();
                        ConsoleIO.DisplayRound(gm.livesLeft, gm.Guesses, gm.wordStatus);
                        GuessResponse result;
                        string guess;
                        do
                        {
                            guess = player2.GetGuess(gm.Guesses).ToLower();
                            result = gm.ValidateGuess(guess, player2, player1);
                            int correctLetters = 0;
                            if (result == Hangman.BLL.Enum.GuessResponse.Correct)
                            {
                                foreach (var letter in gm.wordStatus)
                                {
                                    if (letter == guess)
                                    {
                                        correctLetters++;
                                    }
                                }
                            }
                            ConsoleIO.DisplayGuessResult(result, correctLetters, player2.Name, player1.Name, gm.WordToGuess);
                    } while (result == Hangman.BLL.Enum.GuessResponse.Duplicate);
                        if(result == GuessResponse.Loss || result == GuessResponse.Win)
                        {
                        player1Turn = false;
                        }
                }while(player1Turn);

                gm.WordToGuess = player2.WordSource.SourceWord(player2.Name, player1.Name).ToLower();
                gm.StartRound();
                do
                {
                    System.Console.Clear();
                    ConsoleIO.DisplayRound(gm.livesLeft, gm.Guesses, gm.wordStatus);
                    GuessResponse result;
                    string guess;
                    do
                    {
                        guess = player1.GetGuess(gm.Guesses).ToLower();
                        result = gm.ValidateGuess(guess, player1, player2);
                        int correctLetters = 0;
                        if (result == Hangman.BLL.Enum.GuessResponse.Correct)
                        {
                            foreach (var letter in gm.wordStatus)
                            {
                                if (letter == guess)
                                {
                                    correctLetters++;
                                }
                            }
                        }
                        ConsoleIO.DisplayGuessResult(result, correctLetters, player1.Name, player2.Name, gm.WordToGuess);
                    } while (result == Hangman.BLL.Enum.GuessResponse.Duplicate);
                    if (result == GuessResponse.Loss || result == GuessResponse.Win)
                    {
                        player1Turn = true;
                    }
                } while (!player1Turn);

            } while (ConsoleIO.PlayAgain(player1, player2));

        }
    }
}
