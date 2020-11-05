using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NynaeveLib.DialogService
{
  using System.Windows;
  using System.Windows.Input;

  using Commands;
  using Interfaces;
  using NynaeveLib.ViewModel;

  public class CommonDialogViewModel : ViewModelBase, ICommonDialogBox
  {
    private string title;
    private string message;
    private MessageBoxButton buttons;
    private MessageBoxResult result;

    public CommonDialogViewModel(
      string title,
      string message,
      MessageBoxButton buttons)
    {

      this.title = title;
      this.message = message;
      this.buttons = buttons;

      this.OkCommand = new CommonCommand<ICloseable>(this.SetOk);
      this.YesCommand = new CommonCommand<ICloseable>(this.SetYes);
      this.NoCommand = new CommonCommand<ICloseable>(this.SetNo);
      this.CancelCommand = new CommonCommand<ICloseable>(this.SetCancel);
    }

    public ICommand OkCommand
    {
      get;
      private set;
    }

    public ICommand YesCommand
    {
      get;
      private set;
    }

    public ICommand NoCommand
    {
      get;
      private set;
    }

    public ICommand CancelCommand
    {
      get;
      private set;
    }

    public string Title => this.title;

    public string Message => this.message;

    public MessageBoxButton Buttons => this.buttons;

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

    public int ButtonCount
    {
      get
      {
        switch (this.Buttons)
        {
          case MessageBoxButton.OK:
            return 1;

          case MessageBoxButton.OKCancel:
          case MessageBoxButton.YesNo:
            return 2;

          case MessageBoxButton.YesNoCancel:
            return 3;

          default:
            return 1;
        }
      }
    }

    public bool OkAvailable
    {
      get
      {
        switch (this.Buttons)
        {
          case MessageBoxButton.OK:
          case MessageBoxButton.OKCancel:
            return true;

          default:
            return false;
        }
      }
    }

    public bool YesAvailable
    {
      get
      {
        switch (this.Buttons)
        {
          case MessageBoxButton.YesNo:
          case MessageBoxButton.YesNoCancel:
            return true;

          default:
            return false; ;
        }
      }
    }

    public bool NoAvailable
    {
      get
      {
        switch (this.Buttons)
        {
          case MessageBoxButton.YesNo:
          case MessageBoxButton.YesNoCancel:
            return true;

          default:
            return false; ;
        }
      }
    }

    public bool CancelAvailable
    {
      get
      {
        switch (this.Buttons)
        {
          case MessageBoxButton.YesNoCancel:
          case MessageBoxButton.OKCancel:
            return true;

          default:
            return false; ;
        }
      }
    }

    public void SetOk(ICloseable window)
    {
      this.Result = MessageBoxResult.OK;
      window.CloseObject();
    }

    public void SetYes(ICloseable window)
    {
      this.Result = MessageBoxResult.Yes;
      window.CloseObject();
    }

    public void SetNo(ICloseable window)
    {
      this.Result = MessageBoxResult.No;
      window.CloseObject();
    }

    public void SetCancel(ICloseable window)
    {
      this.Result = MessageBoxResult.Cancel;
      window.CloseObject();
    }
  }
}