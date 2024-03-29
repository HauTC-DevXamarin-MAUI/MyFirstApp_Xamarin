﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MyFirstApp.Converters
{
    class UsernameCorrectToHideLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return isUserNameCorrect(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private bool isUserNameCorrect(object value)
        {
            if (value == null || ((string)value).Length == 0)
                return true;

            if (value is string)
            {
                int length = ((string)value).Trim().Length;
                if (length >= 8 && length <= 60)
                    return true;
                else
                    return false;

            }
            return false;
        }
    }
}
