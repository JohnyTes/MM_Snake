using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food
    {
        public Vector2D position {  get; set; }

        public Food(Vector2D position) { 
            this.position = position;
        }
    }
}
