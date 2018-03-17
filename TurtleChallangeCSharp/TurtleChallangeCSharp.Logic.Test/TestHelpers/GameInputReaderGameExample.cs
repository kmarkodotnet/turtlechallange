using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.Test.TestHelpers
{
    internal class GameInputReaderGameExample : IGameInputReader
    {
        public string[] GetTableConfig()
        {
            return new string[4] {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "0 1 N"
            };
        }

        public string[] GetMovesConfig()
        {
            return new string[4] {
                "M R M M M M R M M",
                "R M M M",
                "L L M L M M M M",
                "M R M M M"
            };
        }
    }
}
