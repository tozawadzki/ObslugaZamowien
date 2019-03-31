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
    /// <summary>
    /// Klasa wygenerowana za pomocą strony http://json2csharp.com/
    /// </summary>
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


        public Order toOrder()
        {
            // Jeśli którekolwiek TryParse zwróci false !false=true
            if (!double.TryParse(Price, out double price) ||
                !long.TryParse(RequestId, out long requestId) ||
                !int.TryParse(Quantity, out int quantity)) return null;
            // Zapobieganie niechcianym formatom danym - wytyczne przedstawione w poleceniu
            if (ClientId == null || RequestId == null || Name == null || Quantity == null || Price == null)
                return null;
            if (Name.Length > 255)
                return null;
            if (ClientId.Equals("") || Name.Equals(""))
                return null;
            if (ClientId.Length > 6 || ClientId.Contains(" "))
                return null;

            //Zwracamy objekt wywołując konstruktor parametryczny
            return new Order(ClientId, requestId, Name, quantity, price);
        }
    }
}

