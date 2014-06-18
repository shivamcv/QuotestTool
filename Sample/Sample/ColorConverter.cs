using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Sample
{
   public class ColorConverter:IValueConverter
    {
       static double LastValue; 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            double currentValue;

            double.TryParse(value.ToString(), out currentValue);

            SolidColorBrush result;

            if (currentValue > LastValue)
            {
                result = new SolidColorBrush(Colors.Green);
            }
            else
                result = new SolidColorBrush(Colors.Red);


            LastValue = currentValue;

            return result;


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
