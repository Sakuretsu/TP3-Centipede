//<Charles Lachance>
//<Tommy Bouffard>
/* Cette classe gère les fonctionalités et les valeurs du joueur dans la partie.
 * 
 * 
 * Créé par Tommy Bouffard
 * 
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using System.Media;
namespace TP3
{
  class Player
  {
    //Date du dernier tir
    DateTime lastTimeFired = DateTime.Now;
    //Nombre de vies
    int nbLives = 3;
    //Nombre de balles restantes
    int ammoRemaining = 20;
	//<Charles Lachance>
    //Nombre de balles maximales
    public const int MAX_AMMO = 20;
    //</Charles Lachance>
    //Position en x
    int xPosition = 0;
    //Position en y
    int yPosition = 0;
    //État de tir du joueur (a tiré dans les 500 derniers millisecondes)
    bool playerHasFired = false;
    //Hauteur du joueur
    public const int PLAYER_HEIGHT = 32;
    //Largeur du joueur
    public const int PLAYER_WIDTH = 32;
    //Vitesse du joueur
    public int PLAYER_SPEED = 10;
    //Propriété c# du nombre de vie
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
    //Propriété c# de la position en X
    public int XPosition
    {
      get
      {
        return xPosition;
      }
      private set
      {
        xPosition = value;
      }
    }
    //Propriété c# de la position en Y
    public int YPosition
    {
      get
      {
        return yPosition;
      }
      private set
      {
        yPosition = value;
      }
    }
    //Propriété c# du nombre de balles
    public int Ammo
    {
      get
      {
        return ammoRemaining;
      }
      set
      {
        ammoRemaining = Math.Min(value, MAX_AMMO);
      }
    }
    //Propriété c# de l'état de tir du joueur
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
    //Constructeur du joueur: initialise les paramètres initiaux du joueur
    public Player()
    {
      nbLives = 3;
      ammoRemaining = 20;
      XPosition = MillipedeGame.GAME_WIDTH/2 - MillipedeGame.OBJECT_SIZE;
      YPosition = MillipedeGame.GAME_HEIGHT - MillipedeGame.OBJECT_SIZE * 2;
    }
    /// <summary>
    /// Cette fonction fait tirer un projectile par le joueur
    /// </summary>
    /// <returns>Le projectile tiré</returns>
    public Projectile Fire()
    {
      if (ammoRemaining > 0 && lastTimeFired.AddMilliseconds(500) < DateTime.Now)
      {
        lastTimeFired = DateTime.Now;
        ammoRemaining--;
        return new Projectile(xPosition+MillipedeGame.OBJECT_SIZE, yPosition);
      }
        //Si le joueur ne peut pas tirer, il faut de même retourner un projectile. On l'initialisera alors hors de la partie ou elle sera supprimée
      else
      {
        return new Projectile(250, -100);
      }
    }
    /// <summary>
    /// Cette fonction dessine le joueur sur la partie.
    /// </summary>
    /// <param name="g"></param>
    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.Player, xPosition, yPosition);
    }
    /// <summary>
    /// Cette fonction met à jour le joueur selon les touches enfoncées.
    /// </summary>
    public void Update()
    {
      if(Keyboard.IsKeyDown(Key.Down))
      {
        YPosition += PLAYER_SPEED;
        if (YPosition> MillipedeGame.GAME_HEIGHT-MillipedeGame.OBJECT_SIZE*2)
        {
          YPosition = MillipedeGame.GAME_HEIGHT - MillipedeGame.OBJECT_SIZE * 2;
        }
      }
      if (Keyboard.IsKeyDown(Key.Up))
      {
        YPosition -= PLAYER_SPEED;
        if (YPosition < 0)
        {
          YPosition = 0;
        }
      }
      if (Keyboard.IsKeyDown(Key.Right))
      {
        XPosition += PLAYER_SPEED;
        if (XPosition > MillipedeGame.GAME_WIDTH-MillipedeGame.OBJECT_SIZE*2)
        {
          XPosition = MillipedeGame.GAME_WIDTH - MillipedeGame.OBJECT_SIZE * 2;
        }
      }
      if (Keyboard.IsKeyDown(Key.Left))
      {
        XPosition -= PLAYER_SPEED;
        if (XPosition < 0)
        {
          XPosition = 0;
        }
      }
    }
  }
  //</Tommy Bouffard>
}
//</Charles Lachance>