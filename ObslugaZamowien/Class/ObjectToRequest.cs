using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xml2CSharp;

namespace ObslugaZamowien.Class
{
    [XmlRoot(ElementName = "requests")]
    public class ObjectToRequest
    {
        
            [XmlElement(ElementName = "request")]
            public List<Request> allRequests { get; set; }

            public IEnumerable<Order> Convert(out List<int> errors)
            {
                errors = new List<int>();
                List<Order> rows = new List<Order>();
                Order currentOrder;
                for (int i = 0; i < allRequests.Count; i++)
                {
                    currentOrder = allRequests[i].toDataBaseRow();
                    if (currentOrder != null) rows.Add(currentOrder);
                    else errors.Add(i + 1);
                }
              
                return rows;
            }
        }

        
    }

