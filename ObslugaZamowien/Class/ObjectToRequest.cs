using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xml2CSharp;

namespace ObslugaZamowien.Class
{
    public class ObjectToRequest
    {
        [XmlRoot(ElementName = "requests")]
        public class RootObjectForRequest
        {
            [XmlElement(ElementName = "request")]
            public List<Request> allRequests { get; set; }

            public IEnumerable<Order> Convert(out List<int> errorList)
            {
                errorList = new List<int>();
                List<Order> rows = new List<Order>();
                Order currentOrder;
                for (int i = 0; i < allRequests.Count; i++)
                {
                    currentOrder = allRequests[i].toDataBaseRow();
                    if (currentOrder != null) rows.Add(currentOrder);
                    else errorList.Add(i + 1);
                }

                return rows;
            }
        }
    }
}
