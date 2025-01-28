using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Enum;
using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Management
{
    public class GameManager
    {
        public string WordToGuess {  get; set; }
        public List<string> Guesses { get; set; } = new List<string>();
        public List<string> wordStatus { get; set; } = new List<string>();
        public int livesLeft { get; set; } = 5;

        public void StartRound()
        {
            livesLeft = 5;
            Guesses.Clear();
            wordStatus.Clear();
            foreach(var letter in WordToGuess)
            {
                wordStatus.Add(letter.ToString());
            }
            for (int i = 0; i < WordToGuess.Length; i++)
            {
                wordStatus[i] = "_";
            }
        }

        public List<int> letterLocations(string guessLetter)
        {
            List<int> letterLocations = new List<int>();
            for (int i = 0; i < WordToGuess.Length; i++)
            {
                if (WordToGuess[i].ToString() == guessLetter)
                {
                    letterLocations.Add(i);
                }
            }
            return letterLocations;
        }

        public GuessResponse ValidateGuess(string guess, IPlayer currentPlayer, IPlayer otherPlayer)
        {
            if (Guesses.Contains(guess))
            {
                return GuessResponse.Duplicate;
            }
            if(livesLeft == 0)
            {
                currentPlayer.Losses++;
                otherPlayer.Wins++;
                return GuessResponse.Loss;
            }
            if(guess.Length > 1)
            {
                
                if(ValidateWord(guess) == GuessResponse.Win)
                {
                    currentPlayer.Wins++;
                    otherPlayer.Losses++;
                    return GuessResponse.Win;
                }
                else
                {
                    livesLeft--;
                    if(livesLeft == 0)
                    {
                        return GuessResponse.Loss;
                    }
                    return GuessResponse.Incorrect;
                }
            }
            else
            {
                var result = ValidateLetter(guess);
                if(result == GuessResponse.Correct)
                {
                    return GuessResponse.Correct;
                }
                else if(result == GuessResponse.Win)
                {
                    currentPlayer.Wins++;
                    otherPlayer.Losses++;
                    return GuessResponse.Win;
                }else
                {
                    livesLeft--;
                    if (livesLeft == 0)
                    {
                        currentPlayer.Losses++;
                        otherPlayer.Wins++;
                        return GuessResponse.Loss;
                    }
                    return GuessResponse.Incorrect;
                }
            }
        }

        public GuessResponse ValidateWord(string guess)
        {
            Guesses.Add(guess);
            if(guess == WordToGuess)
            {
                return GuessResponse.Win;
            }
            return GuessResponse.Incorrect;
        }

        public GuessResponse ValidateLetter(string guess)
        {
            Guesses.Add(guess);
            if (WordToGuess.Contains(guess))
            {
                UpdateWordState(guess);
                if(ConvertStatusToString() == WordToGuess)
                {
                    return GuessResponse.Win;
                }
                return GuessResponse.Correct;
            }
            else
            {
                return GuessResponse.Incorrect;
            }
        }

        public void UpdateWordState(string successfullGuess)
        {
            var goodLetters = letterLocations(successfullGuess); //Equal to like 1,3
            
            foreach(var number in goodLetters)
            {
                wordStatus[number] = successfullGuess;
            }
        }
        public string ConvertStatusToString()
        {
            string finalWord = "";
            foreach(var letter in wordStatus)
            {
                finalWord += letter;
            }
            return finalWord;
        }
    }
}
