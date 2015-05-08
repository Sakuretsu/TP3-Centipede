using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      set
      {
        yPosition = value;
      }
    }
    public int XPosition
    {
      get
      {
        return xPosition;
      }
      set
      {
        xPosition = value;
      }
    }
    public Mushroom(int x, int y)
    {
      xPosition = x;
      yPosition = y;
    }
  }
}
