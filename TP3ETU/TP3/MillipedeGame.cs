using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP3.Properties;

namespace TP3
{
  class MillipedeGame
  {
    public MillipedeGame( )
    {
      
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
      
    }
    
    
    public void Draw(Graphics g)
    {
      
    }


  }
}

