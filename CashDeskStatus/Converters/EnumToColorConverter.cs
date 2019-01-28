using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using CashDeskApi.Models;

namespace CashDeskStatus.Converters
{
    public class EnumToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Enum))
                throw new ArgumentException("value not of type Enum");
            Enum enumToConv = (Enum)value;

            switch (enumToConv)
            {
                case CashDeskState.Green:
                    return new SolidColorBrush(Colors.LimeGreen);
                case CashDeskState.Red:
                    return new SolidColorBrush(Colors.Red);
                case CashDeskState.Gray:
                    return new SolidColorBrush(Colors.LightGray);
                default: return Colors.White;  
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
