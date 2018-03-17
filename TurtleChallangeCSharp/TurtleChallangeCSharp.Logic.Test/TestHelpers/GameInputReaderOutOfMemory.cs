using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.Test.TestHelpers
{
    internal class GameInputReaderOutOfMemory : IGameInputReader
    {
        public string[] OutOfMemory()
        {
            var length = 1000 * 1000 * 1000;
            var ss = new string[length];
            return ss;
        }

        public string[] GetTableConfig()
        {
            return OutOfMemory();
        }

        public string[] GetMovesConfig()
        {
            return OutOfMemory();
        }
    }
}
