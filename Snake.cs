using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public Vector2D movementVector { get; set; }

        public Vector2D head { get; }

        public List<Vector2D> body { get; }

        public Snake(Vector2D startingHeadPosition, int startingSegmentCount, Vector2D startingDirection)
        {
            head = new Vector2D(startingHeadPosition);
            this.movementVector = startingDirection;
            body = new List<Vector2D>();

            for (int i = 0; i < startingSegmentCount; i++)
            {
                eat();
            }
        }

        public void eat()
        {
            Vector2D newSegmentPosition = new Vector2D(0, 0);
            if (body.Count <= 0)
            {
                newSegmentPosition.addToVector(head);
            }
            else
            {
                newSegmentPosition = body[body.Count - 1];
            }

            body.Add(new Vector2D(newSegmentPosition));
        }

        public void move()
        {
            for (int i = body.Count - 1; i >= 1; i--)
            {
                body[i] = body[i - 1];
            }
            if (body.Count > 0)
            {
                body[0] = new Vector2D(head);
            }
            head.addToVector(this.movementVector);
        }

        public bool headCollidesWithBody()
        {
            for (int i = 0; i < body.Count; i++)
            {
                if (head.compareToVector(body[i])) return true;
            }
            return false;
        }

        public bool collidesWithHead(Vector2D position)
        {
            return head.compareToVector(position);
        }
    }
}
