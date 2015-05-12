//<Tommy Bouffard>
using System;
using System.Drawing;

namespace TP3
{
  class Spider
  {
    private float yPosition = 0;
    private float xPosition = 0;
    private int yTarget = 0;
    private int xTarget = 0;
    private float xSpeed = 0;
    private float ySpeed = 0;
    private const int nbUpdatesBeforeReachingTarget = 40;
    public const int nbGetPlayerTargetDivider = 10;
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
    public float XSpeed
    {
      get
      {
        return xSpeed;
      }
    }
    public float YSpeed
    {
      get
      {
        return ySpeed;
      }
    }

    public void GetRandomTarget()
    {
      //Sujet aux changements: requiert la taille de l'écran
      xTarget = rnd.Next(0, MillipedeGame.GAME_WIDTH);
      yTarget = rnd.Next(MillipedeGame.GAME_HEIGHT/3, MillipedeGame.GAME_HEIGHT);
      xSpeed = ((float)xTarget - (float)xPosition) / (float)nbUpdatesBeforeReachingTarget;
      ySpeed = ((float)yTarget - (float)yPosition) / (float)nbUpdatesBeforeReachingTarget;
    }

    public Spider()
    {
      if (rnd.Next(1,3) == 1)
      {
        xPosition = 0;
      }
      else
      {
        xPosition = MillipedeGame.GAME_WIDTH;
      }
      yPosition = 2 * MillipedeGame.GAME_HEIGHT / 3;
      GetRandomTarget();
    }

    public void GetPlayerAsTarget(int playerX, int playerY)
    {
      yTarget = playerY;
      xTarget = playerX;
      xSpeed = ((float)xTarget - (float)xPosition) / (float)nbUpdatesBeforeReachingTarget;
      ySpeed = ((float)yTarget - (float)yPosition) / (float)nbUpdatesBeforeReachingTarget;
    }

    public void Update()
    {
      xPosition += xSpeed;
      yPosition += ySpeed;
    }

    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.Spider,xPosition,yPosition);
    }
  }
}
//</Tommy Bouffard>