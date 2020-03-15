namespace EntradaParking
{
    partial class Entrada
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbselect = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(68, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 2;
            // 
            // cmbselect
            // 
            this.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbselect.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbselect.FormattingEnabled = true;
            this.cmbselect.Location = new System.Drawing.Point(267, 186);
            this.cmbselect.Name = "cmbselect";
            this.cmbselect.Size = new System.Drawing.Size(389, 35);
            this.cmbselect.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EntradaParking.Properties.Resources.dashboard_14_512__1_;
            this.pictureBox1.Location = new System.Drawing.Point(679, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 455);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.RoyalBlue;
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Image = global::EntradaParking.Properties.Resources.next;
            this.next.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.next.Location = new System.Drawing.Point(324, 349);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(239, 60);
            this.next.TabIndex = 1;
            this.next.Text = "Siguiente";
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(524, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione el Tipo de Estacionamiento";
            // 
            // Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbselect);
            this.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "Entrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbselect;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
    }
}

