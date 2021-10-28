using System;
using System.Collections.Generic;
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
      DEFAULT
   }

   class Data
   {
      public int numberTeams;
      public Theme theme;
      public List<string> players;
      public List<string> teams;

      public Data()
      {
         players = new List<string>();
         teams = new List<string>();
         theme = Theme.DEFAULT;
         numberTeams = 0;
      }
   }

   public class Style
   {
      public Brush textBoxBackground;
      public Brush textBoxForeground;
      public Brush labelBackground;
      public int textBoxFontSize;
      public int labelFontSize;
      public string background;
      public string music;

      public Style()
      {
         this.textBoxBackground = Brushes.Black;
         this.textBoxForeground = Brushes.White;
         this.labelBackground = Brushes.Black;
         this.textBoxFontSize = 12;
         this.labelFontSize = 12;
         this.background = "";
         this.music = "";
      }

      public Style(Theme theme)
      {
         if (Theme.CHAMPIONS == theme)
         {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#A5091442");
            this.textBoxBackground = brush;
            this.textBoxForeground = Brushes.White;
            brush = (Brush)converter.ConvertFromString("#FF85BAEC");
            this.labelBackground = brush;
            this.textBoxFontSize = 20;
            this.labelFontSize = 32;
            this.background = "Resources/champions2.jpg";
            this.music = "";

            
         }
         else if (Theme.APTIV == theme)
         {
            this.textBoxBackground = Brushes.Black;
            this.textBoxForeground = Brushes.White;
            this.labelBackground = Brushes.OrangeRed;
            this.textBoxFontSize = 20;
            this.labelFontSize = 32;
            this.background = "Resources/aptiv.jpg";
            this.music = "";
         }
         else
         {
            this.textBoxBackground = Brushes.Black;
            this.textBoxForeground = Brushes.White;
            this.labelBackground = Brushes.Black;
            this.textBoxFontSize = 12;
            this.labelFontSize = 12;
            this.background = "";
            this.music = "";
         }
      }
   }
}
