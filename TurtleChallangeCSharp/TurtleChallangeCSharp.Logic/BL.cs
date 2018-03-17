using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallangeCSharp.Logic
{
    /// <summary>
    /// Business log
    /// </summary>
    public class BL
    {
        public static readonly int EVENT_APPSTART_ID = 101;
        public static readonly string EVENT_APPSTART_NAME = "App started";

        public static readonly int EVENT_APPFIN_ID = 102;
        public static readonly string EVENT_APPFIN_NAME = "App finished";

        public static readonly int EVENT_MCFR_ID = 201;
        public static readonly string EVENT_MCFR_NAME = "Moves config file read";

        public static readonly int EVENT_TCFR_ID = 202;
        public static readonly string EVENT_TCFR_NAME = "Table config file read";

        public static readonly int EVENT_PLAYINIT_ID = 301;
        public static readonly string EVENT_PLAYINIT_NAME = "Play init";

        public static readonly int EVENT_PLAY_ID = 302;
        public static readonly string EVENT_PLAY_NAME = "Play";
    }
}
