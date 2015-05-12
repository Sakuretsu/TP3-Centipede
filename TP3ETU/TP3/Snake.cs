
//<Charles Lachance>
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TP3
{
  class Snake
  {
    private List<Point> bodyParts = null;
    private int maxLength = 0;
    private Direction direction = Direction.Undefined;

    public void Draw(Graphics g)
    {
      foreach (Point part in bodyParts)
      {
        g.DrawImage(Properties.Resources.SnakePart, part.X * MillipedeGame.OBJECT_SIZE, part.Y * MillipedeGame.OBJECT_SIZE);
      }
    }

    public Snake(int length)
    {
      if (length < 0)
      {
        throw new ArgumentOutOfRangeException("La longueur du serpent ne peut pas être négative");
      }

      bodyParts = new List<Point>(0);
      for (int i = 0; i < length; i++)
      {
        bodyParts.Add(new Point(35, 0));
      }

      direction = Direction.Left;
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

      if (newPart.X < 0 || newPart.X >= MillipedeGame.NB_HORIZONTAL_BLOCKS)
      {
        newPart.X -= (int)direction;
        newPart.Y++;

        if (direction == Direction.Left)
          direction = Direction.Right;
        else
          direction = Direction.Left;
      }
      else
      {
        foreach (Mushroom mushroom in mushrooms)
        {
          if (newPart.X == mushroom.XPosition && newPart.Y == mushroom.YPosition)
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
      }
      

      bodyParts.Add(newPart);

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
//</Charles Lachance>