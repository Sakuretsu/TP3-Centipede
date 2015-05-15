using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace TP3
{
  class MillipedeGame
  {
    //<Tommy Bouffard>
    private List<Mushroom> mushrooms = new List<Mushroom>(); 
    private Random rnd = new Random();
    private List<Projectile> bullets = new List<Projectile>();
    private List<Spider> spiders = new List<Spider>();
    private Player player = new Player();
    public const int NB_HORIZONTAL_BLOCKS = 35;
    public const int NB_VERTICAL_BLOCKS = 40;
    public const int OBJECT_SIZE = 16;
    public const int GAME_WIDTH = OBJECT_SIZE*NB_HORIZONTAL_BLOCKS;
    public const int GAME_HEIGHT = OBJECT_SIZE* NB_VERTICAL_BLOCKS;
    public const int NB_STARTING_MUSHROOM = 40;
    private int score = 0;
    //</Tommy Bouffard>
    //<Charles Lachance>
    private List<Snake> snakes = null;
    //</Charles Lachance>

    public int Score
    {
      get
      {
        return score;
      }
    }
    public MillipedeGame( )
    {
      //<Tommy Bouffard
      for (int i = 0; i != NB_STARTING_MUSHROOM; i++)
      {
        mushrooms.Add(new Mushroom(rnd.Next(0, NB_HORIZONTAL_BLOCKS), rnd.Next(0, 2*NB_VERTICAL_BLOCKS/3)));
      }
      //</Tommy Bouffard>

      //<Charles Lachance>
      snakes = new List<Snake>();
      snakes.Add(new Snake(rnd.Next(8, 12)));
      //</Charles Lachance>
    }

    /// <summary>
    /// Vérifie si deux rectangles ont une intersection commune.
    /// </summary>
    /// <param name="r1">Le premier rectangle</param>
    /// <param name="r2">Le second rectangle</param>
    /// <returns>true si les deux rectangles s'intersectent, false sinon. Note: La méthode 
    /// retourne true si l'intersection se produit uniquement au niveau des bordures.</returns>
    public static bool CheckIntersectionBetweenRectangle(RectangleF r1, RectangleF r2)
    {
      float xInter1 = (r1.Left + r1.Width - r2.Left);
      float xInter2 = ((r2.Left + r2.Width) - r1.Left);
      bool xCollide = (xInter1 >= 0) && (xInter2 >= 0);

      float yInter1 = (r1.Top + r1.Height - r2.Top);
      float yInter2 = ((r2.Top + r2.Height) - r1.Top);
      bool yCollide = (yInter1 >= 0) && (yInter2 >= 0);

      return (xCollide && yCollide);
    }

    // ppoulin
    // Vous aurez assurément à modidier le type de retour ici pour un EndGameResult.
    // Je n'ai pas pu le faire car il fallait que ça compile.
    public void Update()
    {
      //<Charles Lachance>
      for (int i = 0; i < snakes.Count; i++)
      {
        if (!snakes[i].Update(mushrooms))
        {
          snakes.RemoveAt(i);
        }
      }

      Rectangle rect1 = new Rectangle();
      rect1.Height = OBJECT_SIZE;
      rect1.Width = OBJECT_SIZE;

      Rectangle rect2 = new Rectangle();
      rect2.Height = Projectile.SHOT_HEIGHT;
      rect2.Width = Projectile.SHOT_WIDTH;

      
      for (int i = 0; i < snakes.Count; i++)
      {
        for (int j = 0; j < snakes[i].Length; j++)
        {
          for (int k = 0; k < bullets.Count; k++)
          {
            if (snakes[i][j].X == bullets[k].XPosition / OBJECT_SIZE && snakes[i][j].Y == bullets[k].YPosition / OBJECT_SIZE)
            {
              Snake snake1 = new Snake(0);
              Snake snake2 = new Snake(0);

              snakes[i].Split(new Point(bullets[k].XPosition / OBJECT_SIZE, bullets[k].YPosition / OBJECT_SIZE), snake1, snake2);

              mushrooms.Add(new Mushroom(snakes[i][j].X, snakes[i][j].Y));

              bullets.RemoveAt(k);
              snakes.RemoveAt(i);
              snakes.Add(snake1);
              snakes.Add(snake2);
              break;
            }
          }
        }
      }

      if (snakes.Count == 0)
      {
        snakes.Add(new Snake(rnd.Next(8, 12)));
      }

      //</charles Lachance>
      //<Tommy Bouffard>
      player.Update();
      if (rnd.Next(0,101) == 100)
      {
        spiders.Add(new Spider());
      }
      if (Keyboard.IsKeyDown(Key.Space) && player.PlayerHasFired ==false)
      {
        player.PlayerHasFired = true;
        bullets.Add(player.Fire());
      }
      else if (Keyboard.IsKeyUp(Key.Space))
      {
        player.PlayerHasFired = false;
      }

      foreach(Projectile shot in bullets)
      {
        shot.Update();
      }
      foreach(Spider spider in spiders)
      {
        spider.Update();
      }
      RemoveShotEntities();
      RandomizeSpiders();
    }

    public void RemoveShotEntities()
    {

      List<Mushroom> mushroomsToRemove = new List<Mushroom>();
      List<Projectile> bulletsToRemove = new List<Projectile>();
      List<Spider> spidersToRemove = new List<Spider>();
      for (int j = 0; j != bullets.Count; j++)
      {
        for (int i = 0; i != mushrooms.Count; i++)
        {
          if (CheckIntersectionBetweenRectangle(new RectangleF(mushrooms[i].XPosition * OBJECT_SIZE, mushrooms[i].YPosition * OBJECT_SIZE, OBJECT_SIZE, OBJECT_SIZE),
            new RectangleF(bullets[j].XPosition, bullets[j].YPosition, Projectile.SHOT_WIDTH, Projectile.SHOT_HEIGHT)))
          {
            mushroomsToRemove.Add(mushrooms[i]);
            bulletsToRemove.Add(bullets[j]);
            break;
          }
        }
        for (int i = 0; i != spiders.Count; i++)
        {
          if (CheckIntersectionBetweenRectangle(new RectangleF(spiders[i].XPosition, spiders[i].YPosition, OBJECT_SIZE * 2, OBJECT_SIZE * 2),
          new RectangleF(bullets[j].XPosition, bullets[j].YPosition, Projectile.SHOT_WIDTH, Projectile.SHOT_HEIGHT)))
          {
            spidersToRemove.Add(spiders[i]);
            bulletsToRemove.Add(bullets[j]);
            break;
          }
          else if (spiders[i].XPosition<0-OBJECT_SIZE*2 || spiders[i].XPosition>GAME_WIDTH)
          {
            spidersToRemove.Add(spiders[i]);
            break;
          }
        }
      }
      foreach (Projectile shot in bulletsToRemove)
      {
        bullets.Remove(shot);
      }
      foreach (Mushroom mush in mushroomsToRemove)
      {
        mushrooms.Remove(mush);
      }
      foreach (Spider spiderMan in spidersToRemove)
      {
        spiders.Remove(spiderMan);
      }
    }

    public void RandomizeSpiders()
    {
      foreach (Spider spider in spiders)
      {
        if (spider.XSpeed<0 && spider.YPosition<spider.XTarget)
        {
          if (rnd.Next(0,11)==10)
          {
            spider.GetPlayerAsTarget(player.XPosition, player.XPosition);
          }
          else
          {
            spider.GetRandomTarget();
          }
        }
        else if (spider.XSpeed>0 && spider.XPosition>spider.XTarget)
        {
          if (rnd.Next(0, 11) == 10)
          {
            spider.GetPlayerAsTarget(player.XPosition, player.XPosition);
          }
          else
          {
            spider.GetRandomTarget();
          }
        }
      }
    }
    //</Tommy Bouffard>
    public void Draw(Graphics g)
    {
      //<Tommy Bouffard>
      foreach (Mushroom mush in mushrooms)
      {
        mush.Draw(g);
      }
      player.Draw(g);
      foreach (Projectile shot in bullets)
      {
        shot.Draw(g);
      }
      foreach (Spider spiderMan in spiders)
      {
        spiderMan.Draw(g);
      }
      //</Tommy Bouffard>

      //<Charles Lachance>
      foreach (Snake snake in snakes)
      {
        snake.Draw(g);
      }
      //</Charles Lachance>
    }
  }
}

