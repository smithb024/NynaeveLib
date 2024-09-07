namespace NynaeveLib.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Value converter which is used to convert an integer into a visibility
    /// </summary>
    public class IntThresholdToVisibiltyConverter : IValueConverter
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IntThresholdToVisibiltyConverter"/> class.
        /// </summary>
        public IntThresholdToVisibiltyConverter()
        {
            this.Threshold = 1;
            this.AboveIsVisible = true;
        }

        /// <summary>
        /// Gets or sets the threshold value.
        /// </summary>
        public int Threshold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value above the threshold is visible or 
        /// the opposite.
        /// </summary>
        public bool AboveIsVisible { get; set; }

        /// <summary>
        /// Convert the value to an visibility
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="targetType">Target type is not used.</param>
        /// <param name="parameter">Parameter is not used</param>
        /// <param name="culture">Culture is not used</param>
        /// <returns>The converted visibility</returns>
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

        /// <summary>
        /// Convert back is not implemented
        /// </summary>
        /// <param name="value">value is not used</param>
        /// <param name="targetType">target type is not used</param>
        /// <param name="parameter">paramter is not used</param>
        /// <param name="culture">culture is not used</param>
        /// <returns>Nothing is returned</returns>
        /// <exception cref="NotImplementedException">
        /// This exception is always thrown.
        /// </exception>
        public object[] ConvertBack(
          object value,
          Type targetType,
          object parameter,
          CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert back is not implemented
        /// </summary>
        /// <param name="value">value is not used</param>
        /// <param name="targetType">target type is not used</param>
        /// <param name="parameter">paramter is not used</param>
        /// <param name="culture">culture is not used</param>
        /// <returns>Nothing is returned</returns>
        /// <exception cref="NotImplementedException">
        /// This exception is always thrown.
        /// </exception>
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