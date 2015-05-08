//<Tommy Bouffard>
using System.Drawing;

namespace TP3
{
  class Mushroom
  {
    private int xPosition = 0;
    private int yPosition = 0;
    public int YPosition
    {
      get
      {
        return yPosition;
      }
    }
    public int XPosition
    {
      get
      {
        return xPosition;
      }
    }
    public Mushroom(int x, int y)
    {
      xPosition = x;
      yPosition = y;
    }
    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.Mushroom, new Point(xPosition, yPosition));
    }
  }
}
//</Tommy Bouffard>
