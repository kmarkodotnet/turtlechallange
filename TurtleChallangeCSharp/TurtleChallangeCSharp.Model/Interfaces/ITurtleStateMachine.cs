using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    /// <summary>
    /// Manages the state changes of the turtle
    /// </summary>
    public interface ITurtleStateMachine
    {
        /// <summary>
        /// Initalize the statemachine
        /// </summary>
        /// <param name="tableConfig">table configuration</param>
        /// <param name="movesConfig">moves configuration</param>
        void Initialize(TableConfig tableConfig, MovesConfig movesConfig);

        /// <summary>
        /// Runs the game on a single moves configuration
        /// </summary>
        /// <returns></returns>
        State Play();
    }
}
