﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Model.Exceptions
{
    public class ParseException : BaseException
    {
        public new object Data { get; set; }
    }
}
