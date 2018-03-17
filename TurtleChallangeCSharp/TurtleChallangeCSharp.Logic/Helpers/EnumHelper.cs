using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Logic.Helpers
{
    /// <summary>
    /// Enum helper
    /// </summary>
    internal class EnumHelper
    {
        /// <summary>
        /// Returns the elements of the enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
    }
}
