using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Input;

namespace TP3
{
  class MillipedeGame
  {
    //<Tommy Bouffard>
    //Liste des champignons présents dans la partie
    private List<Mushroom> mushrooms = new List<Mushroom>(); 
    //Générateur de nombres au hasard
    private Random rnd = new Random();
    //Liste des projectiles présents dans la partie
    private List<Projectile> bullets = new List<Projectile>();
    //Liste des araignées présents dans la partie
    private List<Spider> spiders = new List<Spider>();
    //Le joueur
    private Player player = new Player();
    //Nombre de "cases" horizontales
    public const int NB_HORIZONTAL_BLOCKS = 35;
    //Nombre de "cases" verticales
    public const int NB_VERTICAL_BLOCKS = 40;
    //Taille de base d'un élément
    public const int OBJECT_SIZE = 16;
    //Taille horizontale de la fenêtre du jeu
    public const int GAME_WIDTH = OBJECT_SIZE*NB_HORIZONTAL_BLOCKS;
    //Taille verticale de la fenêtre du jeu
    public const int GAME_HEIGHT = OBJECT_SIZE* NB_VERTICAL_BLOCKS;
    //Pointage total
    private int score = 0;
    //Musique du jeu
    public static SoundPlayer sndTrack = new SoundPlayer(Properties.Resources.Soundtrack_jeu);
    //</Tommy Bouffard>
    //<Charles Lachance>
    private List<Snake> snakes = null;
    private BulletPowerup powerup = null;
    private int nbOfSnakeSpawned = 0;
    //</Charles Lachance>
    //Propriété c# du pointage
    public int Score
    {
      get
      {
        return score;
      }
    }
    //Propriété c# du joueur
    public Player Player
    {
      get
      {
        return player;
      }
    }
    /// <summary>
    /// Constructeur du jeu, initialise les variables et instances de la partie.
    /// </summary>
    public MillipedeGame( )
    {
      //<Charles Lachance>
      Logger.GetInstance().Log("Game started");
      //</Charles Lachance>
      //<Tommy Bouffard>
      int nbStartingMushroom = rnd.Next(25, 41);
      for (int i = 0; i != nbStartingMushroom; i++)
      {
        int xPos = rnd.Next(0, NB_HORIZONTAL_BLOCKS);
        int yPos = rnd.Next(0, 2 * NB_VERTICAL_BLOCKS / 3);
        for (int j = 0; j!= mushrooms.Count; j++)
        {
          if (mushrooms[j].XPosition == xPos && mushrooms[j].YPosition ==yPos)
          {
            mushrooms.RemoveAt(j);
          }
        }
        mushrooms.Add(new Mushroom(rnd.Next(0, NB_HORIZONTAL_BLOCKS), rnd.Next(0, 2*NB_VERTICAL_BLOCKS/3)));
      }
      //Lors du début du jeu on commence à faire jouer la musique
      sndTrack.PlayLooping();
      //</Tommy Bouffard>
      //<Charles Lachance>
      snakes = new List<Snake>();
      snakes.Add(new Snake(rnd.Next(Snake.MIN_LENGTH + nbOfSnakeSpawned, Snake.MAX_LENGTH + nbOfSnakeSpawned)));
      nbOfSnakeSpawned = 1;
      powerup = null;
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
    public EndGameResult Update()
    {
      //<Charles Lachance>

      for (int i = 0; i < snakes.Count; i++)
      {
        if (!snakes[i].Update(mushrooms))
        {
          snakes.RemoveAt(i);
        }
      }
      Rectangle snakeRect = new Rectangle();
      snakeRect.Height = OBJECT_SIZE;
      snakeRect.Width = OBJECT_SIZE;

      Rectangle playerRect = new Rectangle();
      playerRect.Height = Player.PLAYER_HEIGHT;
      playerRect.Width = Player.PLAYER_WIDTH;
      playerRect.X = player.XPosition;
      playerRect.Y = player.YPosition;
      
      for (int i = 0; i < snakes.Count; i++)
      {
        for (int j = 0; j < snakes[i].Length; j++)
        {
          snakeRect.X = snakes[i][j].X * OBJECT_SIZE;
          snakeRect.Y = snakes[i][j].Y * OBJECT_SIZE;
          if (CheckIntersectionBetweenRectangle(snakeRect, playerRect))
          {
            player.NbLives--;
            KillAll();
            break;
          }
            
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
              score += 1;
              break;
            }
          }
        }
      }
      if (snakes.Count == 0)
      {
        snakes.Add(new Snake(rnd.Next(Snake.MIN_LENGTH + nbOfSnakeSpawned, Snake.MAX_LENGTH + nbOfSnakeSpawned)));
        nbOfSnakeSpawned++;
      }

      //</charles Lachance>
      //<Tommy Bouffard>
      player.Update();
      if (rnd.Next(0, 251) == 250)
      {
        spiders.Add(new Spider());
      }
      foreach (Projectile shot in bullets)
      {
        shot.Update();
      }
      if (Keyboard.IsKeyDown(Key.Space))
      {
        //<charles Lachance>
        if (player.Ammo <= BulletPowerup.MIN_AMMO_TO_SPAWN && powerup == null)
          powerup = new BulletPowerup();
        {
          bullets.Add(player.Fire());
        }
      }
      Rectangle spiderRect = new Rectangle();
      spiderRect.Height = Spider.SPIDER_SIZE;
      spiderRect.Width = Spider.SPIDER_SIZE;
      //<Tommy Bouffard>
      for (int i = 0; i < spiders.Count; i++)
      {
        spiders[i].Update();
        spiderRect.X = (int)spiders[i].XPosition;
        spiderRect.Y = (int)spiders[i].YPosition;
        if (CheckIntersectionBetweenRectangle(spiderRect, playerRect))
        {
          player.NbLives--;
          //<charles Lachance>
          KillAll();
          //</charles Lachance>
        }
      }
      //</Tommy Bouffard>
      if (powerup != null && powerup.Update(player))
        powerup = null;

      RemoveShotEntities();
      RandomizeSpiders();

      if (player.NbLives <= 0)
      {
        Logger.GetInstance().Log("Game ended");
        return EndGameResult.GAME_LOST;
      }
      return EndGameResult.GAME_CONTINUE;
      //</charles Lachance>
    }
    /// <summary>
    /// Cette fonction vérifie si une entitée a été atteinte par une balle et les enlève.
    /// </summary>
    private void RemoveShotEntities()
    {
      //Liste de champignons à enlever
      List<Mushroom> mushroomsToRemove = new List<Mushroom>();
      //Liste de projectiles à enlever
      List<Projectile> bulletsToRemove = new List<Projectile>();
      //Liste d'araignées à enlever
      List<Spider> spidersToRemove = new List<Spider>();
      for (int j = 0; j != bullets.Count; j++)
      {
        for (int i = 0; i != mushrooms.Count; i++)
        {
          if (CheckIntersectionBetweenRectangle(new RectangleF(mushrooms[i].XPosition * OBJECT_SIZE, mushrooms[i].YPosition * OBJECT_SIZE, OBJECT_SIZE, OBJECT_SIZE),
            new RectangleF(bullets[j].XPosition, bullets[j].YPosition, Projectile.SHOT_WIDTH, Projectile.SHOT_HEIGHT)))
          {
            //On ajoute la balle et le champignon à leur listes à enlever respectives.
            mushroomsToRemove.Add(mushrooms[i]);
            bulletsToRemove.Add(bullets[j]);
            //Si on ne brise pas la boucle, on risque de détruire 2 éléments dans les mêmes cases.
            break;
          }
        }
        for (int i = 0; i != spiders.Count; i++)
        {
          if (CheckIntersectionBetweenRectangle(new RectangleF(spiders[i].XPosition, spiders[i].YPosition, OBJECT_SIZE * 2, OBJECT_SIZE * 2),
             new RectangleF(bullets[j].XPosition, bullets[j].YPosition, Projectile.SHOT_WIDTH, Projectile.SHOT_HEIGHT)))
          {
            //On ajoute la balle et l'araignée à leur listes à enlever respectives.
            spidersToRemove.Add(spiders[i]);
            bulletsToRemove.Add(bullets[j]);
            mushrooms.Add(new Mushroom((int)(spiders[i].XPosition / OBJECT_SIZE), (int)(spiders[i].YPosition / OBJECT_SIZE)));
            //Une araignée vaut 3 points
            score += 3;
            //Si on ne brise pas la boucle, on risque de détruire 2 éléments dans les mêmes cases.
            break;
          }
          if (spiders[i].XPosition<0-OBJECT_SIZE*2 || spiders[i].XPosition>GAME_WIDTH)
          {
            //Les araignées disparaissent si ils sortent de la partie.
            spidersToRemove.Add(spiders[i]);
            break;
          }
        }
        if (bullets[j].YPosition < 0)
        {
          //On enlève la balle qui sort du jeu.
          bulletsToRemove.Add(bullets[j]);
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

    private void KillAll ()
    {
      while (spiders.Count != 0)
      {
        mushrooms.Add(new Mushroom((int)spiders[0].XPosition/OBJECT_SIZE, (int)spiders[0].YPosition/OBJECT_SIZE));
        spiders.RemoveAt(0);
      }

      while (snakes.Count != 0)
      {
        for (int i = 0; i < snakes[0].Length; i++)
        {
          mushrooms.Add(new Mushroom(snakes[0][i].X, snakes[0][i].Y));
        }
        snakes.RemoveAt(0);
      }
    }

    /// <summary>
    /// Cette conction gère la cible d'une araignée aléatoirement.
    /// </summary>
    private void RandomizeSpiders()
    {
      foreach (Spider spider in spiders)
      {
        if (spider.NbUpdates%Spider.nbUpdatesBeforeTargetChange == 0)
        {
          //un dixième du temps l'araignée cible le joueur
          if (rnd.Next(0,Spider.nbUpdatesBeforeTargetChange+1) == Spider.nbUpdatesBeforeTargetChange)
          {
            spider.SetPlayerAsTarget(player.XPosition, player.YPosition);
          }
          else
          {
            spider.SetRandomTarget();
          }
        }
      }
    }
    /// <summary>
    /// Cette fonction dessine les éléments sur la surface du jeu
    /// </summary>
    /// <param name="g"></param>
    public void Draw(Graphics g)
    {
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
      if (powerup != null)
        powerup.Draw(g);
      //</Charles Lachance>
    }
  }
}

