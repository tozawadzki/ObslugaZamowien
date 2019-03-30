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
        List<Order> orders;
        public FormMain()
        {
            InitializeComponent();
            this.listBoxDrop.DragDrop += new
           System.Windows.Forms.DragEventHandler(this.listBoxDrop_DragDrop);
            this.listBoxDrop.DragEnter += new
                       System.Windows.Forms.DragEventHandler(this.listBoxDrop_DragEnter);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

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
                    orders.Add(row);
                    MessageBox.Show("Załadowano bazę!");
                }
            }
        }
    }
}
        
    

