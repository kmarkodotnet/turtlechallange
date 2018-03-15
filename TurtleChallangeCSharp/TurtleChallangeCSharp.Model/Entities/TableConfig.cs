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

        public List<Coordinate> Mines { get; set; }

        public TableConfig()
        {
            Mines = new List<Coordinate>();
        }

        public void Validate()
        {
            throw new NotImplementedException();
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
