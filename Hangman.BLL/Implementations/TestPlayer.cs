using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class TestPlayer : IPlayer
    {
        public string Name { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public IWordSource WordSource { get; set; } 

        public string GetGuess(string guess)
        {
            return guess;
        }

        public string GetGuess(List<string> guesses)
        {
            throw new NotImplementedException();
        }

        public string? GetWord()
        {
            return null;
        }
        
    }
}
