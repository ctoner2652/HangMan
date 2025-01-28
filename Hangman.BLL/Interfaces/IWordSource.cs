using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.BLL.Interfaces
{
    public interface IWordSource
    {
        string SourceWord(string name, string name2);
    }
}
