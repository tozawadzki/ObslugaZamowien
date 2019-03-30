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
        public FormMain()
        {
            InitializeComponent();
            this.listBoxDrop.DragDrop += new
           System.Windows.Forms.DragEventHandler(this.listBoxDrop_DragDrop);
            this.listBoxDrop.DragEnter += new
                       System.Windows.Forms.DragEventHandler(this.listBoxDrop_DragEnter);

        }

        private void listBoxDrop_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBoxDrop_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBoxDrop.Items.Add(s[i]);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }
    }
}
