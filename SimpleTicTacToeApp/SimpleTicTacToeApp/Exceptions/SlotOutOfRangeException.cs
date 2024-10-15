using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicTacToeApp.Exceptions
{
    public class SlotOutOfRangeException: Exception
    {
        public SlotOutOfRangeException(string message) : base(message) { }
    }
}
