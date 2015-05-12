using System;
using System.Collections.Generic;
using System.Drawing;

namespace TP3
{
  class MillipedeGame
  {
    //<Tommy Bouffard>
    private List<Mushroom> mushrooms = new List<Mushroom>(); 
    private Random rnd = new Random();
    public const int NB_HORIZONTAL_BLOCKS = 35;
    public const int NB_VERTICAL_BLOCKS = 40;
    public const int OBJECT_SIZE = 16;
    public const int GAME_WIDTH = OBJECT_SIZE*NB_HORIZONTAL_BLOCKS;
    public const int GAME_HEIGHT = OBJECT_SIZE* NB_VERTICAL_BLOCKS;
    public const int NB_STARTING_MUSHROOM = 40;
    //</Tommy Bouffard>
    //<Charles Lachance>
    private Snake snake = null;
    //</Charles Lachance>

    public MillipedeGame( )
    {
      //<Tommy Bouffard
      for (int i = 0; i != NB_STARTING_MUSHROOM; i++)
      {
        mushrooms.Add(new Mushroom(rnd.Next(0, NB_HORIZONTAL_BLOCKS), rnd.Next(0, 2*NB_VERTICAL_BLOCKS/3)));
      }
      //</Tommy Bouffard>

      //<Charles Lachance>
      snake = new Snake(rnd.Next(8, 12));
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
      snake.Update(mushrooms);
      //</charles Lachance>
    }
    
    public void Draw(Graphics g)
    {
      //<Tommy Bouffard>
      foreach (Mushroom mush in mushrooms)
      {
        mush.Draw(g);
      }
      //</Tommy Bouffard>

      snake.Draw(g);
    }
  }
}

