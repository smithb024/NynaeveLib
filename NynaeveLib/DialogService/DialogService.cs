namespace NynaeveLib.DialogService
{
  using System.Windows;
  using Interfaces;

  public class DialogService : IDialogService
  {
    public void ShowDialog(Window window)
    {
      window.Owner = Application.Current.MainWindow;
      window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      window.ShowDialog();
    }

    public MessageBoxResult ShowDialog(string message)
    {
      return this.ShowDialog(null, string.Empty, message, MessageBoxButton.OK);
    }

    public MessageBoxResult ShowDialog(string message, MessageBoxButton buttons)
    {
      return this.ShowDialog(null, string.Empty, message, buttons);
    }

    public MessageBoxResult ShowDialog(Window owner, string message)
    {
      return this.ShowDialog(owner, string.Empty, message, MessageBoxButton.OK);
    }

    public MessageBoxResult ShowDialog(
      Window owner,
      string message,
      MessageBoxButton buttons)
    {
      return this.ShowDialog(owner, string.Empty, message, buttons);
    }

    public MessageBoxResult ShowDialog(
      Window owner,
      string title,
      string message,
      MessageBoxButton buttons)
    {
      if (owner == null)
      {
        owner = Application.Current.MainWindow;
      }

      CommonDialogViewModel viewModel = new CommonDialogViewModel(title, message, buttons);

      CommonDialog dialog = new CommonDialog()
      {
        Owner = owner,
        WindowStartupLocation = WindowStartupLocation.CenterOwner,
        DataContext = viewModel
      };

      dialog.ShowDialog();

      return viewModel.Result;
    }
  }
}
