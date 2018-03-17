using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logic;
using TurtleChallangeCSharp.Logic.DataReaders;
using TurtleChallangeCSharp.Logic.StateMachine;

namespace TurtleChallangeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Cannot start application with wrong number of arguments.");
                Console.WriteLine("Example: .\\TurtleChallangeCSharp.exe game-settings moves");
            }
            else
            {
                var gameManager = new GameManager(new GameInputReader(args[0], args[1]), new MovesConfigParser(), new TableConfigParser(), new TurtleStateMachine());
                var results = gameManager.RunGame();
                foreach (var result in results)
                {
                    Console.WriteLine(result.ResultString);
                }
            }
        }
    }
}
