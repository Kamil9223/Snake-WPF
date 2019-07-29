using SnakeWPF.Models;

namespace SnakeWPF.ViewModels
{
    class WindowViewModel : BaseViewModel
    {
        private readonly Window window;

        public WindowViewModel()
        {
            window = new Window();
        }

        public double WindowWidth { get { return window.Width; } }
        public double WindowHeight { get { return window.Height; } }
    }
}
