using SnakeWPF.Commands;
using SnakeWPF.Managers;
using SnakeWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeWPF.ViewModels
{
    public class FoodViewModel : BaseViewModel
    {
        private readonly Food food;
        private Random random;
        private WindowViewModel windomVM;

        public FoodViewModel()
        {
            random = new Random();
            windomVM = new WindowViewModel();
            food = new Food(
                random.Next(0, (int)((windomVM.BoardWidth-20) / 20)) * 20, 
                random.Next(0, (int)((windomVM.WindowHeight-20) / 60)) * 20,
                20, 20
            );
        }
        
        public int X
        {
            get { return food.X; }
            set
            {
                food.X = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get { return food.Y; }
            set
            {
                food.Y = value;
                OnPropertyChanged("Y");
            }
        }

        public int Width { get { return food.Width; } }
        public int Height { get { return food.Height; } }

        public Food GetFood()
        {
            return this.food;
        }

        public void GenerateNewPosition()
        {
            X = random.Next(0, (int)((windomVM.BoardWidth - 20) / 20)) * 20;
            Y = random.Next(0, (int)((windomVM.WindowHeight - 60) / 20)) * 20;
        }
    }
}
