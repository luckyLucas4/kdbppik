namespace paint
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Penna = new System.Windows.Forms.RadioButton();
            this.Linje = new System.Windows.Forms.RadioButton();
            this.Rektangel = new System.Windows.Forms.RadioButton();
            this.Cirkel = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(233, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 480);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Egenskaper";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(7, 69);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // Penna
            // 
            this.Penna.AutoSize = true;
            this.Penna.Location = new System.Drawing.Point(60, 243);
            this.Penna.Name = "Penna";
            this.Penna.Size = new System.Drawing.Size(70, 21);
            this.Penna.TabIndex = 0;
            this.Penna.TabStop = true;
            this.Penna.Text = "Penna";
            this.Penna.UseVisualStyleBackColor = true;
            // 
            // Linje
            // 
            this.Linje.AutoSize = true;
            this.Linje.Location = new System.Drawing.Point(59, 296);
            this.Linje.Name = "Linje";
            this.Linje.Size = new System.Drawing.Size(59, 21);
            this.Linje.TabIndex = 1;
            this.Linje.TabStop = true;
            this.Linje.Text = "Linje";
            this.Linje.UseVisualStyleBackColor = true;
            // 
            // Rektangel
            // 
            this.Rektangel.AutoSize = true;
            this.Rektangel.Location = new System.Drawing.Point(59, 345);
            this.Rektangel.Name = "Rektangel";
            this.Rektangel.Size = new System.Drawing.Size(93, 21);
            this.Rektangel.TabIndex = 2;
            this.Rektangel.TabStop = true;
            this.Rektangel.Text = "Rektangel";
            this.Rektangel.UseVisualStyleBackColor = true;
            // 
            // Cirkel
            // 
            this.Cirkel.AutoSize = true;
            this.Cirkel.Location = new System.Drawing.Point(60, 391);
            this.Cirkel.Name = "Cirkel";
            this.Cirkel.Size = new System.Drawing.Size(64, 21);
            this.Cirkel.TabIndex = 3;
            this.Cirkel.TabStop = true;
            this.Cirkel.Text = "Cirkel";
            this.Cirkel.UseVisualStyleBackColor = true;
            this.Cirkel.CheckedChanged += new System.EventHandler(this.Cirkel_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 531);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cirkel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Rektangel);
            this.Controls.Add(this.Penna);
            this.Controls.Add(this.Linje);
            this.Name = "Form1";
            this.Text = "Bästa Paint Programmet";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton Penna;
        private System.Windows.Forms.RadioButton Linje;
        private System.Windows.Forms.RadioButton Rektangel;
        private System.Windows.Forms.RadioButton Cirkel;
    }
}

