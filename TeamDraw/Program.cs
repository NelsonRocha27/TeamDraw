using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;
using System.Threading;

namespace TeamDraw
{
   static class Program
   {
      static public Data data = new Data();

      static public bool ReadJSON()
      {
         // read JSON directly from a file
         try
         {
            using (StreamReader file = File.OpenText(@"C:\Users\gjq64r\Documents\MOL\TeamDraw\TeamDraw\config.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
               JObject jsonObj = (JObject)JToken.ReadFrom(reader);
               ParseJSON(jsonObj);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
            return false;
         }

         return true;
      }

      static public void ParseJSON(JObject jsonObj)
      {
         data = JsonConvert.DeserializeObject<Data>(jsonObj.Root.ToString());
         data.numberTeams = data.teams.Count;
         data.playersToDraw = data.players;
      }

      static public void Draw()
      {
         int j = 0;

         while (data.playersToDraw.Count > 0)
         {
            Random rnd = new Random();
            int i = rnd.Next(0, data.playersToDraw.Count);

            string playerDrafted = data.playersToDraw[i];

            data.playersToDraw.RemoveAt(i);
            MainWindow.appWindow.Dispatcher.Invoke(() =>
            {
               MainWindow.appWindow.playersTextBox.Text = String.Join(Environment.NewLine, data.playersToDraw);
            });

            //txtB.Name = "team" + i + "TextBox";
            MainWindow.appWindow.Dispatcher.Invoke(() =>
            {
               MainWindow.appWindow.ShowPhoto(playerDrafted);
               MainWindow.appWindow.AddPlayerToTeam(playerDrafted, ("team" + (j + 1) + "TextBox"));
            });

            Thread.Sleep(5000);
            MainWindow.appWindow.Dispatcher.Invoke(() =>
            {
               MainWindow.appWindow.HidePhoto();
            });

            j = (j + 1) % data.teams.Count;
            Thread.Sleep(2500);
         }

         MainWindow.appWindow.Dispatcher.Invoke(() =>
         {
            MainWindow.appWindow.StopMusic();
         });
      }
   }
}
