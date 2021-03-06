using System;
using System.Collections.Generic;
using System.Drawing;

namespace ArcherGame
{
    class RedBallon: Ballon
    {
        private static readonly Random Random = new Random(); //Daha rastgele sayi olusturmak icin disarda olusturduk.
        public RedBallon(Size MovementSize) :base(MovementSize)
        {
            Image = Image.FromFile(@"photos\kirmizi-balon.jpg");
            Distance = (int)(Height * 0.1);
            Left = Random.Next(MovementSize.Width - Width + 1);
        }

        public Arrow IsShot(List<Arrow> arrows) //Balonun vurulma kontrolu
        {
            foreach (var arrow in arrows)
            {
                var isShot = arrow.Top < Bottom && arrow.Right > Left && arrow.Left < Right;
                if (isShot) return arrow;

            }
            return null;
        }
    }
}
