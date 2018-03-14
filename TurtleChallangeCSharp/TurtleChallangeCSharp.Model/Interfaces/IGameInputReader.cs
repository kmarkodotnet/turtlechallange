﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    public interface IGameInputReader
    {
        string[] GetTableConfig();
        
        string[] GetMovesConfig();
    }
}