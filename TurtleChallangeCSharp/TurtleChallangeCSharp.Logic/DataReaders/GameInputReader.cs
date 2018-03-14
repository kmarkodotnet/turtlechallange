using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Exceptions;
using TurtleChallangeCSharp.Model.Interfaces;

namespace TurtleChallangeCSharp.Logic.DataReaders
{
    public class GameInputReader : IGameInputReader
    {
        private string tableConfigPath;
        private string movesConfigPath;

        public GameInputReader(string tableConfigPath, string movesConfigPath)
        {
            this.tableConfigPath = tableConfigPath;
            this.movesConfigPath = movesConfigPath;
        }

        public string[] GetMovesConfig()
        {
            return ReadFile(movesConfigPath);
        }

        public string[] GetTableConfig()
        {
            return ReadFile(tableConfigPath);
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
                throw new BusinessException { Reason = string.Format("Unable to load file: {0}", filePath), InnerException = ex };
            }
        }
    }
}
