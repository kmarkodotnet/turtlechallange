using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Helpers
{
    /// <summary>
    /// Parser helper
    /// </summary>
    internal class ParserHelper
    {
        /// <summary>
        /// Parses a move enum value
        /// </summary>
        /// <param name="value">A 'move' string</param>
        /// <returns></returns>
        internal static Moves TryParseMove(string value)
        {
            Moves parsedValue = 0;
            if (Moves.TryParse(value, out parsedValue) && EnumHelper.GetEnumElements<Moves>().Contains(value))
            {
                return parsedValue;
            }
            else
            {
                throw new ParseException(string.Format("Move config parameter is incorrect")) { ParseData = value };
            }
        }

        /// <summary>
        /// Parses a direction enum value
        /// </summary>
        /// <param name="value">A 'direction' string</param>
        /// <returns></returns>
        internal static Directions TryParseDirections(string value)
        {
            Directions parsedValue = 0;

            if (Directions.TryParse(value, out parsedValue) && EnumHelper.GetEnumElements<Directions>().Contains(value))
            {
                return parsedValue;
            }
            else
            {
                throw new ParseException("Start position parameter is incorrect") { ParseData = value };
            }
        }

        /// <summary>
        /// Parses an integer value
        /// </summary>
        /// <param name="value">Value to parse</param>
        /// <param name="errorString">Error string depends on the kind of the value to parse</param>
        /// <returns></returns>
        internal static int TryParse(string value, string errorString)
        {
            int parsedValue = 0;
            if (int.TryParse(value, out parsedValue))
            {
                return parsedValue;
            }
            else
            {
                throw new ParseException(string.Format("{0} parameter is incorrect", errorString)) { ParseData = value };
            }
        }
    }
}
