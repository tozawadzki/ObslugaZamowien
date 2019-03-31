using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObslugaZamowien.Class;
using ObslugaZamowien;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xml2CSharp;

namespace ObslugaZamowien.Data
{
    public class JSONmaker : ILoader
    {

        public IEnumerable GetFile(string path)
        {
            StringBuilder builder = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                        builder.Append(line);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił niespodziewny błąd");
            }

            JObject jObject = JObject.Parse(builder.ToString());
            var objects = JsonConvert.DeserializeObject<ObjectToRequest>(builder.ToString());
            List<int> errors;
            var returnedValue = objects.Convert(out errors);
            MessageBox.Show("Plik został wczytany");
            return returnedValue;

        }
    }
}
