namespace Bästa_Paint_programmet
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
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.rBtnPenna = new System.Windows.Forms.RadioButton();
            this.rBtnLinje = new System.Windows.Forms.RadioButton();
            this.rBtnRektangel = new System.Windows.Forms.RadioButton();
            this.rBtnCirkel = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnUndo = new System.Windows.Forms.Button();
            this.chbFill = new System.Windows.Forms.CheckBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(233, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 480);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numWidth);
            this.groupBox1.Controls.Add(this.btnColor);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Egenskaper";
            // 
            // numWidth
            // 
            this.numWidth.DecimalPlaces = 1;
            this.numWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(46, 40);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(93, 30);
            this.numWidth.TabIndex = 7;
            this.numWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Green;
            this.btnColor.Location = new System.Drawing.Point(46, 76);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(93, 33);
            this.btnColor.TabIndex = 6;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // rBtnPenna
            // 
            this.rBtnPenna.AutoSize = true;
            this.rBtnPenna.Checked = true;
            this.rBtnPenna.Location = new System.Drawing.Point(58, 193);
            this.rBtnPenna.Name = "rBtnPenna";
            this.rBtnPenna.Size = new System.Drawing.Size(70, 21);
            this.rBtnPenna.TabIndex = 0;
            this.rBtnPenna.TabStop = true;
            this.rBtnPenna.Text = "Penna";
            this.rBtnPenna.UseVisualStyleBackColor = true;
            this.rBtnPenna.CheckedChanged += new System.EventHandler(this.rBtnPenna_CheckedChanged);
            // 
            // rBtnLinje
            // 
            this.rBtnLinje.AutoSize = true;
            this.rBtnLinje.Location = new System.Drawing.Point(57, 241);
            this.rBtnLinje.Name = "rBtnLinje";
            this.rBtnLinje.Size = new System.Drawing.Size(59, 21);
            this.rBtnLinje.TabIndex = 1;
            this.rBtnLinje.Text = "Linje";
            this.rBtnLinje.UseVisualStyleBackColor = true;
            this.rBtnLinje.CheckedChanged += new System.EventHandler(this.rBtnLinje_CheckedChanged);
            // 
            // rBtnRektangel
            // 
            this.rBtnRektangel.AutoSize = true;
            this.rBtnRektangel.Location = new System.Drawing.Point(57, 290);
            this.rBtnRektangel.Name = "rBtnRektangel";
            this.rBtnRektangel.Size = new System.Drawing.Size(93, 21);
            this.rBtnRektangel.TabIndex = 2;
            this.rBtnRektangel.Text = "Rektangel";
            this.rBtnRektangel.UseVisualStyleBackColor = true;
            this.rBtnRektangel.CheckedChanged += new System.EventHandler(this.rBtnRektangel_CheckedChanged);
            // 
            // rBtnCirkel
            // 
            this.rBtnCirkel.AutoSize = true;
            this.rBtnCirkel.Location = new System.Drawing.Point(58, 336);
            this.rBtnCirkel.Name = "rBtnCirkel";
            this.rBtnCirkel.Size = new System.Drawing.Size(64, 21);
            this.rBtnCirkel.TabIndex = 3;
            this.rBtnCirkel.Text = "Cirkel";
            this.rBtnCirkel.UseVisualStyleBackColor = true;
            this.rBtnCirkel.CheckedChanged += new System.EventHandler(this.rbtnCirkel_CheckedChanged);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(57, 470);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(45, 23);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "<-- ";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // chbFill
            // 
            this.chbFill.AutoSize = true;
            this.chbFill.Location = new System.Drawing.Point(58, 399);
            this.chbFill.Name = "chbFill";
            this.chbFill.Size = new System.Drawing.Size(106, 21);
            this.chbFill.TabIndex = 5;
            this.chbFill.Text = "Fyll i formen";
            this.chbFill.UseVisualStyleBackColor = true;
            this.chbFill.CheckedChanged += new System.EventHandler(this.chbFill_CheckedChanged);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(119, 470);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(45, 23);
            this.btnRedo.TabIndex = 4;
            this.btnRedo.Text = "--> ";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 531);
            this.Controls.Add(this.chbFill);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rBtnCirkel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rBtnRektangel);
            this.Controls.Add(this.rBtnPenna);
            this.Controls.Add(this.rBtnLinje);
            this.Name = "Form1";
            this.Text = "Bästa Paint Programmet";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnPenna;
        private System.Windows.Forms.RadioButton rBtnLinje;
        private System.Windows.Forms.RadioButton rBtnCirkel;
        private System.Windows.Forms.RadioButton rBtnRektangel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.CheckBox chbFill;
        private System.Windows.Forms.Button btnRedo;
    }
}

