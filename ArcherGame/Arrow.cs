using System;
using System.Drawing;

namespace ArcherGame
{
    internal class Arrow: Object
    {
        public Arrow(Size MovementSize, int yayOrtasi):base(MovementSize)
        {
            Image = Image.FromFile(@"photos\ok.jpg");
            StartPosition(yayOrtasi);
            Distance = (int)(Height * 1.5);
        }

        private void StartPosition(int yayOrtasi) // Yayin okcunun ortasindan cikmasi
        {
            Bottom = movementSize.Height/2;
            Middle = yayOrtasi;
        }
    }
}
