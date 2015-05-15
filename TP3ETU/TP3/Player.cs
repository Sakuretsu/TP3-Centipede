//<Charles Lachance>
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
namespace TP3
{
  class Player
  {
    //<Tommy Bouffard>
    DateTime lastTimeFired = DateTime.Now;
    int nbLives = 3;
    int ammoRemaining = 20;
    int xPosition = 0;
    int yPosition = 0;
    bool playerHasFired = false;
    public const int PLAYER_HEIGHT = 32;
    public const int PLAYER_WIDTH = 32;
    public int PLAYER_SPEED = 10;
    public int NbLives
    {
      get
      {
        return nbLives;
      }
      set
      {
        nbLives = value;
      }
    }
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
    public int Ammo
    {
      get
      {
        return ammoRemaining;
      }
      set
      {
        ammoRemaining = value;
      }
    }
    public bool PlayerHasFired
    {
      get
      {
        return playerHasFired;
      }
      set
      {
        playerHasFired = value;
      }
    }
    public Player()
    {
      nbLives = 3;
      ammoRemaining = 20;
      xPosition = MillipedeGame.GAME_WIDTH/2 - MillipedeGame.OBJECT_SIZE;
      yPosition = MillipedeGame.GAME_HEIGHT - MillipedeGame.OBJECT_SIZE * 2;
    }
    public Projectile Fire()
    {
      if (ammoRemaining > 0 && lastTimeFired.AddMilliseconds(500) < DateTime.Now)
      {
        lastTimeFired = DateTime.Now;
        ammoRemaining--;
        return new Projectile(xPosition+MillipedeGame.OBJECT_SIZE, yPosition);
      }
      else
      {
        return new Projectile(250, -100);
      }
    }

    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.Player, xPosition, yPosition);
    }

    public void Update()
    {
      if(Keyboard.IsKeyDown(Key.Down))
      {
        yPosition += PLAYER_SPEED;
        if (yPosition> MillipedeGame.GAME_HEIGHT-MillipedeGame.OBJECT_SIZE*2)
        {
          yPosition = MillipedeGame.GAME_HEIGHT - MillipedeGame.OBJECT_SIZE * 2;
        }
      }

      if (Keyboard.IsKeyDown(Key.Up))
      {
        yPosition -= PLAYER_SPEED;
        if (yPosition < 0)
        {
          yPosition = 0;
        }
      }

      if (Keyboard.IsKeyDown(Key.Right))
      {
        xPosition += PLAYER_SPEED;
        if (xPosition > MillipedeGame.GAME_WIDTH-MillipedeGame.OBJECT_SIZE*2)
        {
          xPosition = MillipedeGame.GAME_WIDTH - MillipedeGame.OBJECT_SIZE * 2;
        }
      }

      if (Keyboard.IsKeyDown(Key.Left))
      {
        xPosition -= PLAYER_SPEED;
        if (xPosition < 0)
        {
          xPosition = 0;
        }
      }
    }
  }
  //</Tommy Bouffard>
}
//</Charles Lachance>