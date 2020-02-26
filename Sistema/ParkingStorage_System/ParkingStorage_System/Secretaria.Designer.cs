namespace ParkingStorage_System
{
    partial class Secretaria
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
            this.menu = new System.Windows.Forms.Panel();
            this.closesesion = new System.Windows.Forms.Button();
            this.carnet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.franja1 = new System.Windows.Forms.Panel();
            this.close = new System.Windows.Forms.Panel();
            this.minize = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            this.franja1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.MidnightBlue;
            this.menu.Controls.Add(this.closesesion);
            this.menu.Controls.Add(this.carnet);
            this.menu.Controls.Add(this.label3);
            this.menu.Controls.Add(this.label2);
            this.menu.Location = new System.Drawing.Point(15, 47);
            this.menu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(305, 557);
            this.menu.TabIndex = 2;
            // 
            // closesesion
            // 
            this.closesesion.BackColor = System.Drawing.Color.Transparent;
            this.closesesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closesesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closesesion.FlatAppearance.BorderSize = 0;
            this.closesesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closesesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closesesion.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closesesion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closesesion.Image = global::ParkingStorage_System.Properties.Resources.logout;
            this.closesesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closesesion.Location = new System.Drawing.Point(-4, 502);
            this.closesesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closesesion.Name = "closesesion";
            this.closesesion.Size = new System.Drawing.Size(305, 40);
            this.closesesion.TabIndex = 9;
            this.closesesion.Text = "Cerrar Sesión";
            this.closesesion.UseVisualStyleBackColor = false;
            // 
            // carnet
            // 
            this.carnet.BackColor = System.Drawing.Color.Transparent;
            this.carnet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.carnet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.carnet.FlatAppearance.BorderSize = 0;
            this.carnet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.carnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carnet.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carnet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.carnet.Image = global::ParkingStorage_System.Properties.Resources.parking_card;
            this.carnet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.carnet.Location = new System.Drawing.Point(4, 211);
            this.carnet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carnet.Name = "carnet";
            this.carnet.Size = new System.Drawing.Size(305, 40);
            this.carnet.TabIndex = 3;
            this.carnet.Text = "Carnets";
            this.carnet.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(38, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(84, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Secretaria";
            // 
            // franja1
            // 
            this.franja1.BackColor = System.Drawing.Color.RoyalBlue;
            this.franja1.Controls.Add(this.close);
            this.franja1.Controls.Add(this.minize);
            this.franja1.Controls.Add(this.label1);
            this.franja1.Controls.Add(this.pictureBox1);
            this.franja1.Location = new System.Drawing.Point(15, 6);
            this.franja1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.franja1.Name = "franja1";
            this.franja1.Size = new System.Drawing.Size(1144, 40);
            this.franja1.TabIndex = 11;
            // 
            // close
            // 
            this.close.BackgroundImage = global::ParkingStorage_System.Properties.Resources.delete;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Location = new System.Drawing.Point(1450, 5);
            this.close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(38, 29);
            this.close.TabIndex = 2;
            // 
            // minize
            // 
            this.minize.BackgroundImage = global::ParkingStorage_System.Properties.Resources.minimize;
            this.minize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minize.Location = new System.Drawing.Point(1405, 5);
            this.minize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.minize.Name = "minize";
            this.minize.Size = new System.Drawing.Size(38, 29);
            this.minize.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parking Storage - Panel de Control";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParkingStorage_System.Properties.Resources.dashboard_14_512__1_;
            this.pictureBox1.Location = new System.Drawing.Point(14, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Secretaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 602);
            this.Controls.Add(this.franja1);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Secretaria";
            this.Text = "Secretaria";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.franja1.ResumeLayout(false);
            this.franja1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Button closesesion;
        private System.Windows.Forms.Button carnet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel franja1;
        private System.Windows.Forms.Panel close;
        private System.Windows.Forms.Panel minize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}