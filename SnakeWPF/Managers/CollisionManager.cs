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
        private bool IsCollisionWithFood(SnakeViewModel snakeVM, FoodViewModel foodVM)
        {
            return (snakeVM.HeadX + snakeVM.Width > foodVM.X && 
                snakeVM.HeadX < foodVM.X + foodVM.Width &&
                snakeVM.HeadY < foodVM.Y + foodVM.Height &&
                snakeVM.HeadY + snakeVM.Height > foodVM.Y);
        }

        private bool IsCollisionWithBorder(SnakeViewModel snakeVM, WindowViewModel windowVM)
        {
            return (snakeVM.HeadX < 0 ||
                snakeVM.HeadX + snakeVM.Width > windowVM.WindowWidth ||
                snakeVM.HeadY < 0 ||
                snakeVM.HeadY + snakeVM.Height > windowVM.WindowHeight);
        }

        public void CollisionAction(SnakeViewModel snakeVM, FoodViewModel foodVM, WindowViewModel windowVM)
        {
            if (IsCollisionWithFood(snakeVM, foodVM))
            {
                foodVM.GenerateNewPosition();
                snakeVM.TailExtend();
            }

            if (IsCollisionWithBorder(snakeVM, windowVM))
            {
                //action game over from GameManager
            }
        }
    }
}
