using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logger.Interface;
using TurtleChallangeCSharp.Logic.Helpers;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.DataReaders
{
    public class MovesConfigParser : IMovesConfigParser
    {
        public string[] Source { get; set; }
        ILogger _logger;

        public MovesConfigParser(ILogger logger)
        {
            _logger = logger;
        }

        public MovesConfigs ParseConfig()
        {
            var movesConfigs = new MovesConfigs();
            if (Source != null && Source.Length > 0)
            {
                for (int i = 0; i < Source.Length; i++)
                {
                    var mc = ParseMovesLine(Source[i]);
                    movesConfigs.Add(mc);
                }
            }
            return movesConfigs;
        }

        private MovesConfig ParseMovesLine(string line)
        {
            var values = line.Split(' ');

            var mc = new MovesConfig();
            for (int i = 0; i < values.Length; i++)
            {
                var m = ParserHelper.TryParseMove(values[i]);
                mc.Moves.Add(m);
            }
            return mc;
        }

    }
}
