using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;

namespace TurtleChallangeCSharp.Logic.Test.TestHelpers
{
    public class RandomData
    {
        private Random r = new Random();

        public int GetRandomInt(int? max = null)
        {
            var m = int.MaxValue;
            if (max.HasValue)
            {
                m = max.Value;
            }
            return r.Next(m);
        }

        public List<Moves> GetMoves(int? length = null)
        {
            if (!length.HasValue)
            {
                length = GetRandomInt();
            }

            var moves = new List<Moves>();

            for (int i = 0; i < length; i++)
            {
                moves.Add(GetRandomMoves());
            }

            return moves;
        }

        private Moves GetRandomMoves()
        {
            Array values = Enum.GetValues(typeof(Moves));
            return (Moves)values.GetValue(r.Next(values.Length));
        }
    }
}
