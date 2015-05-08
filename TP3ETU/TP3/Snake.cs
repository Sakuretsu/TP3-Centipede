using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
  class Snake
  {
    private List<Point> bodyParts = null;
    private int maxLength = 0;
    private Direction direction = Direction.Undefined;

    public void Draw(Graphics g)
    {
      foreach (Point parts in bodyParts)
      {
        g.DrawImage(Properties.Resources.SnakePart, parts);
      }
    }

    public Snake(int length)
    {
      if (length < 0)
      {
        throw new ArgumentOutOfRangeException("La longueur du serpent ne peut pas être négative");
      }

      bodyParts = new List<Point>(length);
    }

    public void Split(Point pt, Snake splittedSnake1, Snake splittedSnake2)
    {
      for (int i = 0; i < bodyParts.Count(); i++)
      {
        if (bodyParts[i] != null)
        {
          if (bodyParts[i] != pt)
          {
            splittedSnake1.bodyParts.Add(bodyParts[i]);
          }
          else
          {
            for (int j = i + 1; j < bodyParts.Count; j++)
            {
              splittedSnake2.bodyParts.Add(bodyParts[j]);
            }

            break;
          }
        }
      }
    }

    public void Update(List<Mushroom> mushrooms)
    {
      Point newPart = bodyParts[bodyParts.Count() - 1];
      newPart.X += (int)direction;

      foreach (Mushroom mushroom in mushrooms)
      {
        if (newPart.X == mushroom.XPosition)
        {
          newPart.X -= (int)direction;
          newPart.Y++;

          if (direction == Direction.Left)
            direction = Direction.Right;
          else
            direction = Direction.Left;

          break;
        }
      }

      bodyParts.Add(newPart);

      if (bodyParts.Capacity == bodyParts.Count)
        bodyParts.RemoveAt(0);
    }

    public Point this[int index]
    {
      get
      {
        if (index < 0 || index > bodyParts.Count())
        {
          throw new ArgumentOutOfRangeException("Ce morceau de serpent n'existe pas");
        }

        return bodyParts[index];
      }

      private set { }
    }

    private Snake()
    {

    }
  }
}
