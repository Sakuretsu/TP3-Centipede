//<Charles Lachance>
using System;
using System.Drawing;

namespace TP3
{
  class BulletPowerup
  {
    static Random rand = null;
    public const int NB_BULLET_TO_ADD = 20;
    public const int SIZE = 16;
    public const int MIN_AMMO_TO_SPAWN = 5;

    public int XPosition
    {
      get;
      private set;
    }

    public int YPosition
    {
      get;
      private set;
    }

    public BulletPowerup()
    {
      if(rand == null)
        rand = new Random();
      XPosition = rand.Next(0, MillipedeGame.GAME_WIDTH - SIZE);
      YPosition = rand.Next(MillipedeGame.GAME_HEIGHT / 3, MillipedeGame.GAME_HEIGHT - SIZE);
    }

    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.BulletPowerup, XPosition, YPosition);
    }

    public bool Update(Player player)
    {
      if (MillipedeGame.CheckIntersectionBetweenRectangle(new RectangleF(XPosition, YPosition, SIZE, SIZE),
                                                          new RectangleF(player.XPosition, player.YPosition, Player.PLAYER_WIDTH, Player.PLAYER_HEIGHT)))
      {
        player.Ammo += NB_BULLET_TO_ADD;
        return true;
      }

      return false;
    }
  }
}
//</Charles Lachance>