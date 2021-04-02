
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArcherGame
{
    internal abstract class Object:PictureBox, IMovingObject
    {

        public Size movementSize { get; }

        public int Distance { get; protected set; }

        public new int Right
        {
            get => base.Right;
            set => Left = value - Width;
        }
        public new int Bottom //new yazarak alltaki bottom ile cakismasi engelleniyor.
        {
            get => base.Bottom;
            set => Top = value - Height;
        }

        public int Center
        {
            get => Left + Width / 2;
            set => Left = value - Width / 2;
        }

        public int Middle
        {
            get => Top + Height / 2;
            set => Top = value - Height / 2;
        }


        protected Object(Size MovementSize)
        {
            movementSize = MovementSize;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        protected Object()
        {
        }

        public bool MoveIt(Direction direction) // Kullanilacak cisimlerin hareketlerini kontrol edilmesi
        {
            switch (direction)
            {
                case Direction.Up:
                    return MoveUp();
                case Direction.Down:
                    return MoveDown();
                case Direction.Right:
                    return MoveRight();
                case Direction.Left:
                    return MoveLeft();
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);

            }
        }

        private bool MoveLeft()
        {
            if (Left == 0) return true;

            var newLeft = Left - Distance;
            var IsOutOfRange = newLeft < 0;
            Left = IsOutOfRange ? 0 : newLeft;

            return Left == 0;
        }

        private bool MoveRight()
        {
            if (Right == movementSize.Width) return true;

            var newRight = Right + Distance;
            var IsOutOfRange = newRight > movementSize.Width;

            Right = IsOutOfRange ? movementSize.Width : newRight;

            return Right == movementSize.Width;
               
        }
        private bool MoveUp()
        {
            if (Top == 0) return true;
            var newTop = Top - Distance;
            var IsOutOfRange = newTop < 0;
            Top = IsOutOfRange ? 0 : newTop;

            return Top == 0;
        }
        private bool MoveDown()
        {
            if (Bottom == movementSize.Height) return true;

            var newBottom = Bottom + Distance;
            var IsOutOfRange = newBottom > movementSize.Height;

            Bottom = IsOutOfRange ? movementSize.Height : newBottom;
            
            return Bottom == movementSize.Height;

        }

       
    }
}
