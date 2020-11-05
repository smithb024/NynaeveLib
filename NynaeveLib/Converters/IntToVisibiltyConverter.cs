namespace NynaeveLib.Converters
{
  using System;
  using System.Globalization;
  using System.Collections.ObjectModel;
  using System.Windows;
  using System.Windows.Data;

  public class IntToVisibilityConverter : IValueConverter
  {
    public IntToVisibilityConverter()
    {
      this.InvisibleValue = 0;
    }

    public int InvisibleValue
    {
      get;
      set;
    }

    public object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (value == null)
      {
        return Visibility.Collapsed;
      }

      if (value.GetType() != typeof(int))
      {
        return Visibility.Collapsed;
      }

      int testValue = (int)value;

      return testValue == this.InvisibleValue ? Visibility.Collapsed : Visibility.Visible;
    }

    public object[] ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}