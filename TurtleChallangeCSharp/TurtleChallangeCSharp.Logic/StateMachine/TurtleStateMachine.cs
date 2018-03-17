using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logger.Interface;
using TurtleChallangeCSharp.Logic.Helpers;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.StateMachine
{
    public class TurtleStateMachine : ITurtleStateMachine
    {
        ILogger _logger;

        public TurtleStateMachine(ILogger logger)
        {
            _logger = logger;
        }

        private StateConfiguration StateConfiguration { get; set; }
        private State TurtleState { get; set; }

        private int ID { get; set; }

        public void Initialize(TableConfig tableConfig, MovesConfig movesConfig, int? id = null)
        {
            if (id.HasValue)
            {
                ID = id.Value;
            }

            StateConfiguration = new StateConfiguration();

            StateConfiguration.ActualMove = 0;
            StateConfiguration.Moves = movesConfig.Moves.ToArray();
            StateConfiguration.TableConfig = tableConfig;
            StateConfiguration.Position = tableConfig.StartPosition;

            StateConfiguration.FullValidate();

            TurtleState = StateHelper.GetState(StateConfiguration.Position, StateConfiguration.TableConfig.Mines, StateConfiguration.TableConfig.Exit);
            
            _logger.BusinessSuccess(BL.EVENT_PLAYINIT_ID, BL.EVENT_PLAYINIT_NAME, new { Id = ID });
        }

        private void Next()
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
                    if (bex is InvalidPositionException)
                    {
                        _logger.BusinessFail(BL.EVENT_PLAY_ID, BL.EVENT_PLAY_NAME, new { Id = ID, BEX = bex, Message = "Left table" });
                        return State.LeftTable;
                    }
                    else
                    {
                        _logger.BusinessFail(BL.EVENT_PLAY_ID, BL.EVENT_PLAY_NAME, new { Id = ID, BEX = bex });
                        return State.Error;
                    }
                }
            }
            _logger.BusinessSuccess(BL.EVENT_PLAY_ID, BL.EVENT_PLAY_NAME, new { Id = ID, State = TurtleState });
            return TurtleState;
        }
    }
}
