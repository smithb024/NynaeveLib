namespace NynaeveLib.Commands
{
  using System;
  using System.Windows.Input;

  public class CommonCommand<T> : ICommand
  {
    public CommonCommand(Action<T> command)
      : this(command, null)
    {
    }

    public CommonCommand(
      Action<T> command,
      Predicate<T> canExecuteCommand)
    {
      this.RunCommand = command;
      this.CanRunCommand = canExecuteCommand;
    }

    /// <summary>
    /// Run command action.
    /// </summary>
    public Action<T> RunCommand
    {
      get;
      private set;
    }

    /// <summary>
    /// Can run command function.
    /// </summary>
    public Predicate<T> CanRunCommand
    {
      get;
      private set;
    }

    /// <summary>
    /// Determine if the command can be run.
    /// </summary>
    /// <param name="parameter">not used</param>
    /// <returns>always true</returns>
    public bool CanExecute(object parameter)
    {
      return this.CanRunCommand == null ? true : this.CanRunCommand((T)parameter);
    }

    /// <summary>
    /// Can execute changed event.
    /// </summary>
    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
      this.RunCommand((T)parameter);
    }
  }
}
