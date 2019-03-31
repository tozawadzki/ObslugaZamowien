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
            this.buttonAmount = new System.Windows.Forms.Button();
            this.buttonSummedCost = new System.Windows.Forms.Button();
            this.buttonAverage = new System.Windows.Forms.Button();
            this.buttonInterval = new System.Windows.Forms.Button();
            this.labelInterval = new System.Windows.Forms.Label();
            this.textBoxOd = new System.Windows.Forms.TextBox();
            this.textBoxDo = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxDrop
            // 
            this.listBoxDrop.AllowDrop = true;
            this.listBoxDrop.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxDrop.FormattingEnabled = true;
            this.listBoxDrop.ItemHeight = 16;
            this.listBoxDrop.Location = new System.Drawing.Point(12, 98);
            this.listBoxDrop.Name = "listBoxDrop";
            this.listBoxDrop.Size = new System.Drawing.Size(279, 212);
            this.listBoxDrop.TabIndex = 0;
            // 
            // buttonAmount
            // 
            this.buttonAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAmount.Location = new System.Drawing.Point(12, 12);
            this.buttonAmount.Name = "buttonAmount";
            this.buttonAmount.Size = new System.Drawing.Size(105, 68);
            this.buttonAmount.TabIndex = 1;
            this.buttonAmount.Text = "Ilość raportów";
            this.buttonAmount.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.buttonAmount.UseVisualStyleBackColor = true;
            this.buttonAmount.Click += new System.EventHandler(this.buttonAmount_Click);
            // 
            // buttonSummedCost
            // 
            this.buttonSummedCost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSummedCost.Location = new System.Drawing.Point(123, 12);
            this.buttonSummedCost.Name = "buttonSummedCost";
            this.buttonSummedCost.Size = new System.Drawing.Size(105, 68);
            this.buttonSummedCost.TabIndex = 2;
            this.buttonSummedCost.Text = "Łączny koszt zamówień";
            this.buttonSummedCost.UseVisualStyleBackColor = true;
            this.buttonSummedCost.Click += new System.EventHandler(this.buttonSummedCost_Click);
            // 
            // buttonAverage
            // 
            this.buttonAverage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAverage.Location = new System.Drawing.Point(234, 12);
            this.buttonAverage.Name = "buttonAverage";
            this.buttonAverage.Size = new System.Drawing.Size(105, 68);
            this.buttonAverage.TabIndex = 3;
            this.buttonAverage.Text = "Średni koszt zamowienia";
            this.buttonAverage.UseVisualStyleBackColor = true;
            this.buttonAverage.Click += new System.EventHandler(this.buttonAverage_Click);
            // 
            // buttonInterval
            // 
            this.buttonInterval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInterval.Location = new System.Drawing.Point(345, 12);
            this.buttonInterval.Name = "buttonInterval";
            this.buttonInterval.Size = new System.Drawing.Size(105, 68);
            this.buttonInterval.TabIndex = 4;
            this.buttonInterval.Text = "Raporty w przedziale cenowym";
            this.buttonInterval.UseVisualStyleBackColor = true;
            this.buttonInterval.Click += new System.EventHandler(this.buttonInterval_Click);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInterval.Location = new System.Drawing.Point(351, 88);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(94, 20);
            this.labelInterval.TabIndex = 6;
            this.labelInterval.Text = "Przedział:";
            // 
            // textBoxOd
            // 
            this.textBoxOd.Location = new System.Drawing.Point(345, 111);
            this.textBoxOd.Name = "textBoxOd";
            this.textBoxOd.Size = new System.Drawing.Size(47, 22);
            this.textBoxOd.TabIndex = 7;
            // 
            // textBoxDo
            // 
            this.textBoxDo.Location = new System.Drawing.Point(398, 111);
            this.textBoxDo.Name = "textBoxDo";
            this.textBoxDo.Size = new System.Drawing.Size(47, 22);
            this.textBoxDo.TabIndex = 8;
            // 
            // buttonExit
            // 
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(347, 251);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(105, 59);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Wyjście";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 327);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.textBoxDo);
            this.Controls.Add(this.textBoxOd);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.buttonInterval);
            this.Controls.Add(this.buttonAverage);
            this.Controls.Add(this.buttonSummedCost);
            this.Controls.Add(this.buttonAmount);
            this.Controls.Add(this.listBoxDrop);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDrop;
        private System.Windows.Forms.Button buttonAmount;
        private System.Windows.Forms.Button buttonSummedCost;
        private System.Windows.Forms.Button buttonAverage;
        private System.Windows.Forms.Button buttonInterval;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.TextBox textBoxOd;
        private System.Windows.Forms.TextBox textBoxDo;
        private System.Windows.Forms.Button buttonExit;
    }
}

