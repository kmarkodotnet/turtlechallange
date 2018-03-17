using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    /// <summary>
    /// The manager class of the gate
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Method that run the game
        /// </summary>
        /// <returns></returns>
        GameResults RunGame();
    }
}
