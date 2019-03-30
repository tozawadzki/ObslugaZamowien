namespace ObslugaZamowien
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxDrop = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxDrop
            // 
            this.listBoxDrop.AllowDrop = true;
            this.listBoxDrop.FormattingEnabled = true;
            this.listBoxDrop.ItemHeight = 16;
            this.listBoxDrop.Location = new System.Drawing.Point(430, 220);
            this.listBoxDrop.Name = "listBoxDrop";
            this.listBoxDrop.Size = new System.Drawing.Size(120, 84);
            this.listBoxDrop.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 597);
            this.Controls.Add(this.listBoxDrop);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDrop;
    }
}

