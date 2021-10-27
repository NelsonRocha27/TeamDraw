using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDraw
{
   enum Theme
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

   class Style
   {
   }
}
