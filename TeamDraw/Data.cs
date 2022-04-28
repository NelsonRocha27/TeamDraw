using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TeamDraw
{
   public enum Theme
   {
      CHAMPIONS,
      APTIV,
      STARWARS,
      DEFAULT
   }

   class Data
   {
      public int numberTeams;
      public Theme theme;
      public List<string> players;
      public List<string> playersToDraw;
      public List<string> teams;
      public string picsDir;

      public Data()
      {
         players = new List<string>();
         playersToDraw = new List<string>();
         teams = new List<string>();
         theme = Theme.DEFAULT;
         numberTeams = 0;
         picsDir = null;
      }
   }

   public class Style
   {
      public Brush textBoxBackground;
      public Brush textBoxForeground;
      public Brush labelBackground;
      public Brush textBoxPlayersBackground;
      public Brush textBoxPlayersForeground;
      public Brush drawButtonBackground;
      public Brush drawButtonForeground;
      public FontFamily fontFamily;
      public int textBoxFontSize;
      public int labelFontSize;
      public int drawButtonFontSize;
      public string background;
      public string music;

      public Style()
      {
         this.textBoxBackground = Brushes.Black;
         this.textBoxForeground = Brushes.White;
         this.labelBackground = Brushes.Black;
         this.textBoxPlayersBackground = Brushes.Black;
         this.textBoxPlayersForeground = Brushes.White;
         this.drawButtonBackground = Brushes.Black;
         this.drawButtonForeground = Brushes.White;
         this.fontFamily = new FontFamily("Formular");
         this.textBoxFontSize = 12;
         this.labelFontSize = 12;
         this.drawButtonFontSize = 12;
         this.background = "";
         this.music = "";
      }

      public Style(Theme theme, string dir)
      {
         if (Theme.CHAMPIONS == theme)
         {
            this.fontFamily = new FontFamily("Formular");
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#A5091442");
            this.textBoxBackground = brush;
            this.textBoxForeground = Brushes.White;
            brush = (Brush)converter.ConvertFromString("#FF85BAEC");
            this.labelBackground = brush;
            brush = (Brush)converter.ConvertFromString("#990d3e69");
            this.textBoxPlayersBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            this.textBoxPlayersForeground = brush;
            brush = (Brush)converter.ConvertFromString("#FF2E87DA");
            this.drawButtonBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FF091442");
            this.drawButtonForeground = brush;
            this.drawButtonFontSize = 20;
            this.textBoxFontSize = 20;
            this.labelFontSize = 32;
            this.background = "Resources/champions2.jpg";
            this.music = dir + "champions.wav";
         }
         else if (Theme.APTIV == theme)
         {
            this.fontFamily = new FontFamily("Formular");
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#99db3525");
            this.textBoxBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            this.textBoxForeground = brush;
            brush = (Brush)converter.ConvertFromString("#BB0d3e69");
            this.drawButtonBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            this.drawButtonForeground = brush;
            this.drawButtonFontSize = 20;
            brush = (Brush)converter.ConvertFromString("#FFdb3525");
            this.labelBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FFFFFFFF");
            this.textBoxPlayersForeground = brush;
            this.textBoxFontSize = 20;
            this.labelFontSize = 32;
            this.background = "Resources/playground.png";
            this.music = dir + "squidgame.mp3";
         }
         else if (Theme.STARWARS == theme)
         {
            PrivateFontCollection pfc = new PrivateFontCollection();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            pfc.AddFontFile(path + "\\Resources\\Fonts\\Starjedi.ttf");
            this.fontFamily = new FontFamily(pfc.Families[0].Name);
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#99FFE81F");
            this.textBoxBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FF2F2F2F");
            this.textBoxForeground = brush;
            brush = (Brush)converter.ConvertFromString("#99FFE81F");
            this.textBoxPlayersBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FF2F2F2F");
            this.textBoxPlayersForeground = brush;
            brush = (Brush)converter.ConvertFromString("#BBFFE81F");
            this.drawButtonBackground = brush;
            brush = (Brush)converter.ConvertFromString("#FF2F2F2F");
            this.drawButtonForeground = brush;
            this.drawButtonFontSize = 20;
            brush = (Brush)converter.ConvertFromString("#FFFFE81F");
            this.labelBackground = brush;
            this.textBoxFontSize = 19;
            this.labelFontSize = 32;
            this.background = "Resources/Fundo1.png";
            this.music = dir + "imperialmarch.wav";
         }
         else
         {
            this.textBoxBackground = Brushes.Black;
            this.textBoxForeground = Brushes.White;
            this.labelBackground = Brushes.Black;
            this.textBoxPlayersBackground = Brushes.Black;
            this.textBoxPlayersForeground = Brushes.White;
            this.drawButtonBackground = Brushes.Black;
            this.drawButtonForeground = Brushes.White;
            this.textBoxFontSize = 12;
            this.labelFontSize = 12;
            this.drawButtonFontSize = 12;
            this.background = "";
            this.music = "";
         }
      }
   }
}
