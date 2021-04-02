using System.Drawing;
using System.Windows.Forms;

namespace ArcherGame
{
    internal class Archer:Object
    {
        public Archer(int panelHeight, Size MovementSize): base(MovementSize)
        {

            Image = Image.FromFile(@"photos\okcu2.jpg");
            Middle = panelHeight/ 2;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Distance = Height;
        }
    }
}
