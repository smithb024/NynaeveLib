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

    /// <summary>
    /// Raise an event to indicate that a property has changed.
    /// </summary>
    /// <param name="propertyName">property name</param>
    void RaisePropertyChangedEvent(string propertyName);
  }
}