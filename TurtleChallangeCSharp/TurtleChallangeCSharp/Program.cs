using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logger;
using TurtleChallangeCSharp.Logger.Interface;
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
                var logger = new BusinessLog();

                var gir = new GameInputReader(logger);
                gir.TableConfigPath = args[0];
                gir.MovesConfigPath = args[1];

                var gameManager = new GameManager(gir, new MovesConfigParser(logger), new TableConfigParser(logger), new TurtleStateMachine(logger), logger);
                var results = gameManager.RunGame();
                foreach (var result in results)
                {
                    Console.WriteLine(result.ResultString);
                }
            }
        }
    }
}
