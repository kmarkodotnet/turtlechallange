using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Model.Entities
{
    public class TableConfig: IValidation
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Position StartPosition { get; set; }
        public Coordinate Exit { get; set; }

        public List<Coordinate> Mines { get; set; }

        public TableConfig()
        {
            Mines = new List<Coordinate>();
        }

        public void Validate()
        {
            if (StartPosition == null || Exit == null || Mines == null || SizeX  < 1 || SizeY < 1)
            {
                throw new BusinessException("Table configuration is invalid");
            }

            StartPosition.Valiadte();
            Exit.Validate();
            Mines.ForEach(m => m.Validate());

            if (StartPosition.X >= SizeX || StartPosition.Y >= SizeY || Mines.Any(m => m.X >= SizeX || m.Y >= SizeY) || Exit.X >= SizeX || Exit.Y >= SizeY)
            {
                throw new InvalidPositionException("Coordinate values cannot be higher than table size");
            }
        }

        //public override bool Equals(object obj)
        //{
        //    var tc = obj as TableConfig;
        //    if (obj != null && tc != null)
        //    {
        //        return 
        //            this.SizeX == tc.SizeX &&
        //            this.SizeY == tc.SizeY &&
        //            this.StartPosition.Equals(tc.StartPosition) &&
        //            this.Exit.Equals(tc.Exit) &&
        //            this.Mines.Count == tc.Mines
        //    }
        //    else
        //        return false;
        //}
    }
}
