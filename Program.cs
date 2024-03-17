using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
namespace Snake
{
    class Program
    {
        static int verticalTileCount = 16;
        static int horizontalTileCount = 32;
        static Vector2D borderDimensions = new Vector2D(horizontalTileCount, verticalTileCount);

        static int initialBodyLength = 5;

        static int delayBetweenMovementsMs = 500;

        static void Main(string[] args)
        {
            Renderer renderer = new ConsoleRenderer();
            renderer.setScreenSize(verticalTileCount, horizontalTileCount);
            
            int score = 5;
            bool gameover = false;

            Snake snake = new Snake(calculateScreenCenterPoint(), initialBodyLength, Directions.Right);
            Food food = new Food(randomPosition(borderDimensions));

            DateTime timeBefore = DateTime.Now;
            DateTime timeDuring = DateTime.Now;
            bool buttonPressed = false;

            while (!gameover)
            {
                renderer.clearScreen();
                renderer.renderBorders(borderDimensions);

                if (snake.head.compareToVector(food.position))
                {
                    score++;
                    food.position = randomPosition(borderDimensions);
                    snake.eat();
                }

                renderer.renderSnake(snake);
                renderer.renderFood(food);

                timeBefore = DateTime.Now;

                buttonPressed = false;

                while (true)
                {
                    timeDuring = DateTime.Now;
                    if (timeDuring.Subtract(timeBefore).TotalMilliseconds > delayBetweenMovementsMs) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                        if (!buttonPressed)
                        {
                            Vector2D newMovementVector = new Vector2D(0, 0);
                            if (pressedKey.Key.Equals(ConsoleKey.UpArrow))
                            {
                                newMovementVector = Directions.Up;
                                buttonPressed = true;
                            }
                            if (pressedKey.Key.Equals(ConsoleKey.DownArrow))
                            {
                                newMovementVector = Directions.Down;
                                buttonPressed = true;
                            }
                            if (pressedKey.Key.Equals(ConsoleKey.LeftArrow))
                            {
                                newMovementVector = Directions.Left;
                                buttonPressed = true;
                            }
                            if (pressedKey.Key.Equals(ConsoleKey.RightArrow))
                            {
                                newMovementVector = Directions.Right;
                                buttonPressed = true;
                            }

                            Vector2D compareVector = new Vector2D(snake.movementVector);
                            compareVector.addToVector(newMovementVector);
                            if(!compareVector.compareToVector(new Vector2D(0, 0)))
                            {
                                snake.movementVector = newMovementVector;
                            }
                        }
                        
                    }
                }
                snake.move();

                if (!(0 < snake.head.xPosition && snake.head.xPosition < horizontalTileCount - 1)) gameover = true;
                else if (!(0 < snake.head.yPosition && snake.head.yPosition < verticalTileCount - 1)) gameover = true;
                else gameover = snake.headCollidesWithBody();
            }
            renderer.renderText(new Vector2D(horizontalTileCount / 5, verticalTileCount / 2),"Game over, Score: " + score);
        }

        private static Vector2D calculateScreenCenterPoint()
        {
            return new Vector2D(horizontalTileCount/2, verticalTileCount/2);
        }

        private static Vector2D randomPosition(Vector2D screenDimensions)
        {
            Random random = new Random();
            return new Vector2D(random.Next(1, screenDimensions.xPosition - 1), random.Next(1, screenDimensions.yPosition - 1));
        }
    }  
}
