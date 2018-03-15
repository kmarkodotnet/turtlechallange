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
                return new ErrorResult { ErrorMessage = pex.Reason };
            }
            catch (BusinessException bex)
            {
                return new ErrorResult { ErrorMessage = bex.Reason };
            }
            catch (OutOfMemoryException oex)
            {
                return new ErrorResult { ErrorMessage = "Application is out of memory" };
            }
            catch (Exception ex)
            {
                return new ErrorResult { ErrorMessage = "An error occured" };
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

                return new GameResults();
            }
        }
    }
}
