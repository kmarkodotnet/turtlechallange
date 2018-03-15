using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic
{
    internal class ParserHelper
    {
        internal static List<string> GetEnumElements<T>()
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var elements = new List<string>();
            var iterator = Enum.GetValues(typeof(T)).GetEnumerator();
            while (iterator.MoveNext())
            {
                var item = iterator.Current;
                elements.Add(item.ToString());
            }
            return elements;
        }

        internal static Moves TryParseMove(string value)
        {
            Moves parsedValue = 0;
            if (Moves.TryParse(value, out parsedValue) && GetEnumElements<Moves>().Contains(value))
            {
                return parsedValue;
            }
            else
            {
                throw new ParseException { Data = value, Reason = string.Format("Move config parameter is incorrect") };
            }
        }

        internal static Directions TryParseDirections(string value, string errorString)
        {
            Directions parsedValue = 0;

            if (Directions.TryParse(value, out parsedValue) && GetEnumElements<Directions>().Contains(value))
            {
                return parsedValue;
            }
            else
            {
                throw new ParseException { Data = value, Reason = string.Format("{0} parameter is incorrect", errorString) };
            }
        }

        internal static int TryParse(string value, string errorString)
        {
            int parsedValue = 0;
            if (int.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }
            else
            {
                throw new ParseException { Data = value, Reason = string.Format("{0} parameter is incorrect", errorString) };
            }
        }
    }
}
