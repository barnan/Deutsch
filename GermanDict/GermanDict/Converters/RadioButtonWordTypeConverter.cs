using GermanDict.Interfaces;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GermanDict.Converters
{
    public class RadioButtonWordTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WordType selectedWordType = (WordType)value;
            string text = (string)parameter;
            if (selectedWordType.ToString() == text)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WordType inputAsEnum = (WordType)Enum.Parse(typeof(WordType), (string)parameter, true);

            return inputAsEnum;
        }
    }
}
