using SnakeWPF.Commands;
using SnakeWPF.Managers;
using SnakeWPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnakeWPF.ViewModels
{
    public class SnakeViewModel : BaseViewModel
    {
        private SnakeElement snakeHead;
        public Timer Timer { get; }
        public CollisionManager collisionManager;
        public LocatorViewModel Locator;
        public MovementManager MovementManager;

        public int previousX;
        public int previousY;

        public ICommand leftCommand { get; }
        public ICommand rightCommand { get; }
        public ICommand upCommand { get; }
        public ICommand downCommand { get; }

        public SnakeViewModel()
        {
            snakeHead = new SnakeElement(0, 0, 20, 20);
            collisionManager = new CollisionManager();
            Timer = new Timer();
            Timer.dispatcherTimer.Start();
            Locator = new LocatorViewModel();
            MovementManager = new MovementManager(this, Locator.Food);

            leftCommand = new RelayCommand(LeftAction, () => true);
            rightCommand = new RelayCommand(RightAction, () => true);
            upCommand = new RelayCommand(UpAction, () => true);
            downCommand = new RelayCommand(DownAction, () => true);

            GuiTail = new ObservableCollection<SnakeElement>();
        }

        public int HeadX
        {
            get { return snakeHead.X; }
            set
            {
                snakeHead.X = value;
                OnPropertyChanged("HeadX");
            }
        }

        public int HeadY
        {
            get { return snakeHead.Y; }
            set
            {
                snakeHead.Y = value;
                OnPropertyChanged("HeadY");
            }
        }

        public int Width { get { return snakeHead.Width; } }
        public int Height { get { return snakeHead.Height; } }

        private ObservableCollection<SnakeElement> guiTail;
        public ObservableCollection<SnakeElement> GuiTail
        {
            get { return guiTail; }
            set
            {
                guiTail = value;
                OnPropertyChanged("GuiTail");
            }
        }

        private void LeftAction()
        {
            MovementManager.MoveAction(Movement.Left, -20);
        }

        private void RightAction()
        {
            MovementManager.MoveAction(Movement.Right, 20);
        }

        private void UpAction()
        {
            MovementManager.MoveAction(Movement.Up, -20);
        }

        private void DownAction()
        {
            MovementManager.MoveAction(Movement.Down, 20);
        }

        public void TailExtend()
        {
            if (!GuiTail.Any())
            {
                GuiTail.Add(new SnakeElement
                {
                    X = previousX,
                    Y = previousY,
                    Height = this.Height,
                    Width = this.Width
                });
                return;
            }
            var lastElement = GuiTail.Last();
            GuiTail.Add(new SnakeElement
            {
                X = lastElement.X,
                Y = lastElement.Y,
                Height = this.Height,
                Width = this.Width
            });
        }

        public void SetToBeginningState()
        {
            GuiTail.Clear();
            HeadX = 0;
            HeadY = 0;
            Timer.RemoveHandlers();
        }
    }
}
