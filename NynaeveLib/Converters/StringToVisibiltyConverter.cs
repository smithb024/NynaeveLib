namespace NynaeveLib.Converters
{
  using System;
  using System.Globalization;
  using System.Windows;
  using System.Windows.Data;

  public class StringToVisibilityConverter : IValueConverter
  {
    public StringToVisibilityConverter()
    {
      this.InvisibleValue = "0";
    }

    public string InvisibleValue
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

      if (value.GetType() != typeof(string))
      {
        return Visibility.Collapsed;
      }

      string testValue = (string)value;

      return 
        string.Compare(testValue, this.InvisibleValue, false) == 0 ?
        Visibility.Collapsed :
        Visibility.Visible;
    }

    public object[] ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    object IValueConverter.ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}