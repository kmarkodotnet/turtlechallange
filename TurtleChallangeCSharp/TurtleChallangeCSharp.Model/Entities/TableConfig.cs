using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class TableConfig: IValidation
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Position StartPosition { get; set; }
        public Coordinate Exit { get; set; }

        public ICollection<Coordinate> Mines { get; set; }

        public TableConfig()
        {
            Mines = new List<Coordinate>();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
