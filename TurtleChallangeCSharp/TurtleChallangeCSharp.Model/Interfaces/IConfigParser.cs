using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    public interface IConfigParser<T>
        where T: new()
    {
        string[] Source { get; set; }
        T ParseConfig();
    }
}
