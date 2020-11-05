namespace NynaeveLib.Enumerations.Converters
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Windows;
  using System.Windows.Data;
  using NynaeveLib.Utils;

  /// <summary>
  /// Converts a string to a visibility
  /// </summary>
  public class StringToVisCollapsedVisibilityConverter : IValueConverter
  {
    public StringToVisCollapsedVisibilityConverter()
    {
      this.Hidden = false;
      this.AssessmentString = string.Empty;
    }

    /// <summary>
    /// Set to hide.
    /// </summary>
    /// <remarks>
    /// Default is unset, ie collapse.
    /// </remarks>
    public bool Hidden
    {
      get;
      set;
    }

    /// <summary>
    /// String to compare against. If the value does not equal this then visisble is to be
    /// returned.
    /// </summary>
    public string AssessmentString
    {
      get;
      set;
    }

    /// <summary>
    /// Convert a string to a visibility
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="targetType">not used</param>
    /// <param name="parameter">not used</param>
    /// <param name="culture">not used</param>
    /// <returns>visibility value</returns>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value == null || value.GetType() != typeof(string))
      {
        return this.NotVisibile();
      }

      string check = (string)value;

      if (StringCompare.CompareEmpty(this.AssessmentString))
      {
        return StringCompare.CompareNullOrEmpty(check) ? this.NotVisibile() : Visibility.Visible;
      }

      return StringCompare.SimpleCompare(check, AssessmentString) ? this.NotVisibile() : Visibility.Visible;
    }

    /// <summary>
    /// Not used
    /// </summary>
    /// <param name="value">not used</param>
    /// <param name="targetType">not used</param>
    /// <param name="parameter">not used</param>
    /// <param name="culture">not used</param>
    /// <returns>not used</returns>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Choose type of not visible visibility.
    /// </summary>
    /// <returns>return visibility</returns>
    private Visibility NotVisibile()
    {
      return Hidden ? Visibility.Hidden : Visibility.Collapsed;
    }
  }
}
