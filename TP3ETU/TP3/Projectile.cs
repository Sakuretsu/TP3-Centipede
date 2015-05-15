//<Tommy Bouffard>
using System.Drawing;

namespace TP3
{
  class Projectile
  {
    public const int SHOT_SPEED = 16;
    public const int SHOT_WIDTH = 6;
    public const int SHOT_HEIGHT = 8;
    private int yPosition = 0;
    private int xPosition = 0;

    public int XPosition
    {
      get
      {
        return xPosition;
      }
    }
    public int YPosition
    {
      get
      {
        return yPosition;
      }
    }

    public Projectile(int x, int y)
    {
      xPosition = x;
      yPosition = y;
    }

    public void Draw (Graphics g)
    {
      g.DrawImage(Properties.Resources.Bullet, new Point(xPosition, yPosition));
    }

    public void Update()
    {
      yPosition = yPosition - SHOT_SPEED;
    }
  }
}
//</Tommy Bouffard>
