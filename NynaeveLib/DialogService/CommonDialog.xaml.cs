using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NynaeveLib.DialogService
{
  using Interfaces;

  /// <summary>
  /// Interaction logic for CommonDialog.xaml
  /// </summary>
  public partial class CommonDialog : Window, ICloseable
  {
    public CommonDialog()
    {
      InitializeComponent();
    }

    public void CloseObject()
    {
      this.Close();
    }
  }
}
