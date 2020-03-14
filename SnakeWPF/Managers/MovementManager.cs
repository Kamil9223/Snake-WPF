using SnakeWPF.Models;
using SnakeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF.Managers
{
    public enum Movement { NoMove, Left, Right, Up, Down };


    public class MovementManager
    {
        private readonly SnakeViewModel snakeVM;
        private readonly FoodViewModel foodVM;
        public Movement currentMoveDirection;

        public MovementManager(SnakeViewModel snakeVM, FoodViewModel foodVM)
        {
            this.snakeVM = snakeVM;
            this.foodVM = foodVM;
        }

        public void MoveAction(Movement movement, int translationValue)
        {
            snakeVM.Timer.RemoveHandlers();
            snakeVM.Timer.dispatcherTimer.Tick += (sender, e) =>
            {
                snakeVM.previousY = snakeVM.HeadY;
                snakeVM.previousX = snakeVM.HeadX;

                SetDirection(movement, translationValue);

                var lastTailElement = MoveTail();

                snakeVM.collisionManager.CollisionAction(snakeVM, foodVM, lastTailElement);
            };
        }

        private void SetDirection(Movement movement, int translationValue)
        {
            if (movement == Movement.Left || movement == Movement.Right)
            {
                if (currentMoveDirection == Movement.Left && movement == Movement.Right ||
                    currentMoveDirection == Movement.Right && movement == Movement.Left)
                {
                    snakeVM.HeadX -= translationValue;
                    return;
                }

                snakeVM.HeadX += translationValue;
            }
               
            else if (movement == Movement.Up || movement == Movement.Down)
            {
                if (currentMoveDirection == Movement.Up && movement == Movement.Down ||
                    currentMoveDirection == Movement.Down && movement == Movement.Up)
                {
                    snakeVM.HeadY -= translationValue;
                    return;
                }

                snakeVM.HeadY += translationValue;
            }

            currentMoveDirection = movement;
        }

        private SnakeElement MoveTail()
        {
            if (!snakeVM.GuiTail.Any())
                return null;

            var lastElement = snakeVM.GuiTail.Last();
            var prevStates = new List<SnakeElement>();

            for (int i = 0; i < snakeVM.GuiTail.Count; i++)
            {
                prevStates.Add(snakeVM.GuiTail[i]);
                if (i == 0)
                {
                    snakeVM.GuiTail[i] = new SnakeElement(snakeVM.previousX, 
                        snakeVM.previousY, snakeVM.Width, snakeVM.Height);
                }
                else
                {
                    snakeVM.GuiTail[i] = new SnakeElement(prevStates[i - 1].X,
                        prevStates[i - 1].Y, snakeVM.Width, snakeVM.Height);
                }
            }

            return lastElement;
        }
    }
}
