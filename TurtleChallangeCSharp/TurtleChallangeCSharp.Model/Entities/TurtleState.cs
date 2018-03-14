using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class TurtleState: IValidation
    {
        public Position Position { get; set; }

        public TableConfig TableConfig { get; set; }

        public int ActualMove { get; set; }
        public MovesConfig MovesConfig { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
