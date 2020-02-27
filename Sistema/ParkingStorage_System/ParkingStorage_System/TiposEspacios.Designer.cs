namespace ParkingStorage_System
{
    partial class TiposEspacios
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdescripcion = new System.Windows.Forms.RichTextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btndesactivar = new System.Windows.Forms.Button();
            this.btneditar = new System.Windows.Forms.Button();
            this.dgvusuarios = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(39, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(873, 447);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(865, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ingreso de Datos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtdescripcion);
            this.groupBox1.Controls.Add(this.txtnombre);
            this.groupBox1.Controls.Add(this.btnRegistrar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(55, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 353);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese los siguientes datos";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(293, 136);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(220, 96);
            this.txtdescripcion.TabIndex = 10;
            this.txtdescripcion.Text = "";
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(293, 71);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(220, 25);
            this.txtnombre.TabIndex = 9;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Image = global::ParkingStorage_System.Properties.Resources.useres;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(308, 260);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(177, 45);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descripción:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btndesactivar);
            this.tabPage2.Controls.Add(this.btneditar);
            this.tabPage2.Controls.Add(this.dgvusuarios);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnbuscar);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(865, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Búsqueda, Edición y Eliminación";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btndesactivar
            // 
            this.btndesactivar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btndesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesactivar.ForeColor = System.Drawing.Color.White;
            this.btndesactivar.Image = global::ParkingStorage_System.Properties.Resources.dele;
            this.btndesactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndesactivar.Location = new System.Drawing.Point(664, 50);
            this.btndesactivar.Name = "btndesactivar";
            this.btndesactivar.Size = new System.Drawing.Size(179, 45);
            this.btndesactivar.TabIndex = 12;
            this.btndesactivar.Text = "Eliminar";
            this.btndesactivar.UseVisualStyleBackColor = false;
            // 
            // btneditar
            // 
            this.btneditar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btneditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneditar.ForeColor = System.Drawing.Color.White;
            this.btneditar.Image = global::ParkingStorage_System.Properties.Resources.pencil;
            this.btneditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btneditar.Location = new System.Drawing.Point(484, 50);
            this.btneditar.Name = "btneditar";
            this.btneditar.Size = new System.Drawing.Size(162, 45);
            this.btneditar.TabIndex = 11;
            this.btneditar.Text = "Editar";
            this.btneditar.UseVisualStyleBackColor = false;
            // 
            // dgvusuarios
            // 
            this.dgvusuarios.AllowUserToAddRows = false;
            this.dgvusuarios.AllowUserToDeleteRows = false;
            this.dgvusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvusuarios.Location = new System.Drawing.Point(6, 111);
            this.dgvusuarios.Name = "dgvusuarios";
            this.dgvusuarios.ReadOnly = true;
            this.dgvusuarios.Size = new System.Drawing.Size(853, 300);
            this.dgvusuarios.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Búsqueda por nombre";
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.White;
            this.btnbuscar.Image = global::ParkingStorage_System.Properties.Resources.loupe;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.Location = new System.Drawing.Point(300, 50);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(162, 45);
            this.btnbuscar.TabIndex = 9;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipos de Estacionamiento";
            // 
            // TiposEspacios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 500);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TiposEspacios";
            this.Text = "TiposEspacios";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtdescripcion;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btndesactivar;
        private System.Windows.Forms.Button btneditar;
        private System.Windows.Forms.DataGridView dgvusuarios;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Label label1;
    }
}