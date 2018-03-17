using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    /// <summary>
    /// Base class of the configuration parsers
    /// </summary>
    /// <typeparam name="T">Generic type of configuration class</typeparam>
    public interface IConfigParser<T>
        where T: new()
    {
        /// <summary>
        /// Configuration data source
        /// </summary>
        string[] Source { get; set; }

        /// <summary>
        /// Parser of the data
        /// </summary>
        /// <returns></returns>
        T ParseConfig();
    }
}
