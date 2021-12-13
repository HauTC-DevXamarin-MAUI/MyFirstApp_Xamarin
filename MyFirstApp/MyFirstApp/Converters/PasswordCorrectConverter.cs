using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyFirstApp.Converters
{
    public class PasswordCorrectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return isPasswordCorrect(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool isPasswordCorrect(object value)
        {
            if (value is string)
            {
                bool isPass = Regex.IsMatch(
                    (string)value, "^(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

                int length = ((string)value).Trim().Length;

                if (length >= 7 && length <= 60 && isPass)
                    return true;
                else
                    return false;

            }
            return false;
        }
    }
}
