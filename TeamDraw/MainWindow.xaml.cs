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

namespace TeamDraw
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
         ChangeBackground("Resources/aptiv.jpg");
      }

      private void ChangeBackground(string resource)
      {
         ImageBrush b = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), resource)));
         appGrid.Background = b;
      }
   }
}
