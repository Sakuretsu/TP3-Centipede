//<Tommy Bouffard>
/* Cette classe contient l'ensemble des fonctionalités de l'araignée dans la partie
 * 
 * 
 * Créé par Tommy Bouffard
 * 
 *
 */
using System;
using System.Drawing;

namespace TP3
{
  class Spider
  {
    //Position de l'araignée en y.
    private float yPosition = 0;
    //Position de l'araignée en x.
    private float xPosition = 0;
    //Position de la cible en y.
    private int yTarget = 0;
    //Position de la cible en x.
    private int xTarget = 0;
    //Vitesse de l'araignée en x.
    private float xSpeed = 0;
    //Vitesse de l'araignée en y.
    private float ySpeed = 0;
    //Grandeur en pixel de l'araignée.
    public const int SPIDER_SIZE = 32;
    //Nombre de mise à jours avant d'atteindre la cible.
    public const int nbUpdatesBeforeTargetChange = 40;
    //Nombre de mise à jours total depuis l'initialisation.
    private int nbUpdates = 0;
    //Diviseur du nombre de chances de cibler le joueur (si il est égal à 5, le nombre de chances est 1/5.
    public const int nbGetPlayerTargetDivider = 10;
    //Générateur de nombre aléatoire.
    Random rnd = new Random();
    //Propriétés c# de la position en y
    public float YPosition
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
    //Propriétés c# du nombre de mise à jours
    public int NbUpdates
    {
      get
      {
        return nbUpdates;
      }
    }
    //Propriétés c# de la position en x
    public float XPosition
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
    //Propriétés c# de la cible en x
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
    //Propriétés c# de la cible en y
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
    //Propriétés c# de la vitesse en X
    public float XSpeed
    {
      get
      {
        return xSpeed;
      }
      private set
      {
        xSpeed = value;
      }
    }
    //Propriétés c# de la vitesse en Y
    public float YSpeed
    {
      get
      {
        return ySpeed;
      }
      private set
      {
        ySpeed = value;
      }
    }
    /// <summary>
    /// Cette fonction donne une cible aléatoire à l'araignée
    /// </summary>
    public void SetRandomTarget()
    {
      XTarget = rnd.Next(0, MillipedeGame.GAME_WIDTH);
      YTarget = rnd.Next(MillipedeGame.GAME_HEIGHT/3, MillipedeGame.GAME_HEIGHT);
      XSpeed = ((float)XTarget - (float)XPosition) / (float)nbUpdatesBeforeTargetChange;
      YSpeed = ((float)YTarget - (float)YPosition) / (float)nbUpdatesBeforeTargetChange;
    }
    /// <summary>
    /// Constructeur de l'araignée. Initialise aléatoirement l'araignée (L'araignée commence à un des deux côtés de la partie).
    /// </summary>
    public Spider()
    {
      if (rnd.Next(1,3) == 1)
      {
        XPosition = 0;
      }
      else
      {
        XPosition = MillipedeGame.GAME_WIDTH;
      }
      YPosition = 2 * MillipedeGame.GAME_HEIGHT / 3;
      SetRandomTarget();
    }
    /// <summary>
    /// Cette fonction change la cible de l'araignée vers une cible donnée (Seulement utilisée pour le joueur).
    /// </summary>
    /// <param name="playerX">Position en X (du joueur)</param>
    /// <param name="playerY">Position en Y (du joueur)</param>
    public void SetPlayerAsTarget(int playerX, int playerY)
    {
      YTarget = playerY;
      XTarget = playerX;
      XSpeed = ((float)XTarget - (float)XPosition) / (float)nbUpdatesBeforeTargetChange;
      YSpeed = ((float)YTarget - (float)YPosition) / (float)nbUpdatesBeforeTargetChange;
    }
    /// <summary>
    /// Cette fonction met à jour l'araignée.
    /// </summary>
    public void Update()
    {
      XPosition += XSpeed;
      YPosition += YSpeed;
      nbUpdates++;
    }
    /// <summary>
    /// Cette fonction dessine l'araignée.
    /// </summary>
    /// <param name="g"></param>
    public void Draw(Graphics g)
    {
      g.DrawImage(Properties.Resources.Spider,XPosition,YPosition);
    }
  }
}
//</Tommy Bouffard>