using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xml2CSharp;

namespace ObslugaZamowien.Class
{
    /// <summary>
    /// Publiczna klasa ObjectToRequest
    /// </summary>
    [XmlRoot(ElementName = "requests")]
    public class ObjectToRequest
    {
            [XmlElement(ElementName = "request")]
            public List<Request> allRequests { get; set; }
        /// <summary>
        /// Metoda Convert
        /// Zamienia dane pobrane z pliku i wczytane do bazy na "gotowe" wiersze z odpowiednimi polami
        /// Służy do stworzenia obiektu (wywołania konstruktora parametrycznego, ma to miejsce w klasie Requests przy wywołaniu metody toOrder()
        /// Zwraca wiersze z dodanymi zamówieniami
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
            public IEnumerable<Order> Convert(out List<int> errors)
            {
                errors = new List<int>();
                List<Order> rows = new List<Order>();
            // Zmienna pomocnicza, która będzie w pętli przechowywać aktualnie badane zamówienie
                Order currentOrder;
            // W tym miejscu program przestaje działać
            // Jest to spowodowane tym, że lista allRequest jest zainicjalizowana nullem (?)
            // Jest nullem (?)
                for (int i = 0; i < allRequests.Count; i++)
                {
                // Wywołanie metody z klasy Request, stworzenie obiektu za pomocą konstruktora parametrycznego
                    currentOrder = allRequests[i].toOrder();
                    if (currentOrder != null)
                    // Dodanie zamówienia do wiersza
                    rows.Add(currentOrder);
                    else
                    // Dodanie błędu (Obsługa ilości błędów nie została jeszcze zaimplementowana)
                    errors.Add(i + 1);
                }
                return rows;
            }
        }

        
    }

