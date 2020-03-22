using SnakeWPF.Managers;
using SnakeWPF.Views;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SnakeWPF.Converters
{
    public class ApplicationPageConverter : MarkupExtension, IValueConverter
    {
        private static ApplicationPageConverter pageConverter = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((PageDefinition)value)
            {
                case PageDefinition.Board:
                    return new Board();
                case PageDefinition.SideBar:
                    return new SideMenu();
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return pageConverter ?? (pageConverter = new ApplicationPageConverter());
        }
    }
}
