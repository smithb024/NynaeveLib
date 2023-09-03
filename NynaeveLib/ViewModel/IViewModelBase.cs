namespace NynaeveLib.ViewModel
{
  using System;
  using System.ComponentModel;

  public interface IViewModelBase : INotifyPropertyChanged
  {
    /// <summary>
    /// view close request event handler
    /// </summary>
    event EventHandler ClosingRequest;
  }
}