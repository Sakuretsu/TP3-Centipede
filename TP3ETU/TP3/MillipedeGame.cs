/* Classe repr�sentant un partie du jeu Millipede. Le but du jeu est de faire
 * le plus de point possible en tirant sur les araign�es et les serpents. Les araign�es
 * se d�place de mani�re al�atoire, mais vise parfois le joueur. Les serpents se d�place
 * horizontalement jusqu'� ce qu'il rencontre un obstacle ou qu'il sorte de l'�cran. Lorsque
 * cela survient, ils descendent vers le bas et change de direction. Le joueur dispose de
 * trois vie et il en perd une � chaque fois qu'il se fait toucher par une araign�e ou
 * par un serpent.
 * 
 * Cr�er par Charles Lachance et Tommy Bouffard
 */

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
    //Liste des champignons pr�sents dans la partie
    private List<Mushroom> mushrooms = new List<Mushroom>(); 
    //G�n�rateur de nombres au hasard
    private Random rnd = new Random();
    //Liste des projectiles pr�sents dans la partie
    private List<Projectile> bullets = new List<Projectile>();
    //Liste des araign�es pr�sents dans la partie
    private List<Spider> spiders = new List<Spider>();
    //Le joueur
    private Player player = new Player();
    //Nombre de "cases" horizontales
    public const int NB_HORIZONTAL_BLOCKS = 35;
    //Nombre de "cases" verticales
    public const int NB_VERTICAL_BLOCKS = 40;
    //Taille de base d'un �l�ment
    public const int OBJECT_SIZE = 16;
    //Taille horizontale de la fen�tre du jeu
    public const int GAME_WIDTH = OBJECT_SIZE*NB_HORIZONTAL_BLOCKS;
    //Taille verticale de la fen�tre du jeu
    public const int GAME_HEIGHT = OBJECT_SIZE* NB_VERTICAL_BLOCKS;
    //Nombre de champignons initiaux
    public const int NB_STARTING_MUSHROOM = 40;
    //Pointage total
    private int score = 0;
    //Musique du jeu
    public static SoundPlayer sndTrack = new SoundPlayer(Properties.Resources.Soundtrack_jeu);
    //</Tommy Bouffard>
    //<Charles Lachance>
    //La liste des serpents du jeu
    private List<Snake> snakes = null;
    //La recharge de munitions
    private BulletPowerup powerup = null;
    //Le nombre de serpent ayant �t� cr�er depuis le d�but du jeu excluant les divisions de serpent
    private int nbOfSnakeSpawned = 0;
    //</Charles Lachance>
    //Propri�t� c# du pointage
    public int Score
    {
      get
      {
        return score;
      }
    }
    //Propri�t� c# du joueur
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
      //On journalise le d�but d'une nouvelle partie
      Logger.GetInstance().Log("Game started");
      //</Charles Lachance>
      //<Tommy Bouffard>
      for (int i = 0; i != NB_STARTING_MUSHROOM; i++)
      {
        mushrooms.Add(new Mushroom(rnd.Next(0, NB_HORIZONTAL_BLOCKS), rnd.Next(0, 2*NB_VERTICAL_BLOCKS/3)));
      }
      //Lors du d�but du jeu on commence � faire jouer la musique
      sndTrack.PlayLooping();
      //</Tommy Bouffard>
      //<Charles Lachance>
      //On initialise le tableau des serpents
      snakes = new List<Snake>();
      //On ajoute un serpent de d�part
      snakes.Add(new Snake(rnd.Next(Snake.MIN_LENGTH + nbOfSnakeSpawned, Snake.MAX_LENGTH + nbOfSnakeSpawned)));
      //On as fait apparaitre un serpent
      nbOfSnakeSpawned = 1;
      //Aucune recharge de munitions n'est cr�� au d�but
      powerup = null;
      //</Charles Lachance>
    }

    /// <summary>
    /// V�rifie si deux rectangles ont une intersection commune.
    /// </summary>
    /// <param name="r1">Le premier rectangle</param>
    /// <param name="r2">Le second rectangle</param>
    /// <returns>true si les deux rectangles s'intersectent, false sinon. Note: La m�thode 
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

    /// <summary>
    /// Met � jour le jeu
    /// </summary>
    /// <returns>Retourne EndGameResult.GAME_LOST si le joueur est mort. Retourne EndGameResult.GAME_CONTINUE sinon.</returns>
    public EndGameResult Update()
    {
      //<Charles Lachance>
      //Si le joueur est vivant
      if (player.NbLives > 0)
      {
        //Pour chaque serpent...
        for (int i = 0; i < snakes.Count; i++)
        {
          //Si le serpent est mort ou en dehors de l'�cran...
          if (!snakes[i].Update(mushrooms))
          {
            //On retire le serpent
            snakes.RemoveAt(i);
            //On reste sur le m�me indice puisque tous les �l�ments sont d�cal�s de une position
            i--;
          }
        }

        //Rectangle repr�sentant une partie de serpent
        Rectangle snakeRect = new Rectangle();
        snakeRect.Height = OBJECT_SIZE;
        snakeRect.Width = OBJECT_SIZE;

        //Rectangle repr�sentant le joueur
        Rectangle playerRect = new Rectangle();
        playerRect.Height = Player.PLAYER_HEIGHT;
        playerRect.Width = Player.PLAYER_WIDTH;
        playerRect.X = player.XPosition;
        playerRect.Y = player.YPosition;

        //Pour chaque serpent...
        for (int i = 0; i < snakes.Count; i++)
        {
          //Pour chaque partie de serpent...
          for (int j = 0; j < snakes[i].Length; j++)
          {
            //On change la position du rectangle repr�sentant le serpent
            snakeRect.X = snakes[i][j].X * OBJECT_SIZE;
            snakeRect.Y = snakes[i][j].Y * OBJECT_SIZE;

            //Si le joueur touche � la partie de serpent...
            if (CheckIntersectionBetweenRectangle(snakeRect, playerRect))
            {
              //On diminue le nombre de vie du joueur
              player.NbLives--;
              //On �limine tous les ennemis du jeu
              KillAll();
              break;
            }

            //Pour chaque balle...
            for (int k = 0; k < bullets.Count; k++)
            {
              //Si la balle touche au serpent...
              if (snakes[i][j].X == bullets[k].XPosition / OBJECT_SIZE && snakes[i][j].Y == bullets[k].YPosition / OBJECT_SIZE)
              {
                //On cr�e deux nouveaux serpents
                Snake snake1 = new Snake();
                Snake snake2 = new Snake();

                //On s�pare l'ancien serpent en deux
                snakes[i].Split(new Point(bullets[k].XPosition / OBJECT_SIZE, bullets[k].YPosition / OBJECT_SIZE), snake1, snake2);

                //On ajoute un champignon � la position de la partie du serpent ayant �t� touch�
                mushrooms.Add(new Mushroom(snakes[i][j].X, snakes[i][j].Y));

                //On retire la balle du jeu
                bullets.RemoveAt(k);

                //On retire l'ancien serpent du jeu
                snakes.RemoveAt(i);

                //On ajoute les deux nouveaux serpents
                snakes.Add(snake1);
                snakes.Add(snake2);

                //On augmente le score
                score += 1;
                break;
              }
            }
          }
        }

        //S'il ne reste plus de serpent en jeu...
        if (snakes.Count == 0)
        {
          //On ajoute un nouveau serpent
          snakes.Add(new Snake(rnd.Next(Snake.MIN_LENGTH + nbOfSnakeSpawned, Snake.MAX_LENGTH + nbOfSnakeSpawned)));
          //On augmente le nombre de serpent ayant �t� cr��
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
          //Si le joueur manque de balle et que la recharge de munition n'existe pas...
          if (player.Ammo <= BulletPowerup.MIN_AMMO_TO_SPAWN && powerup == null)
            powerup = new BulletPowerup(); //On cr�e une nouvelle recharge de munition
          //</charles Lachance>
          bullets.Add(player.Fire());
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
            KillAll(); //On �limine tous les ennemis
            //</charles Lachance>
          }
        }
        //</Tommy Bouffard>
        //<charles Lachance>
        //Si la recharge de munition existe et qu'elle a �t� prise par le joueur...
        if (powerup != null && powerup.Update(player))
          powerup = null; //On la retire du jeu
        //</charles Lachance>

        RemoveShotEntities();
        RandomizeSpiders();
        //<charles Lachance>
        //Si le joueur est mort...
        if (player.NbLives <= 0)
        {
          //On journalise la fin de partie
          Logger.GetInstance().Log("Game ended");
          //On �limine tous les ennemis
          KillAll();
        }
      }
      else
      {
        return EndGameResult.GAME_LOST;
      }
      return EndGameResult.GAME_CONTINUE;
      //</charles Lachance>
    }
    /// <summary>
    /// Cette fonction v�rifie si une entit�e a �t� atteinte par une balle et les enl�ve.
    /// </summary>
    private void RemoveShotEntities()
    {
      //Liste de champignons � enlever
      List<Mushroom> mushroomsToRemove = new List<Mushroom>();
      //Liste de projectiles � enlever
      List<Projectile> bulletsToRemove = new List<Projectile>();
      //Liste d'araign�es � enlever
      List<Spider> spidersToRemove = new List<Spider>();
      for (int j = 0; j != bullets.Count; j++)
      {
        for (int i = 0; i != mushrooms.Count; i++)
        {
          if (CheckIntersectionBetweenRectangle(new RectangleF(mushrooms[i].XPosition * OBJECT_SIZE, mushrooms[i].YPosition * OBJECT_SIZE, OBJECT_SIZE, OBJECT_SIZE),
            new RectangleF(bullets[j].XPosition, bullets[j].YPosition, Projectile.SHOT_WIDTH, Projectile.SHOT_HEIGHT)))
          {
            //On ajoute la balle et le champignon � leur listes � enlever respectives.
            mushroomsToRemove.Add(mushrooms[i]);
            bulletsToRemove.Add(bullets[j]);
            //Si on ne brise pas la boucle, on risque de d�truire 2 �l�ments dans les m�mes cases.
            break;
          }
        }
        for (int i = 0; i != spiders.Count; i++)
        {
          if (CheckIntersectionBetweenRectangle(new RectangleF(spiders[i].XPosition, spiders[i].YPosition, OBJECT_SIZE * 2, OBJECT_SIZE * 2),
             new RectangleF(bullets[j].XPosition, bullets[j].YPosition, Projectile.SHOT_WIDTH, Projectile.SHOT_HEIGHT)))
          {
            //On ajoute la balle et l'araign�e � leur listes � enlever respectives.
            spidersToRemove.Add(spiders[i]);
            bulletsToRemove.Add(bullets[j]);
            mushrooms.Add(new Mushroom((int)(spiders[i].XPosition / OBJECT_SIZE), (int)(spiders[i].YPosition / OBJECT_SIZE)));
            //Une araign�e vaut 3 points
            score += 3;
            //Si on ne brise pas la boucle, on risque de d�truire 2 �l�ments dans les m�mes cases.
            break;
          }
          if (spiders[i].XPosition<0-OBJECT_SIZE*2 || spiders[i].XPosition>GAME_WIDTH)
          {
            //Les araign�es disparaissent si ils sortent de la partie.
            spidersToRemove.Add(spiders[i]);
            break;
          }
        }
        if (bullets[j].YPosition < 0)
        {
          //On enl�ve la balle qui sort du jeu.
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
    //<charles Lachance>
    /// <summary>
    /// M�thode �liminant tous les ennemis encore vivant dans le jeu et les remplace par des champignons
    /// </summary>
    private void KillAll ()
    {
      //Tant qu'il reste des araign�es sur le jeu...
      while (spiders.Count != 0)
      {
        //On ajoute un champignon � la position de l'araign�e
        mushrooms.Add(new Mushroom((int)spiders[0].XPosition/OBJECT_SIZE, (int)spiders[0].YPosition/OBJECT_SIZE));
        //On suprime l'araign�e
        spiders.RemoveAt(0);
      }

      //Tant qu'il reste des serpents sur le jeu...
      while (snakes.Count != 0)
      {
        //Pour chaque partie du serpent...
        for (int i = 0; i < snakes[0].Length; i++)
        {
          //On fait apparaitre un champignon � la position de la partie du serpent
          mushrooms.Add(new Mushroom(snakes[0][i].X, snakes[0][i].Y));
        }

        //On retire le serpent du jeu
        snakes.RemoveAt(0);
      }
    }
    //</charles Lachance>

    /// <summary>
    /// Cette conction g�re la cible d'une araign�e al�atoirement.
    /// </summary>
    private void RandomizeSpiders()
    {
      foreach (Spider spider in spiders)
      {
        if (spider.NbUpdates%Spider.nbUpdatesBeforeTargetChange == 0)
        {
          //un dixi�me du temps l'araign�e cible le joueur
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
    /// Cette fonction dessine les �l�ments sur la surface du jeu
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
      //Pour chaque serpent du jeu...
      foreach (Snake snake in snakes)
      {
        //On l'affiche...
        snake.Draw(g);
      }

      //Si la recharge de munition existe...
      if (powerup != null)
        powerup.Draw(g); //On l'affiche
      //</Charles Lachance>
    }
  }
}

