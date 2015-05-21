/* Classe représentant un serpent dans le jeu. Les serpents doivent se déplacer horizontalement
 * et changer de direction à chaque fois qu'ils touchent un champignon ou le bord du jeu. Ils
 * doivent aussi descendre lorsqu'ils touchent un champignon ou le bord du jeu.
 * 
 * Créé par Charles Lachance
 */
//<Charles Lachance>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TP3
{
  class Snake
  {
    //La liste des points où il y a une partie du corps du serpent
    private List<Point> bodyParts = null;
    //La direction vers laquelle le serpent se dirige
    private Direction direction = Direction.Undefined;
    //La taille initiale minimale du premier serpent
    public const int MIN_LENGTH = 8;
    //La taille initiale maximale du premier serpent
    public const int MAX_LENGTH = 12;

    //La taille actuelle du serpent en lecture seulement
    public int Length
    {
      get
      {
        return bodyParts.Count();
      }
    }

    /// <summary>
    /// Affiche le serpent à l'écran
    /// </summary>
    /// <param name="g">Objet permettant d'afficher à l'écran</param>
    public void Draw(Graphics g)
    {
      //Pour chaque partie du serpent...
      foreach (Point part in bodyParts)
      {
        //On l'affiche à la bonne position
        g.DrawImage(Properties.Resources.SnakePart, part.X * MillipedeGame.OBJECT_SIZE, part.Y * MillipedeGame.OBJECT_SIZE);
      }
    }

    /// <summary>
    /// Crée un nouveau serpent de la taille spécifié
    /// </summary>
    /// <param name="length">La taille du serpent à créer</param>
    public Snake(int length)
    {
      //Si la taille est nulle ou négative...
      if (length <= 0)
      {
        //On lance une erreur
        throw new ArgumentOutOfRangeException("La longueur du serpent ne peut pas être négative");
      }

      //On initialise la liste des parties du serpent
      bodyParts = new List<Point>(0);

      //Pour chaque partie du serpent...
      for (int i = 0; i < length; i++)
      {
        //On crée un nouveau point à la position de départ
        bodyParts.Add(new Point(35, 0));
      }

      //On initialise la direction du serpent
      direction = Direction.Left;
    }

    /// <summary>
    /// Sépare le serpent à la position spécifié
    /// </summary>
    /// <param name="pt">Le point à partir duquel on doit séparer le serpent</param>
    /// <param name="splittedSnake1">La première partie du serpent</param>
    /// <param name="splittedSnake2">La deuxième partie du serpent</param>
    public void Split(Point pt, Snake splittedSnake1, Snake splittedSnake2)
    {
      //Pour chaque partie du corps du serpent...
      for (int i = 0; i < bodyParts.Count(); i++)
      {
        //Si la partie existe...
        if (bodyParts[i] != null)
        {
          //Si la partie n'est pas à la position à laquelle on souhaite séparer le serpent...
          if (bodyParts[i] != pt)
          {
            //On ajoute la partie au premier serpent
            splittedSnake1.bodyParts.Add(bodyParts[i]);
          }
          else
          {
            //Pour chaque partie subséquente...
            for (int j = i + 1; j < bodyParts.Count; j++)
            {
              //On ajoute la partie subséquente au serpent
              splittedSnake2.bodyParts.Add(bodyParts[j]);
            }
            break;
          }
        }
      }
    }

    /// <summary>
    /// Met à jour le serpent en prenant en compte les éléments pouvant le bloquer
    /// </summary>
    /// <param name="mushrooms">Les champignons pouvant bloquer le serpent</param>
    /// <returns>Retourne faux si le serpent est entièrement en dehors de l'écran ou de longueur nulle.
    ///          Retourne faux sinon.
    /// </returns>
    public bool Update(List<Mushroom> mushrooms)
    {
      //Si le serpent a une longueur nulle...
      if (bodyParts.Count() == 0)
        return false;

      //On récupère la position de la tête du serpent
      Point newPart = bodyParts[bodyParts.Count() - 1];
      //On déplace dans le sens du mouvement la nouvelle tête du serpent
      newPart.X += (int)direction;

      //Pour chaque champignon du jeu...
      foreach (Mushroom mushroom in mushrooms)
      {
        //Si la nouvelle tête est à la même place que le nouveau champignon...
        if (newPart.X == mushroom.XPosition && newPart.Y == mushroom.YPosition)
        {
          //On vas vers le bas
          GoDown(ref newPart);
          break;
        }
      }

      //Si la tête est trop à gauche ou trop à droite...
      if (newPart.X < 0 || newPart.X >= MillipedeGame.NB_HORIZONTAL_BLOCKS)
      {
        //On vas vers le bas
        GoDown(ref newPart);
      }

      //Si la tête est trop basse...
      if (newPart.Y > MillipedeGame.NB_VERTICAL_BLOCKS)
      {
        //On suprime le reste du corpŝ
        bodyParts.Clear();
      }
      else
      {
        //On ajoute la nouvelle tête
        bodyParts.Add(newPart);
        //On retire l'ancienne queue
        bodyParts.RemoveAt(0);
      }

      return true;
    }

    /// <summary>
    /// Déplace la partie du serpent spécifié vers le bas
    /// </summary>
    /// <param name="pt">La partie du serpent à déplacer vers le bas</param>
    private void GoDown(ref Point pt)
    {
      //On annule le dernier déplacement de la partie du serpent spécifié
      pt.X -= (int)direction;
      //On le déplace vers le bas la partie du serpent spécifié
      pt.Y++;

      //On inverse la direction
      if (direction == Direction.Left)
        direction = Direction.Right;
      else
        direction = Direction.Left;
    }

    /// <summary>
    /// Permet d'accéder à une partie du serpent en lecture seulement
    /// </summary>
    /// <param name="index">L'indice de base zéro de la partie du serpent que l'on souhaite
    ///                     accéder en lecture seulement.
    /// </param>
    /// <returns></returns>
    public Point this[int index]
    {
      get
      {
        //Si l'indice n'est pas dans les limites du tableau...
        if (index < 0 || index > bodyParts.Count())
        {
          //On lance une erreur
          throw new ArgumentOutOfRangeException("Ce morceau de serpent n'existe pas");
        }

        return bodyParts[index];
      }
    }
  }
}
//</Charles Lachance>