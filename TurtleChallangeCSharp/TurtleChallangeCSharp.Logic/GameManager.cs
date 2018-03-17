using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logger.Interface;
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
        private ITurtleStateMachine _turtleStateMachine;

        private TableConfig TableConfig { get; set; }
        private MovesConfigs MovesConfigs { get; set; }

        ILogger _logger;

        public GameManager(IGameInputReader gameInputReader, IMovesConfigParser movesConfigParser, ITableConfigParser tableConfigParser, ITurtleStateMachine turtleStateMachine, ILogger logger)
        {
            _gameInputReader = gameInputReader;
            _movesConfigParser = movesConfigParser;
            _tableConfigParser = tableConfigParser;
            _turtleStateMachine = turtleStateMachine;
            _logger = logger;
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

                _logger.BusinessSuccess(BL.EVENT_APPSTART_ID, BL.EVENT_APPSTART_NAME);

                return new Result();
            }
            catch (ParseException pex)
            {
                _logger.BusinessFail(BL.EVENT_APPSTART_ID, BL.EVENT_APPSTART_NAME, pex);
                return new ErrorResult { ResultString = pex.Message };
            }
            catch (BusinessException bex)
            {
                _logger.BusinessFail(BL.EVENT_APPSTART_ID, BL.EVENT_APPSTART_NAME, bex);
                return new ErrorResult { ResultString = bex.Message };
            }
            catch (OutOfMemoryException oex)
            {
                _logger.BusinessFail(BL.EVENT_APPSTART_ID, BL.EVENT_APPSTART_NAME, oex);
                return new ErrorResult { ResultString = "Application is out of memory" };
            }
            catch (Exception ex)
            {
                _logger.PublishException(ex);
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
                    _turtleStateMachine.Initialize(TableConfig, movesConfig);
                    var state = _turtleStateMachine.Play();
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

                _logger.BusinessSuccess(BL.EVENT_APPFIN_ID, BL.EVENT_APPFIN_NAME);

                return grs;
            }
        }
    }
}
