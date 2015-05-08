//<Tommy Bouffard>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
  class Spider
  {
    private float yPosition = 0;
    private float xPosition = 0;
    private float angle = 0;
    private int speed = 0;
    private int yTarget = 0;
    private int xTarget = 0;
    Random rnd = new Random();

    public float YPosition
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
    public float XPosition
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
    public float Angle
    {
      get
      {
        return angle;
      }
      set
      {
        angle = value;
      }
    }

    public int XTarget
    {
      get
      {
        return xTarget;
      }
      set
      {
        xTarget = value;
      }
    }
    public int YTarget
    {
      get
      {
        return yTarget;
      }
      set
      {
        yTarget = value;
      }
    }

    public void GetRandomTarget()
    {
      //Sujet aux changements: requiert la taille de l'écran
      xTarget = rnd.Next(0, 500);
      yTarget = rnd.Next(250, 500);
    }
  }
}
//</Tommy Bouffard>