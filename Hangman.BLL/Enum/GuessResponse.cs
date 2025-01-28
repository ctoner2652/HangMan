using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.BLL.Enum
{
    public enum GuessResponse
    {
        Win,
        Loss,
        Duplicate,
        Correct,
        Incorrect
    }
}
