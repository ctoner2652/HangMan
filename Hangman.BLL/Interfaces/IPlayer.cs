using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.BLL.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        int Wins { get; set; }
        int Losses { get; set; }
        string GetGuess(List<string> guesses);
        IWordSource WordSource { get; set; }
    }
}
