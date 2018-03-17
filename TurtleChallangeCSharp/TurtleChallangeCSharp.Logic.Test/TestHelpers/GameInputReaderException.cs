using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.Test.TestHelpers
{
    internal class GameInputReaderException : IGameInputReader
    {

        public string[] GetTableConfig()
        {
            throw new Exception("XYZ");
        }

        public string[] GetMovesConfig()
        {
            throw new Exception("XYZ");
        }
    }
}
