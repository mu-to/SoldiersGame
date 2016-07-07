using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldiersGame
{
    interface Player
    {
        Action makeAction(Map map, int teamColor);
    }
}
