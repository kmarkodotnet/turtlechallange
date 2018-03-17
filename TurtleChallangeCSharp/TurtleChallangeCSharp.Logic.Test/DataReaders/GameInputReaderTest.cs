using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurtleChallangeCSharp.Logger;
using TurtleChallangeCSharp.Logic.DataReaders;
using TurtleChallangeCSharp.Model.Exceptions;

namespace TurtleChallangeCSharp.Logic.Test.DataReaders
{
    [TestClass]
    public class GameInputReaderTest
    {
        [TestMethod]
        public void ReadFileTest()
        {
            var tempFile = Path.GetTempFileName();
            var content = string.Empty;
            File.WriteAllText(tempFile, content);
            var gir = new GameInputReader(new BusinessLog());
            gir.MovesConfigPath = tempFile;
            gir.TableConfigPath= tempFile + "XYZ";
            var mfc = gir.GetMovesConfig();
            Assert.IsTrue(mfc.Length == 0);

            content = "a" + Environment.NewLine + "b";
            File.WriteAllText(tempFile, content);
            mfc = gir.GetMovesConfig();
            Assert.IsTrue(mfc.Length == 2);

            Assert.ThrowsException<BusinessException>(() => gir.GetTableConfig());
        }
    }
}
