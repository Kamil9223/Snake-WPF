using SnakeWPF.Managers;
using SnakeWPF.Models;

namespace SnakeWPF.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        private readonly Window window;

        public WindowViewModel()
        {
            window = new Window();
        }

        public double WindowWidth { get { return window.Width; } }
        public double WindowHeight { get { return window.Height; } }

        public PageDefinition BoardPage { get { return PageDefinition.Board; } }
        public PageDefinition SideMenu { get { return PageDefinition.SideBar; } }
    }
}
