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
    /// <summary>
    /// Publiczna klasa JSONMaker
    /// Pozwala nam parsować przekazany plik z rozszerzeniem .json
    /// Używamy w niej funkcjonalności z rozszerzenie Newtonsoft
    /// </summary>
    public class JSONmaker  
    {
        /// <summary>
        /// Funkcja pobierająca plik json
        /// Używamy StreamReadera w celu zczytania tekstu z pliku
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable GetFile(string path)
        {
            StringBuilder builder = new StringBuilder();

            try
            {
                // Tworzymy obiekt pomocniczy klasy StreamReader
                // using zamyka StreamReadera
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    // Sczytuje i wyświetla linijki z tekstu aż do końca pliku
                    while ((line = sr.ReadLine()) != null)
                        builder.Append(line);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił niespodziewny błąd");
            }
            // Parsujemy dane pobrane podczas StreamReadowania
            JObject jObject = JObject.Parse(builder.ToString());
            // JSON na obiekt
            var objects = JsonConvert.DeserializeObject<ObjectToRequest>(builder.ToString());
            List<int> errors;
            // Konwertujemy, używając metody z klasy ObjectToRequest 
            var returnedValue = objects.Convert(out errors);
            MessageBox.Show("Plik został wczytany");
            return returnedValue;

        }
    }
}
