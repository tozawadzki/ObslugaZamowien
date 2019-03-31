using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObslugaZamowien.Class
{
    /// <summary>
    /// Klasa publiczna raports
    /// Posiada metody, które mają za zadanie tworzyć odpowiednie raporty
    /// Posiada funkcjonalności podane w zadaniu
    /// Ilość zamówień
    /// Łączna kwota zamówień
    /// Lista wszystkich zamówień
    /// Średnia wartość zamówienia
    /// Zamówienia w podanym przedziale cenowym
    /// </summary>
    public class Raports
    {
        public List<Order> Db { get; set; }

        public Raports(List<Order> db)
        {
            Db = db;
        }
        /// <summary>
        /// Metoda publiczna typu IEnumerable
        /// zwraca listę wszystkich zamówień
        /// </summary>
        /// <returns></returns>
        public IEnumerable AllOrders()
        {
            // Użycie LINQ
            // Odbywa się sortowanie listy
            // Najpierw wg.  ClientID, nastepnie RequestID
            var sortedList = Db.OrderBy(x => x.ClientID).ThenBy(y => y.RequestID).ToList();
            List<Order> orders = new List<Order>();
            Order goneOrder = new Order(sortedList[0].ClientID, sortedList[0].RequestID);
            // Ostatnie RequestID
            long endRID = sortedList[0].RequestID;
            // Ostatnie ClientID
            string endCID = sortedList[0].ClientID;

            foreach (var row in sortedList)
            {
                // Dopóki RID i CID z danego wiersza to nie ten końcowy
                if (row.RequestID != endRID || row.ClientID != endCID)
                {
                    // Dodajemy do listy dane zamówienie
                    orders.Add(goneOrder);
                    // Wywołujemy konstruktor parametryczny
                    goneOrder = new Order(row.ClientID, row.RequestID);
                    // A ostatnie RID i CID to te z wiersza
                    endRID = row.RequestID;
                    endCID = row.ClientID;
                }
                // Łączna kwota zamówienia
                goneOrder.Price += row.Price * row.Quantity;
            }
            orders.Add(goneOrder);
            return orders;
        }
        /// <summary>
        /// Metoda publiczna typu double
        /// Zwraca ilość wszystkich zamówień
        /// </summary>
        /// <returns></returns>
        public double OrdersAmount()
        {
            var value = Db.GroupBy(x => new { x.ClientID, x.RequestID }).Count();
            return value;
        }
        /// <summary>
        /// Metoda publiczna typu double
        /// Zwraca łączną kwotę wszystkich zamówień
        /// </summary>
        /// <returns></returns>
        public double SummedCostOfOrders()
        {
            var value = Db.Sum(x => x.Price * x.Quantity);
            return value;
        }
        /// <summary>
        /// Metoda publiczna typu double
        /// Zwraca średni koszt zamówienia
        /// </summary>
        /// <returns></returns>
        public double AverageCostOfOrder()
        {
            var value = Db.Sum(x => x.Price * x.Quantity);
            var denominator= Db.GroupBy(x => new { x.ClientID, x.RequestID }).Count();
            double result = value / denominator;
            return result;
        }
        /// <summary>
        /// Metoda publiczna typu IEnumerable
        /// Zwraca listę zamówień w danym przedziale cenowym
        /// Jako parametry przyjmuje dolny i górny limit cenowy
        /// </summary>
        /// <returns></returns>
        public IEnumerable IntervalCost(double ulimit, double dlimit)
        {
            List<Order> orders = new List<Order>();
            // Wywowałanie metody AllOrders, która zwraca liste wszystkich zamówień
            var listOfOrders = ((IEnumerable<Order>) AllOrders() ).ToList();
            List<Order> intervalOrders = new List<Order>();
            // Następnie odbywa się wybranie tych zamówień, które mieszczą się w podanym przedziale cenowym
            foreach(var order in orders)
            {
                if (order.Price > dlimit && order.Price < ulimit)
                {
                    intervalOrders.Add(order);
                }
            }
            return orders;
        }
    }
}
