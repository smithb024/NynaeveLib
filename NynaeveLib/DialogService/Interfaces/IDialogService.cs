using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NynaeveLib.DialogService.Interfaces
{
  using System.Windows;

  public interface IDialogService
  {
    void ShowDialog(Window window);

    MessageBoxResult ShowDialog(
      Window owner,
      string title,
      string message,
      MessageBoxButton buttons);

    MessageBoxResult ShowDialog(
      Window owner,
      string message,
      MessageBoxButton buttons);

    MessageBoxResult ShowDialog(
      Window owner,
      string message);

    MessageBoxResult ShowDialog(
      string message,
      MessageBoxButton button);

    MessageBoxResult ShowDialog(string message);
  }
}
