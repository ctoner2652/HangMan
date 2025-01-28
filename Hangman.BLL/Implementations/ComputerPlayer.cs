using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class ComputerPlayer : IPlayer

    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public IWordSource WordSource { get; set; }
        public string GetGuess(List<string> currentGuesses)
        {
            List<string> strings = new List<string>
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };
            Random rng = new Random();
            while (true) {

                string answer = strings[rng.Next(0, strings.Count)];
                if (currentGuesses.Contains(answer))
                {
                    continue;
                }
                else
                {
                    System.Console.WriteLine($"{this.Name} has guessed the letter {answer}");
                    return answer;
                }
            }
            
        }

    }
}
