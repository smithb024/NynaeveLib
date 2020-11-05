namespace NynaeveLib.DialogService.Interfaces
{
  using System.Windows;

  public interface ICommonDialogBox
  {
    string Title { get; }

    string Message { get; }

    MessageBoxButton Buttons { get; }

    MessageBoxResult Result { get; }
  }
}
