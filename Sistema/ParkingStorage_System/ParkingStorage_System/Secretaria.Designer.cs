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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Secretaria));
            this.franja1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.closesesion = new System.Windows.Forms.Button();
            this.carnet = new System.Windows.Forms.Button();
            this.lbladmin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Panel();
            this.minize = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelcontenedor = new System.Windows.Forms.Panel();
            this.franja1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // franja1
            // 
            this.franja1.BackColor = System.Drawing.Color.RoyalBlue;
            this.franja1.Controls.Add(this.close);
            this.franja1.Controls.Add(this.minize);
            this.franja1.Controls.Add(this.label1);
            this.franja1.Controls.Add(this.pictureBox1);
            this.franja1.Location = new System.Drawing.Point(0, 0);
            this.franja1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.franja1.Name = "franja1";
            this.franja1.Size = new System.Drawing.Size(1676, 33);
            this.franja1.TabIndex = 1;
            this.franja1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.franja1_MouseMove);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.MidnightBlue;
            this.menu.Controls.Add(this.panelcontenedor);
            this.menu.Controls.Add(this.panel1);
            this.menu.Controls.Add(this.closesesion);
            this.menu.Controls.Add(this.carnet);
            this.menu.Controls.Add(this.lbladmin);
            this.menu.Controls.Add(this.label2);
            this.menu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menu.Location = new System.Drawing.Point(0, 32);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(244, 508);
            this.menu.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(244, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 502);
            this.panel1.TabIndex = 2;
            // 
            // closesesion
            // 
            this.closesesion.BackColor = System.Drawing.Color.Transparent;
            this.closesesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closesesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closesesion.FlatAppearance.BorderSize = 0;
            this.closesesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.closesesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closesesion.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closesesion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closesesion.Image = global::ParkingStorage_System.Properties.Resources.logout;
            this.closesesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closesesion.Location = new System.Drawing.Point(0, 442);
            this.closesesion.Name = "closesesion";
            this.closesesion.Size = new System.Drawing.Size(244, 35);
            this.closesesion.TabIndex = 9;
            this.closesesion.Text = "Cerrar Sesión";
            this.closesesion.UseVisualStyleBackColor = false;
            this.closesesion.Click += new System.EventHandler(this.closesesion_Click);
            // 
            // carnet
            // 
            this.carnet.BackColor = System.Drawing.Color.Transparent;
            this.carnet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.carnet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.carnet.FlatAppearance.BorderSize = 0;
            this.carnet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.carnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.carnet.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carnet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.carnet.Image = global::ParkingStorage_System.Properties.Resources.parking_card;
            this.carnet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.carnet.Location = new System.Drawing.Point(0, 139);
            this.carnet.Name = "carnet";
            this.carnet.Size = new System.Drawing.Size(244, 35);
            this.carnet.TabIndex = 3;
            this.carnet.Text = "Carnets";
            this.carnet.UseVisualStyleBackColor = false;
            this.carnet.Click += new System.EventHandler(this.carnet_Click);
            // 
            // lbladmin
            // 
            this.lbladmin.AutoSize = true;
            this.lbladmin.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmin.ForeColor = System.Drawing.Color.White;
            this.lbladmin.Location = new System.Drawing.Point(24, 52);
            this.lbladmin.Name = "lbladmin";
            this.lbladmin.Size = new System.Drawing.Size(53, 17);
            this.lbladmin.TabIndex = 2;
            this.lbladmin.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(67, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Secretaria";
            // 
            // close
            // 
            this.close.BackgroundImage = global::ParkingStorage_System.Properties.Resources.delete;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Location = new System.Drawing.Point(1160, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 26);
            this.close.TabIndex = 2;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minize
            // 
            this.minize.BackgroundImage = global::ParkingStorage_System.Properties.Resources.minimize;
            this.minize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minize.Location = new System.Drawing.Point(1124, 4);
            this.minize.Name = "minize";
            this.minize.Size = new System.Drawing.Size(30, 26);
            this.minize.TabIndex = 1;
            this.minize.Click += new System.EventHandler(this.minize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parking Storage";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ParkingStorage_System.Properties.Resources.dashboard_14_512__1_;
            this.pictureBox1.Location = new System.Drawing.Point(11, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panelcontenedor
            // 
            this.panelcontenedor.BackColor = System.Drawing.Color.White;
            this.panelcontenedor.Location = new System.Drawing.Point(244, 0);
            this.panelcontenedor.Name = "panelcontenedor";
            this.panelcontenedor.Size = new System.Drawing.Size(957, 508);
            this.panelcontenedor.TabIndex = 4;
            // 
            // Secretaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 538);
            this.ControlBox = false;
            this.Controls.Add(this.menu);
            this.Controls.Add(this.franja1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Secretaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secretaria";
            this.franja1.ResumeLayout(false);
            this.franja1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel franja1;
        private System.Windows.Forms.Panel close;
        private System.Windows.Forms.Panel minize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closesesion;
        private System.Windows.Forms.Button carnet;
        public System.Windows.Forms.Label lbladmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelcontenedor;
    }
}