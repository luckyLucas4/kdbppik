using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Bästa_Paint_programmet
{
    public partial class Form1 : Form
    {
        public Color color;     // Sparar färgen som väljs av användaren
        DrawingPanel panel;     // Panelen som användaren kan rita på

        public Form1()
        {
            InitializeComponent();

            // Skapar en ny panel med samma position och storlek som den panel som redan finns i fönstret
            panel = new DrawingPanel(new Pen(Color.Green, 10), panel1.Location, panel1.Size);
            // Lägger till den nya panelen bland kontrollerna i programmet
            Controls.Add(panel);
            // Döljer och avaktiverar den tidigare panelen
            panel1.Visible = false;
            panel1.Enabled = false;

        }
      
        // Hanterar byte av verktyg
        public void ToolCheck()
        {
            // Ser till att variabeln som indikerar att frihandsverktyget 
            // är aktiverat har rätt inställning
            if (rBtnPenna.Checked == true)
                panel.freehandActive = true;
            else
                panel.freehandActive = false;

            // Ändrar currentShape i panelen till rätt klass som ärver av klassen Shape
            if (rBtnLinje.Checked == true)
                panel.currentShape = new LineShape();
            if (rBtnRektangel.Checked == true)
                panel.currentShape = new RectangleShape();
            if (rBtnCirkel.Checked == true)
                panel.currentShape = new CircleShape();
            
        }

        // Hänvisar till funktionen ToolCheck() när valet av verktyg ändras
        private void rbtnCirkel_CheckedChanged(object sender, EventArgs e) { ToolCheck(); }

        private void rBtnRektangel_CheckedChanged(object sender, EventArgs e) { ToolCheck(); }

        private void rBtnLinje_CheckedChanged(object sender, EventArgs e) { ToolCheck(); }

        private void rBtnPenna_CheckedChanged(object sender, EventArgs e) { ToolCheck(); }

        // Aktiveras när användaren klickar på färg-knappen
        private void btnColor_Click(object sender, EventArgs e)
        {
            // Färgväljaren returnerar värdet DialogResult.OK om en färg har valts
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                // Färgen från färgväljaren sparas som color
                color = colorDialog1.Color;
            }
            // Knappens bakgrundsfärg ändras till den valda färgen
            btnColor.BackColor = color;
            // Färgen på pennan som används i panelen ändras till den valda färgen
            panel.currentPen.Color = color;
        }

        // Aktiveras när värdet på kontrollen numWidth ändras
        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            // Tjockleken på pennan som sparas i panelen ändras till det valda värdet 
            panel.currentPen.Width = (float)numWidth.Value;
        }

        // Aktiveras när värdet på CheckedChanged ändras
        private void chbFill_CheckedChanged(object sender, EventArgs e)
        {
            // Booleanen som indikerar om former ska fyllas i eller inte uppdateras
            panel.fillShape = chbFill.Checked;
        }

        // Vid klick på knapparna för att ångra och göra om aktiveras respektive funktion i panelen
        private void btnUndo_Click(object sender, EventArgs e) { panel.UndoChange(); }

        private void btnRedo_Click(object sender, EventArgs e) { panel.RedoChange(); }
    }
}
