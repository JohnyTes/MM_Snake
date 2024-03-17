using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public interface Renderer
    {
        public void clearScreen();
        public void setScreenSize(int height, int width);
        public void renderSnake(Snake snake);
        public void renderFood(Food food);
        public void renderBorders(Vector2D borderSize);
        public void renderText(Vector2D position, string message);
    }
}
