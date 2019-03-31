using ObslugaZamowien.Class;
using ObslugaZamowien.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObslugaZamowien
{
    public partial class FormMain : Form
    {
        // Lista zamówień służąca nam jako połączenie z "bazą danych"
        private List<Order> ordersContext = new List<Order>();
        // Objekt, na którym będziemy wywoływać metody klasy Raports zawierającą funkcjonalności zadane w poleceniu
        private Raports raportObj;
        public FormMain()
        {
            InitializeComponent();
            this.listBoxDrop.DragDrop += new
           System.Windows.Forms.DragEventHandler(this.listBoxDrop_DragDrop);
            this.listBoxDrop.DragEnter += new
                       System.Windows.Forms.DragEventHandler(this.listBoxDrop_DragEnter);

        }

        /// <summary>
        /// https://support.microsoft.com/en-us/help/307966/how-to-provide-file-drag-and-drop-functionality-in-a-visual-c-applicat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDrop_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// Funkcja drag and drop
        /// Zainspirowana tą napisaną na stronie https://support.microsoft.com/en-us/help/307966/how-to-provide-file-drag-and-drop-functionality-in-a-visual-c-applicat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDrop_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            JSONmaker loader = new JSONmaker();
            foreach (var file in s)
            {
                if (!file.EndsWith(".json"))
                {
                    MessageBox.Show("Plik posiada nieobsługiwane rozszerzenie");
                    break;
                }

                var loading = Task<IEnumerable<Order>>.Run(() =>
                    {
                        return (IEnumerable<Order>)loader.GetFile(file);
                    });

                foreach (var row in loading.Result)
                {
                    ordersContext.Add(row);
                    MessageBox.Show("Załadowano bazę!");
                }
            }
        }
        /// <summary>
        /// Przycisk wyświetlający ilość wszystkich zamówień
        /// Wszystkie funkcjonalności przycisków zaprezentowane poniżej są niezgodne z zasadą YAGNI
        /// Lepszym rozwiązaniem byłoby zrobienie jednego guzika ze switch/case
        /// Niestety nie zdążę tego już przerobić
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAmount_Click(object sender, EventArgs e)
        {
            if (ordersContext.Count > 0)
            {
                var result = Task<int>.Run(() =>
                {
                    // Wywołujemy odpowiednią metodę, analogicznie w reszcie przypadków
                    return raportObj.OrdersAmount();
                });

                MessageBox.Show("Ilość zamówień: ", result.Result.ToString());
            }
            else
                MessageBox.Show("Nie załadowano bazy danych");
        }
        /// <summary>
        /// Przycisk wyświetlający łączną kwotę zamówień
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSummedCost_Click(object sender, EventArgs e)
        {
            if (ordersContext.Count > 0)
            {
                var result = Task<int>.Run(() =>
                {
                    return raportObj.SummedCostOfOrders();
                });

                MessageBox.Show("Łączny koszt zamówień: ", result.Result.ToString());
            }
            else
                MessageBox.Show("Nie załadowano bazy danych");
        }
        /// <summary>
        /// Przycisk wyświetlający średnią kwotę zamówienia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAverage_Click(object sender, EventArgs e)
        {
            if (ordersContext.Count > 0)
            {
                var result = Task<int>.Run(() =>
                {
                    return raportObj.AverageCostOfOrder();
                });

                MessageBox.Show("Średni koszt zamówienia: ", result.Result.ToString());
            }
            else
                MessageBox.Show("Nie załadowano bazy danych");
        }
        /// <summary>
        /// Przycisk wyświetlający zamówienia w podanym przedziale cenowym
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInterval_Click(object sender, EventArgs e)
        {
            // Dolny i górny przedział
            double uLimit, dLimit;
            // Jeśli textboxy są uzupełnione
            if (textBoxOd.Text != "" && textBoxDo.Text != "")
            {
                // Parsujemy string na double
                uLimit = double.Parse(textBoxOd.Text);
                dLimit = double.Parse(textBoxDo.Text);
                if (ordersContext.Count > 0)
                {
                    var result = Task<int>.Run(() =>
                    {
                        return raportObj.IntervalCost(uLimit, dLimit);
                    });
                    MessageBox.Show("Średni koszt zamówienia: ", result.Result.ToString());
                }
                else
                    MessageBox.Show("Nie załadowano bazy danych");
            }
            else
                MessageBox.Show("Wpisz granice przedziałów!");
            
        }
        

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
        
    

