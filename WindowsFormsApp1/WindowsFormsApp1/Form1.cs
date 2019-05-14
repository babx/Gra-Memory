using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> ikony = new List<string>()
        {
            "H", "H", "h", "h", "%", "%", "o", "o", "N", "N", "$", "$", "b", "b", "d", "d"
        };
        int a = 0;
        Label klik1, klik2;
        public Form1()
        {
            InitializeComponent();
            timer2.Start();
            Obrazki();

        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (klik1 != null && klik2 != null)
                return;

            Label ClickedLabel = sender as Label;

            if (ClickedLabel == null)
                return;

            if (ClickedLabel.ForeColor == Color.Black)
                return;

            if (klik1 == null)
            {
                klik1 = ClickedLabel;
                klik1.ForeColor = Color.Black;
                return;
            }

            klik2 = ClickedLabel;
            klik2.ForeColor = Color.Black;

            Sprawdzenie();

            if(klik1.Text == klik2.Text )
            {
                klik1 = null;
                klik2 = null;
            }
            else
                timer1.Start();
        }

        private void Sprawdzenie()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show("Udało Ci się ukończyć grę w " + a + " sekund", "Gratulacje!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            klik1.ForeColor = klik2.BackColor;
            klik2.ForeColor = klik1.BackColor;

            klik1 = null;
            klik2 = null; 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {           
           a++;
        }

        private void Obrazki()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(ikony.Count);
                    iconLabel.Text = ikony[randomNumber];                 
                    ikony.RemoveAt(randomNumber);
                }
            }
        }
    }
}
