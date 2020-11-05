namespace NynaeveLib.ViewModel
{
  using System;
  using System.ComponentModel;

  public class ViewModelBase : IViewModelBase, INotifyPropertyChanged
  {
    /// <summary>
    /// Initialises a new instance of the <see cref="ViewModelBase"/> class.
    /// </summary>
    public ViewModelBase()
    {
    }

    /// <summary>
    /// property changed event handler
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// view close request event handler
    /// </summary>
    public event EventHandler ClosingRequest;

    /// <summary>
    /// Raise an event to indicate that a property has changed.
    /// </summary>
    /// <param name="propertyName">property name</param>
    public void RaisePropertyChangedEvent(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Request that the view is closed.
    /// </summary>
    protected void OnClosingRequest()
    {
        if (this.ClosingRequest != null)
        {
            this.ClosingRequest(this, EventArgs.Empty);
        }
    }
  }
}