using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class Console : IWordSource
    {
        public string SourceWord(string name, string name2)
        {
            System.Console.WriteLine($"{name}, you will pick the word to guess. {name2}, look away!");
            System.Console.Write("Enter word: ");
            return System.Console.ReadLine();
        }
    }
}
