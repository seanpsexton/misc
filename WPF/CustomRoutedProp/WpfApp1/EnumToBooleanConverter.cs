using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1
{
    public class EnumToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the result of the ConvertBack if the value is false. 
        /// </summary>
        public object False { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = Binding.DoNothing;

            if (value.Equals(true))
            {
                result = parameter;
            }
            else if (False != null)
            {
                result = False;
            }

            return result;
        }
    }
}
