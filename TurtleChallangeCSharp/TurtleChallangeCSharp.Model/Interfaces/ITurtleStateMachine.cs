using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleChallangeCSharp.Model.Entities;
using TurtleChallangeCSharp.Model.Enums;

namespace TurtleChallangeCSharp.Model.Interfaces
{
    public interface ITurtleStateMachine
    {
        void Initialize(TableConfig tableConfig, MovesConfig movesConfig);
        void Next();
        State Play();
    }
}
