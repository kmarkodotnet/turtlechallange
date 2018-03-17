using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Logger.Interface;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.DataReaders
{
    public class GameInputReader : IGameInputReader
    {
        public string TableConfigPath { get; set; }
        public string MovesConfigPath { get; set; }
        ILogger _logger;

        public GameInputReader(ILogger logger)
        {
            _logger = logger;
        }

        public string[] GetMovesConfig()
        {
            var data = ReadFile(MovesConfigPath);
            _logger.BusinessSuccess(BL.EVENT_MCFR_ID, BL.EVENT_MCFR_NAME);
            return data;
        }

        public string[] GetTableConfig()
        {
            var data = ReadFile(TableConfigPath);
            _logger.BusinessSuccess(BL.EVENT_TCFR_ID, BL.EVENT_TCFR_NAME);
            return data;
        }

        private string[] ReadFile(string filePath)
        {
            try
            {
                var content = File.ReadAllLines(filePath);
                return content;
            
            }
            catch (Exception ex)
            {
                throw new BusinessException(string.Format("Unable to load file: {0}", filePath), ex );
            }
        }
    }
}
