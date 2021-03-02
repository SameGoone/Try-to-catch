using System;
using System.Drawing;

namespace Игра.Финал
{
    class Texture
    {
        public Point location;
        public Size size;
        public Bitmap texture;

        public Texture(Image image) : this(image, 0, 0, 0, 0)
        {
        }


        public Texture(Image image, int x, int y, int width, int height)
        {
            texture = new Bitmap(image);
            location.X = x;
            location.Y = y;
            size.Width = width;
            size.Height = height;

        }
    }
}
