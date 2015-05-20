//<Tommy Bouffard>
/*
 * Cette classe gère l'ensemble des fonctionalités et des fonctions d'un champignon quelconque dans la partie
 * 
 *  Créé par Tommy Bouffard
 * 
 */
using System.Drawing;

namespace TP3
{
  class Mushroom
  {
    //Position en x
    private int xPosition = 0;
    //Position en y
    private int yPosition = 0;
    //Largeur du champignon
    public const int MUSHROOM_WIDTH = 16;
    //Hauteur du champignon
    public const int MUSHROOM_HEIGHT = 16;
    //Propriété c# de la position en y du champignon
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
    //Propriété c# de la position en x du champignon
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
    /// <summary>
    /// Constructeur du champignon: initialise la position du champignon selon des valeurs reçue
    /// </summary>
    /// <param name="x">Position en X reçue</param>
    /// <param name="y">Position en Y reçue</param>
    public Mushroom(int x, int y)
    {
      XPosition = x;
      YPosition = y;
    }
    /// <summary>
    /// Dessine le champignon sur la surface de la partie.
    /// </summary>
    /// <param name="g"></param>
    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.Mushroom, new Point(xPosition*MillipedeGame.OBJECT_SIZE, yPosition*MillipedeGame.OBJECT_SIZE));
    }
  }
}
//</Tommy Bouffard>
