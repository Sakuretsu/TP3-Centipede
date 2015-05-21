//<Tommy Bouffard>
/* Cette classe gère l'ensemble des fonctionalités qu'un projectile peut avoir dans la partie.
 * 
 * Créé par Tommy Bouffard
 * 
 */
using System.Drawing;

namespace TP3
{
  class Projectile
  {
    //Vitesse du projectile
    public const int SHOT_SPEED = 16;
    //Largeur du projectile
    public const int SHOT_WIDTH = 6;
    //Hauteur du projectile
    public const int SHOT_HEIGHT = 8;
    //Position du projectile en y
    private int yPosition = 0;
    //Position du projectile en x
    private int xPosition = 0;
    //Propriétés c# de la position en x
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
    //Propriétés c# de la position en y
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
    //Constructeur: initialise la position du projectile selon un x et un y reçu.
    public Projectile(int x, int y)
    {
      XPosition = x;
      YPosition = y;
    }
    /// <summary>
    /// Dessine le projectile sur la surface du jeu.
    /// </summary>
    /// <param name="g"></param>
    public void Draw (Graphics g)
    {
      g.DrawImage(Properties.Resources.Bullet, new Point(XPosition, YPosition));
    }
    //Met à jour le projectile
    public void Update()
    {
      YPosition = YPosition - SHOT_SPEED;
    }
  }
}
//</Tommy Bouffard>
