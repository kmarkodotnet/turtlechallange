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

namespace TurtleChallangeCSharp.Logic.DataReaders
{
    public class TableConfigParser : IConfigParser<TableConfig>
    {
        public string[] Source { get; set; }

        public TableConfig ParseConfig()
        {
            if (Source == null || Source.Length != 4)
            {
                throw new ParseException { Data = Source, Reason = "Table configuration is empty or the parameters are incorrect" };
            }

            var config = new TableConfig();

            SetTableSize(config);
            SetMines(config);
            SetExit(config);
            SetStartPosition(config);

            return config;
        }

        private void SetStartPosition(TableConfig config)
        {
            config.StartPosition = new Position();
            var startPosRow = Source[3];

            var startPosValues = startPosRow.Split(' ');
                
            if (startPosValues.Length != 3)
            {
                throw new ParseException { Data = Source, Reason = string.Format("Start position parameter value is incorrect") };
            }
            config.StartPosition.Direction = ParserHelper.TryParseDirections(startPosValues[2], "Start position");

            var coordinate = ParseCoordinate(startPosValues, "Start position");
            config.StartPosition.X = coordinate.X;
            config.StartPosition.Y = coordinate.Y;
        }

        private void SetExit(TableConfig config)
        {
            config.Exit = new Coordinate();
            var exitRow = Source[2];

            config.Exit = ParseCoordinate(exitRow, ' ', "Exit point");
        }

        private void SetMines(TableConfig config)
        {
            config.Mines = new List<Coordinate>();
            var minesRow = Source[1];

            var mines = minesRow.Split(' ');

            for (int i = 0; i < mines.Length; i++)
            {
                var mineCoordinate = ParseCoordinate(mines[i], ',', string.Format("Mine[{0}]", i));
                
                config.Mines.Add(mineCoordinate);
            }
        }

        private void SetTableSize(TableConfig config)
        {
            var sizeRow = Source[0];

            var size = ParseCoordinate(sizeRow, ' ', "Table size");
            config.SizeX = size.X;
            config.SizeY = size.Y;
        }

        private Coordinate ParseCoordinate(string coordinateSource, char divider, string errorString)
        {
            var coordinates = coordinateSource.Split(divider);

            if (coordinates.Length != 2)
            {
                throw new ParseException { Data = Source, Reason = string.Format("{0} parameter value is incorrect", errorString) };
            }
            return ParseCoordinate(coordinates, errorString);
        }

        private Coordinate ParseCoordinate(string[] coordinates, string errorString)
        {
            var coord = new Coordinate();
            coord.X = ParserHelper.TryParse(coordinates[0], string.Format("{0} X value", errorString));
            coord.Y = ParserHelper.TryParse(coordinates[1], string.Format("{0} Y value", errorString));
            return coord;
        }
    }
}
