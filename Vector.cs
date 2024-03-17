using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Vector2D
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }

        public Vector2D(int xPosition, int yPosition)
        {
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }

        public Vector2D(Vector2D toCopy)
        {
            xPosition = toCopy.xPosition;
            yPosition = toCopy.yPosition;
        }

        public void addToVector(Vector2D toAdd)
        {
            xPosition += toAdd.xPosition;
            yPosition += toAdd.yPosition;
        }

        public bool compareToVector(Vector2D toCompare)
        {
            return xPosition == toCompare.xPosition && yPosition == toCompare.yPosition;
        }
    }

    static class Directions
    {
        public static Vector2D Up = new Vector2D(0, -1);
        public static Vector2D Down = new Vector2D(0, 1);
        public static Vector2D Left = new Vector2D(-1, 0);
        public static Vector2D Right = new Vector2D(1, 0);
    }
}
