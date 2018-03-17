using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    /// <summary>
    /// Reads the configuration files
    /// </summary>
    public interface IGameInputReader
    {
        /// <summary>
        /// Reads the table configuration file
        /// </summary>
        /// <returns></returns>
        string[] GetTableConfig();

        /// <summary>
        /// Reads the moves configuration file
        /// </summary>
        string[] GetMovesConfig();
    }
}
