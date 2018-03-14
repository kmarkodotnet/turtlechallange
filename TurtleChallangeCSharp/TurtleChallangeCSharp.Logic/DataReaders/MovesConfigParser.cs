using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.DataReaders
{
    public class MovesConfigParser : IConfigParser<MovesConfigs>
    {
        public string[] Source { get; set; }
        
        public MovesConfigs ParseConfig()
        {
            throw new NotImplementedException();
        }
    }
}
