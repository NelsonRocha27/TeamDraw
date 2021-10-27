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
         ChangeBackground("Resources/champions2.jpg");

         if (true == Program.ReadJSON())
         {
            for (int i = 1; i <= Program.data.numberTeams; i++)
            {
               AddTeamSlot(i);
            }

            playersTextBox.Text = String.Join(Environment.NewLine, Program.data.players);
         }
         else
         {
            return;
         }
      }

      private void ChangeBackground(string resource)
      {
         ImageBrush b = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), resource)));
         appGrid.Background = b;
      }

      private void AddTeamSlot(int i)
      {
         ColumnDefinition columnMargin = new ColumnDefinition();
         ColumnDefinition columnText = new ColumnDefinition();

         columnMargin.Width = new GridLength(1, GridUnitType.Star);
         columnText.Width = new GridLength(0.1, GridUnitType.Star);

         appGrid.ColumnDefinitions.Add(columnMargin);
         appGrid.ColumnDefinitions.Add(columnText);

         Label label = new Label();

         label.Name = "labelTeam" + i;
         label.Content = "Team " + i;
         label.HorizontalAlignment = HorizontalAlignment.Center;
         label.VerticalAlignment = VerticalAlignment.Bottom;
         label.Margin = new Thickness(1);
         label.Foreground = Brushes.OrangeRed;
         label.FontSize = 32;
         Grid.SetColumn(label, appGrid.ColumnDefinitions.Count - 2);
         Grid.SetRow(label, 1);
         appGrid.Children.Add(label);

         TextBox txtB = new TextBox();

         txtB.Name = "team" + i + "TextBox";
         txtB.HorizontalAlignment = HorizontalAlignment.Stretch;
         txtB.VerticalAlignment = VerticalAlignment.Stretch;
         txtB.Margin = new Thickness(10);
         txtB.TextWrapping = TextWrapping.Wrap;
         txtB.Background = Brushes.Black;
         txtB.Foreground = Brushes.White;
         txtB.FontSize = 20;
         Grid.SetColumn(txtB, appGrid.ColumnDefinitions.Count - 2);
         Grid.SetRow(txtB, 2);
         appGrid.Children.Add(txtB);
      }
   }
}
