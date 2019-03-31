using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObslugaZamowien.Class
{
    public class Raports
    {
        public List<Order> Db { get; set; }

        public Raports(List<Order> db)
        {
            Db = db;
        }

        public IEnumerable AllOrders()
        {
            var sortedList = Db.OrderBy(x => x.ClientID).ThenBy(y => y.RequestID).ToList();
            List<Order> orders = new List<Order>();
            Order goneOrder = new Order(sortedList[0].ClientID, sortedList[0].RequestID);
            long endRID = sortedList[0].RequestID;
            string endCID = sortedList[0].ClientID;

            foreach (var row in sortedList)
            {
                if (row.RequestID != endRID || row.ClientID != endCID)
                {
                    orders.Add(goneOrder);
                    goneOrder = new Order(row.ClientID, row.RequestID);
                    endRID = row.RequestID;
                    endCID = row.ClientID;
                }
                goneOrder.Price += row.Price * row.Quantity;
            }
            orders.Add(goneOrder);
            return orders;
        }

        public double OrdersAmount()
        {
            var value = Db.GroupBy(x => new { x.ClientID, x.RequestID }).Count();
            return value;
        }

        public double SummedCostOfOrders()
        {
            var value = Db.Sum(x => x.Price * x.Quantity);
            return value;
        }

        public double AverageCostOfOrder()
        {
            var value = Db.Sum(x => x.Price * x.Quantity);
            var denominator= Db.GroupBy(x => new { x.ClientID, x.RequestID }).Count();
            double result = value / denominator;
            return result;
        }

        public IEnumerable IntervalCost(double ulimit, double dlimit)
        {
            List<Order> orders = new List<Order>();
            var listOfOrders = ((IEnumerable<Order>) AllOrders() ).ToList();
            List<Order> intervalOrders = new List<Order>();
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
