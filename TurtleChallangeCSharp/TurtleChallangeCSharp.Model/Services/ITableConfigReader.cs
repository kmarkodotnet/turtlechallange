using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;

namespace TurtleChallangeCSharp.Model.Services
{
    public interface ITableConfigReader
    {
        TableConfig ReadConfig();
    }
}
