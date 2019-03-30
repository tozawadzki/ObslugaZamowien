using ObslugaZamowien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/// <summary>
/// Użyto convertera ze strony https://xmltocsharp.azurewebsites.net/
/// </summary>
namespace Xml2CSharp
{
    [XmlRoot(ElementName = "request")]
    public class Request
    {
        [XmlElement(ElementName = "clientId")]
        public string ClientId { get; set; }
        [XmlElement(ElementName = "requestId")]
        public string RequestId { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "quantity")]
        public string Quantity { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }


        public Order toDataBaseRow()
        {

            if (ClientId == null || RequestId == null || Name == null || Quantity == null || Price == null)
                return null;
            if (ClientId.Equals("") || Name.Equals("")) return null;
            if (ClientId.Length > 6 || ClientId.Contains(" ")) return null;
            if (Name.Length > 255) return null;
            // Jeśli którekolwiek TryParse zwróci false !false=true
            if (!double.TryParse(Price, out double price) ||
                !long.TryParse(RequestId, out long requestId) ||
                !int.TryParse(Quantity, out int quantity)) return null;

            //Zwracamy objekt wywołując konstruktor parametryczny
            return new Order(ClientId, requestId, Name, quantity, price);
        }
    }

    [XmlRoot(ElementName = "requests")]
    public class Requests
    {
        [XmlElement(ElementName = "request")]
        public List<Request> Request { get; set; }
    }

}

