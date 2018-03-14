using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class Coordinate : IValidation
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
