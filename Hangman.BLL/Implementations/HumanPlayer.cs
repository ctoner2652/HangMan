using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public int Wins { get; set ; }
        public int Losses { get; set; }

        public IWordSource WordSource { get; set; }

        public string GetGuess(List<string> guesses)
        {
            System.Console.WriteLine("Enter Guess: ");
            return System.Console.ReadLine();
        }
    }
}
