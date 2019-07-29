using SnakeWPF.Commands;
using SnakeWPF.Managers;
using SnakeWPF.Models;
using System.Windows.Input;

namespace SnakeWPF.ViewModels
{
    class SnakeViewModel : BaseViewModel
    {
        private readonly Snake snake;
        private readonly Timer timer;

        public ICommand leftCommand { get; }
        public ICommand rightCommand { get; }
        public ICommand upCommand { get; }
        public ICommand downCommand { get; }

        public SnakeViewModel()
        {
            snake = new Snake(0, 0);
            timer = new Timer();
            timer.dispatcherTimer.Start();

            leftCommand = new RelayCommand(LeftAction, () => true);
            rightCommand = new RelayCommand(RightAction, () => true);
            upCommand = new RelayCommand(UpAction, () => true);
            downCommand = new RelayCommand(DownAction, () => true);
        }

        public int HeadX
        {
            get { return snake.Head.X; }
            set
            {
                snake.Head.X = value;
                OnPropertyChanged("HeadX");
            }
        }

        public int HeadY
        {
            get { return snake.Head.Y; }
            set
            {
                snake.Head.Y = value;
                OnPropertyChanged("HeadY");
            }
        }

        private void LeftAction()
        {
            timer.RemoveHandlers();
            timer.dispatcherTimer.Tick += (sender, e) => { HeadX -= 20; };
        }

        private void RightAction()
        {
            timer.RemoveHandlers();
            timer.dispatcherTimer.Tick += (sender, e) => { HeadX += 20; };
        }

        private void UpAction()
        {
            timer.RemoveHandlers();
            timer.dispatcherTimer.Tick += (sender, e) => { HeadY -= 20; };
        }

        private void DownAction()
        {
            timer.RemoveHandlers();
            timer.dispatcherTimer.Tick += (sender, e) => { HeadY += 20; };
        }
    }
}
