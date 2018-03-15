using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic
{
    public class GameManager : IGameManager
    {
        private IMovesConfigParser _movesConfigParser;
        private ITableConfigParser _tableConfigParser;
        private IGameInputReader _gameInputReader;

        private TableConfig TableConfig { get; set; }
        private MovesConfigs MovesConfigs { get; set; }

        public GameManager(IGameInputReader gameInputReader, IMovesConfigParser movesConfigParser, ITableConfigParser tableConfigParser)
        {
            _gameInputReader = gameInputReader;
            _movesConfigParser = movesConfigParser;
            _tableConfigParser = tableConfigParser;
            
        }

        private Result Initialize()
        {
            try
            {
                _tableConfigParser.Source = _gameInputReader.GetTableConfig();
                _movesConfigParser.Source = _gameInputReader.GetMovesConfig();

                TableConfig = _tableConfigParser.ParseConfig();
                MovesConfigs = _movesConfigParser.ParseConfig();

                TableConfig.Validate();
                
                return new Result();
            }
            catch (ParseException pex)
            {
                return new ErrorResult { ResultString = pex.Reason };
            }
            catch (BusinessException bex)
            {
                return new ErrorResult { ResultString = bex.Reason };
            }
            catch (OutOfMemoryException oex)
            {
                return new ErrorResult { ResultString = "Application is out of memory" };
            }
            catch (Exception ex)
            {
                return new ErrorResult { ResultString = "An error occured" };
            }
        }

        public GameResults RunGame()
        {
            var initResult = Initialize();
            if (initResult is ErrorResult)
            {
                return new GameResults { initResult };
            }
            else
            {
                var grs = new GameResults();
                int i = 1;
                foreach (var movesConfig in MovesConfigs)
                {
                    var stateMachine = new TurtleStateMachine();
                    stateMachine.Initialize(TableConfig, movesConfig);
                    var state = stateMachine.Play();
                    var message = string.Format("Sequence {0}: ",i);
                    Result result;
                    switch (state)
                    {
                        case Model.Enums.State.Success:
                            result = new GameResult { ResultString = string.Format("{0}{1}", message, "Success!") };
                            break;
                        case Model.Enums.State.MineHit:
                            result = new GameResult { ResultString = string.Format("{0}{1}", message, "Mine hit!") };
                            break;
                        case Model.Enums.State.StillInDander:
                            result = new GameResult { ResultString = string.Format("{0}{1}", message, "Still in danger!") };
                            break;
                        case Model.Enums.State.Error:
                            result = new GameResult { ResultString = string.Format("{0}{1}", message, "Error!") };
                            break;
                        default:
                            throw new BusinessException("Invalid application state");
                            break;
                    }
                    grs.Add(result);
                    i++;
                }
                return grs;
            }
        }
    }
}
