/* Représente une recharge de munition que le joueur peut
 * ramasser. Lorsque le joueur la rammasse, elle lui redonne 20 balles.
 * 
 * Créé par Charles Lachance
 */ 
//<Charles Lachance>
using System;
using System.Drawing;

namespace TP3
{
  class BulletPowerup
  {
    //Générateur de nombre aléatoire.
    static Random rand = null;
    //Le nombre de balle à ajouter au joueur lorsqu'il rammasse le powerup.
    public const int NB_BULLET_TO_ADD = 20;
    //La taille d'un coté du powerup.
    public const int SIZE = 16;
    //Le nombre de balle à partir duquel on doit faire apparaitre le powerup.
    public const int MIN_AMMO_TO_SPAWN = 5;

    //La position du powerup en X
    public int XPosition
    {
      get; //todo
      private set;
    }

    //La position du powerup en Y
    public int YPosition
    {
      get;
      private set;
    }

    /// <summary>
    /// Contruit un nouveau powerup et le positionne sur le jeu
    /// </summary>
    public BulletPowerup()
    {
      //Si le générateur de nombre n'as pas encore été créé...
      if(rand == null)
        rand = new Random(); //On le crée
      //On positionne le powerup dans le tier inférieur de l'écran
      XPosition = rand.Next(0, MillipedeGame.GAME_WIDTH - SIZE);
      YPosition = rand.Next( 2 * MillipedeGame.GAME_HEIGHT / 3, MillipedeGame.GAME_HEIGHT - SIZE);
    }

    /// <summary>
    /// Affiche la recharge de munition à l'écran
    /// </summary>
    /// <param name="g">Objet permettant d'afficher à l'écran</param>
    public void Draw(Graphics g)
    {
      //On affiche la recharge de munition à sa position
      g.DrawImage(Properties.Resources.BulletPowerup, XPosition, YPosition);
    }

    /// <summary>
    /// Met à jour la recharge de balle et détermine si le joueur a récupéré 
    /// la recharge de balle.
    /// </summary>
    /// <param name="player">Le joueur</param>
    /// <returns>Retourne vrai si le joueur a pris la recharge de balle. Retourne faux sinon.</returns>
    public bool Update(Player player)
    {
      //Si le joueur touche à la recharge de balle...
      if (MillipedeGame.CheckIntersectionBetweenRectangle(new RectangleF(XPosition, YPosition, SIZE, SIZE),
                                                          new RectangleF(player.XPosition, player.YPosition, Player.PLAYER_WIDTH, Player.PLAYER_HEIGHT)))
      {
        //On augmente le nombre de balle du joueur
        player.Ammo += NB_BULLET_TO_ADD;
        return true;
      }

      return false;
    }
  }
}
//</Charles Lachance>