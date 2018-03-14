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

        private TurtleState turtleState;

        public GameManager(IGameInputReader gameInputReader, IMovesConfigParser movesConfigParser, ITableConfigParser tableConfigParser)
        {
            _gameInputReader = gameInputReader;
            _movesConfigParser = movesConfigParser;
            _tableConfigParser = tableConfigParser;

            turtleState = new TurtleState();
        }

        private string Initialize()
        {
            try
            {
                _tableConfigParser.Source = _gameInputReader.GetTableConfig();
                _movesConfigParser.Source = _gameInputReader.GetMovesConfig();

                var tableConfig = _tableConfigParser.ParseConfig();
                var movesConfig = _movesConfigParser.ParseConfig();

                turtleState.ActualMove = 0;
                turtleState.MovesConfig = movesConfig;
                turtleState.TableConfig = tableConfig;
                turtleState.Position = tableConfig.StartPosition;

                return string.Empty;
            }
            catch (ParseException pex)
            {

                throw;
            }
            catch (BusinessException bex)
            {

                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public GameResults RunGame()
        {
            throw new NotImplementedException();
        }
    }
}
