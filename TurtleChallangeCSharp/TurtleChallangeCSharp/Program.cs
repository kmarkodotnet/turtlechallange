using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logic;
using TurtleChallangeCSharp.Logic.DataReaders;

namespace TurtleChallangeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameManager = new GameManager(new GameInputReader(@"c:\temp\game-settings.txt",@"c:\temp\moves.txt"), new MovesConfigParser(), new TableConfigParser());
            var results = gameManager.RunGame();
            foreach (var result in results)
            {
                Console.WriteLine(result.ResultString);
            }
        }
    }
}
