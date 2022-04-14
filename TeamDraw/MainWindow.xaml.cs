using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
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
        Style style;
        public static WMPLib.WindowsMediaPlayer wplayer;
        public static MainWindow appWindow;
        public bool pause = false;

        public MainWindow()
        {
            InitializeComponent();
            appWindow = this;

            if (true == Program.ReadJSON())
            {

            }
            else
            {
                return;
            }

            style = new Style(Program.data.theme, Program.data.picsDir);

            for (int i = 1; i <= Program.data.numberTeams; i++)
            {
                AddTeamSlot(i, Program.data.teams[i - 1]);
            }

            playersTextBox.Text = String.Join(Environment.NewLine, Program.data.players);

            ChangeBackground(style.background);
            PlayBackgroundMusic(style.music);

            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#990d3e69");
            playersTextBox.Background = brush;
            brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            playersTextBox.Foreground = brush;

            buttonDraw.Background = style.drawButtonBackground;
            buttonDraw.Foreground = style.drawButtonForeground;
            buttonDraw.FontSize = style.drawButtonFontSize;

            buttonPlayer.Background = style.drawButtonBackground;
            buttonPlayer.Foreground = style.drawButtonForeground;
            buttonPlayer.FontSize = style.drawButtonFontSize;
        }

        private void ChangeBackground(string resource)
        {
            ImageBrush b = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), resource)));
            appGrid.Background = b;
        }

        private void PlayBackgroundMusic(string resource)
        {
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.settings.setMode("loop", true);
            wplayer.settings.volume = 4;
            wplayer.URL = resource;
            wplayer.controls.play();
        }

        public void StopMusic()
        {
            wplayer.controls.stop();
        }

        public void ShowPhoto(string player)
        {
            buttonPlayer.Content = player;

            if (Theme.CHAMPIONS == Program.data.theme)
            {
                try
                {
                    Console.WriteLine(new Uri(BaseUriHelper.GetBaseUri(this), player + ".png"));

                    badgeChampions.Fill = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), Program.data.picsDir + player + ".png")));
                }
                catch
                {
                    badgeChampions.Fill = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), Program.data.picsDir + "default.png")));
                    Console.WriteLine("Photo error!");
                }

                playersTextBox.Visibility = Visibility.Hidden;
                badgeChampions.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    Console.WriteLine(new Uri(BaseUriHelper.GetBaseUri(this), player + ".png"));

                    badge.Fill = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), Program.data.picsDir + player + ".png")));
                }
                catch
                {
                    badge.Fill = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), Program.data.picsDir + "default.png")));
                    Console.WriteLine("Photo error!");
                }

                playersTextBox.Visibility = Visibility.Hidden;
                badge.Visibility = Visibility.Visible;
                buttonPlayer.Visibility = Visibility.Visible;
            }

        }

        public void HidePhoto()
        {
            if (Theme.CHAMPIONS == Program.data.theme)
            {
                playersTextBox.Visibility = Visibility.Visible;
                badgeChampions.Visibility = Visibility.Hidden;
            }
            else
            {
                playersTextBox.Visibility = Visibility.Visible;
                badge.Visibility = Visibility.Hidden;
                buttonPlayer.Visibility = Visibility.Hidden;
            }
        }

        private void AddTeamSlot(int i, string teamName)
        {
            ColumnDefinition columnMargin = new ColumnDefinition();
            ColumnDefinition columnText = new ColumnDefinition();

            columnMargin.Width = new GridLength(1, GridUnitType.Star);
            columnText.Width = new GridLength(0.1, GridUnitType.Star);

            appGrid.ColumnDefinitions.Add(columnMargin);
            appGrid.ColumnDefinitions.Add(columnText);

            Label label = new Label();

            label.Name = "labelTeam" + i;
            label.Content = teamName;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Bottom;
            label.Margin = new Thickness(1);
            label.Foreground = style.labelBackground;
            label.FontSize = style.labelFontSize;
            label.FontFamily = new FontFamily("Formular");
            label.FontWeight = FontWeights.DemiBold;
            Grid.SetColumn(label, appGrid.ColumnDefinitions.Count - 2);
            Grid.SetRow(label, 1);
            appGrid.Children.Add(label);

            TextBox txtB = new TextBox();

            txtB.Name = "team" + i + "TextBox";
            txtB.HorizontalAlignment = HorizontalAlignment.Stretch;
            txtB.VerticalAlignment = VerticalAlignment.Stretch;
            txtB.Margin = new Thickness(10);
            txtB.TextWrapping = TextWrapping.Wrap;
            txtB.Background = style.textBoxBackground;
            txtB.Foreground = style.textBoxForeground;
            txtB.FontFamily = new FontFamily("Formular");
            txtB.FontWeight = FontWeights.Bold;
            txtB.FontSize = style.textBoxFontSize;
            txtB.BorderBrush = Brushes.LightYellow;
            //txtB.BorderThickness = new Thickness(5);
            Grid.SetColumn(txtB, appGrid.ColumnDefinitions.Count - 2);
            Grid.SetRow(txtB, 2);
            this.RegisterName(txtB.Name, txtB);
            appGrid.Children.Add(txtB);
        }

        public void AddPlayerToTeam(string player, string textBoxName)
        {
            var textBox = (TextBox)this.FindName(textBoxName);
            textBox.Text += player + '\n';
        }

        private void buttonDraw_Click(object sender, RoutedEventArgs e)
        {
            buttonDraw.Visibility = Visibility.Hidden;
            new Thread(Program.Draw).Start();
        }

        private void pressed(object sender, KeyEventArgs e)
        {


        }

        private void PAUSE(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (pause)
                    pause = false;
                else if (!pause)
                    pause = true;
            }
        }
    }
}
