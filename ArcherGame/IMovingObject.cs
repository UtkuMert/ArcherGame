using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcherGame
{
    interface IMovingObject
    {
        Size movementSize { get; }
        int Distance { get; }
        bool MoveIt(Direction direction);
    }
}
