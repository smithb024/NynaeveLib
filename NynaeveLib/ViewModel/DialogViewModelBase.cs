namespace NynaeveLib.ViewModel
{
  using System;
  using System.ComponentModel;
  using System.Windows;

  using NynaeveLib.DialogService.Interfaces;

  public class DialogViewModelBase : ViewModelBase, IDialogViewModelBase
  {
    private MessageBoxResult result;

    /// <summary>
    /// Initialises a new instance of the <see cref="ViewModelBase"/> class.
    /// </summary>
    public DialogViewModelBase()
      : base()
    {
    }

    public MessageBoxResult Result
    {
      get
      {
        return this.result;
      }

      set
      {
        this.result = value;
      }
    }
  }
}