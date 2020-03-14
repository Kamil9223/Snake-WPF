using SnakeWPF.Models;
using SnakeWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWPF.Managers
{
    public class CollisionManager
    {
        public bool IsCollision(SnakeViewModel snakeVM, FoodViewModel foodVM)
        {
            return (snakeVM.HeadX + snakeVM.Width > foodVM.X && 
                snakeVM.HeadX < foodVM.X + foodVM.Width &&
                snakeVM.HeadY < foodVM.Y + foodVM.Height &&
                snakeVM.HeadY + snakeVM.Height > foodVM.Y);
        }

        public void CollisionAction(SnakeViewModel snakeVM, FoodViewModel foodVM, SnakeElement lastElement)
        {
            if (!IsCollision(snakeVM, foodVM))
                return;

            foodVM.GenerateNewPosition();
            snakeVM.TailExtend(lastElement);
        }
    }
}
