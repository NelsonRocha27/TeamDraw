using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;

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
         catch(Exception ex)
         {
            MessageBox.Show(ex.ToString());
            return false;
         }

         return true;
      }

      static public void ParseJSON(JObject jsonObj)
      {
         data = JsonConvert.DeserializeObject<Data>(jsonObj.Root.ToString());
      }
   }
}
