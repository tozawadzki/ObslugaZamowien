using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObslugaZamowien
{
    /// <summary>
    /// Klasa order
    /// "baza danych"
    /// posiada właściwości zamówień
    /// </summary>
    public class Order
    {
        // Nie dłuższe niż 6 znaków
        [StringLength(6)]
        public string ClientID { get; set; }
        public long RequestID { get; set; }
        // Nie dłuższe niż 255 znaków
        [StringLength(255)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Konstruktor parametryczny inicjalizujący właściwości klasy podanymi parametrami
        /// </summary>
        /// <param name="clientid"></param>
        /// <param name="requestid"></param>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
    
        public Order(string clientid, long requestid, string name, int quantity, double price)
        {
            ClientID = clientid;
            RequestID = requestid;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// Konsturktor parametryczny inicjalizujący dwie z pięciu właściwości klasy
        /// Został stworzony dla metody AllOrders w klasie Raports
        /// Wysyłamy w niej obiekt typu Order posiadający zainicjalizowane tylko ClientID i RequestID
        /// </summary>
        /// <param name="clientid"></param>
        /// <param name="requestid"></param>
        public Order(string clientid, long requestid)
        {
            ClientID = clientid;
            RequestID = requestid;
        }
    }
}
