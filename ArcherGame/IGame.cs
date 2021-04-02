using System;

namespace ArcherGame
{
    internal interface IGame
    {
        event EventHandler TimeChanged;

        bool IsContinue { get; }
        TimeSpan PassTime { get; }
        void Start();
        void Fire();
        void moveArcher(Direction direction);
    }
}
