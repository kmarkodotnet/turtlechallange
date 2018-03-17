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
        /// <returns>Lines of the table configuration</returns>
        string[] GetTableConfig();

        /// <summary>
        /// Reads the moves configuration file
        /// </summary>
        /// <returns>Lines of the moves configuration</returns>
        string[] GetMovesConfig();
    }
}
