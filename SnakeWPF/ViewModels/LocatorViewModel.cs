using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace SnakeWPF.ViewModels
{
    public class LocatorViewModel
    {
        static LocatorViewModel()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<WindowViewModel>();
            SimpleIoc.Default.Register<SnakeViewModel>();
            SimpleIoc.Default.Register<FoodViewModel>();
        }

        public SnakeViewModel Snake
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SnakeViewModel>();
            }
        }

        public FoodViewModel Food
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FoodViewModel>();
            }
        }

        public WindowViewModel WindowOptions
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WindowViewModel>();
            }
        }
    }
}
