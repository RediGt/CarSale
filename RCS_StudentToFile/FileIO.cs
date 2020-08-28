using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_CarListJson
{
    class FileIO
    {
        public static void SaveToFile(List<Car> stud)
        {
            string jsonString;

            jsonString = JsonConvert.SerializeObject(stud, Formatting.Indented);
            File.WriteAllText(GetFile(), jsonString);
            MessageBox.Show("Saved successfully");
        }

        public static List<Car> LoadFromFile()
        {
            try
            {
                StreamReader reader = new StreamReader(GetFile());
                String line = reader.ReadLine();
                String json = "";

                while (line != null)
                {
                    json += line;
                    line = reader.ReadLine();
                }
                reader.Close();

                return JsonConvert.DeserializeObject<List<Car>>(json);
            }
            catch
            {
                List<Car> a = new List<Car>();
                return null;
            }
        }

        public static string GetFile()
        {
            string filename = Directory.GetCurrentDirectory();
            filename += @"\CarList.json";

            return filename;
        }
    }
}
