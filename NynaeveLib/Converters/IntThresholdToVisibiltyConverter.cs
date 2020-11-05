namespace NynaeveLib.Converters
{
  using System;
  using System.Globalization;
  using System.Collections.ObjectModel;
  using System.Windows;
  using System.Windows.Data;

  public class IntThresholdToVisibiltyConverter : IValueConverter
  {
    public IntThresholdToVisibiltyConverter()
    {
      this.Threshold = 1;
      this.AboveIsVisible = true;
    }

    public int Threshold { get; set; }
    public bool AboveIsVisible { get; set; }

    public object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (value == null ||
        value.GetType() != typeof(int))
      {
        return Visibility.Collapsed;
      }

      bool calcAboveVisible =
        (int)value > this.Threshold;

      if (this.AboveIsVisible)
      {
        return calcAboveVisible ? Visibility.Visible : Visibility.Collapsed;
      }
      else
      {
        return !calcAboveVisible ? Visibility.Visible : Visibility.Collapsed;
      }
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