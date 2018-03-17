using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logic.Helpers;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.StateMachine
{
    public class TurtleStateMachine : ITurtleStateMachine
    {
        private StateConfiguration StateConfiguration { get; set; }
        private State TurtleState { get; set; }

        public void Initialize(TableConfig tableConfig, MovesConfig movesConfig)
        {
            StateConfiguration = new StateConfiguration();

            StateConfiguration.ActualMove = 0;
            StateConfiguration.Moves = movesConfig.Moves.ToArray();
            StateConfiguration.TableConfig = tableConfig;
            StateConfiguration.Position = tableConfig.StartPosition;

            StateConfiguration.FullValidate();

            TurtleState = StateHelper.GetState(StateConfiguration.Position, StateConfiguration.TableConfig.Mines, StateConfiguration.TableConfig.Exit);
        }

        internal void Next()
        {
            StateConfiguration.ActualMove++;
            var actualMove = StateConfiguration.Moves[StateConfiguration.ActualMove - 1];
            var actualPosition = StateConfiguration.Position;
            StateConfiguration.Position = StateHelper.GetNewPosition(actualMove, actualPosition);
            
            StateConfiguration.Validate();

            TurtleState = StateHelper.GetState(StateConfiguration.Position, StateConfiguration.TableConfig.Mines, StateConfiguration.TableConfig.Exit);
        }
        
        public State Play()
        {
            bool canMove = StateConfiguration.ActualMove < StateConfiguration.Moves.Length && !StateHelper.FinishState(TurtleState);
            while (canMove)
            {
                try
                {
                    Next();
                    canMove = StateConfiguration.ActualMove < StateConfiguration.Moves.Length && !StateHelper.FinishState(TurtleState);
                }
                catch (BusinessException bex)
                {
                    return State.Error;
                }
            }
            return TurtleState;
        }
    }
}
