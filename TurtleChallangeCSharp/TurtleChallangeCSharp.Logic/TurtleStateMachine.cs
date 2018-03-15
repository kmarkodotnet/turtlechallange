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

namespace TurtleChallangeCSharp.Logic
{
    public class TurtleStateMachine : ITurtleStateMachine
    {
        private TurtleState TurtleState { get; set; }

        public void Initialize(TableConfig tableConfig, MovesConfig movesConfig)
        {
            TurtleState = new TurtleState();

            TurtleState.ActualMove = 0;
            TurtleState.Moves = movesConfig.Moves.ToArray();
            TurtleState.TableConfig = tableConfig;
            TurtleState.Position = tableConfig.StartPosition;

            TurtleState.FullValidate();
        }

        public void Next()
        {
            TurtleState.ActualMove++;
            var actualMove = TurtleState.Moves[TurtleState.ActualMove - 1];
            var actualPosition = TurtleState.Position;
            TurtleState.Position = StateHelper.GetNewPosition(actualMove, actualPosition);
            
            TurtleState.Validate();

            TurtleState.State = StateHelper.GetState(TurtleState.Position, TurtleState.TableConfig.Mines, TurtleState.TableConfig.Exit);
        }


        public State Play()
        {
            if (StateHelper.IsInMine(TurtleState.TableConfig.Mines, TurtleState.Position))
            {
                return State.MineHit;
            }
            else
            {
                bool canMove = true;
                while (canMove)
                {
                    try
                    {
                        Next();
                        canMove = TurtleState.ActualMove < TurtleState.Moves.Length && !StateHelper.FinishState(TurtleState.State);
                    }
                    catch (BusinessException bex)
                    {
                        return State.Error;
                    }
                }
                return TurtleState.State;
            }
        }
                
    }
}
