namespace NynaeveLib.DialogService.Interfaces
{
  using System.Windows;

  /// <summary>
  /// Message box results.
  /// </summary>
  public interface IResult
  {
    /// <summary>
    /// Gets or sets the result.
    /// </summary>
    MessageBoxResult Result { get; set; }
  }
}
