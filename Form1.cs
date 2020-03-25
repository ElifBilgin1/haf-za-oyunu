using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k",
            "b","b","v","v","w","w","z","z",
        };

        Label firstClicked, secondClicked;
        public Form1()
        {
            InitializeComponent();
            KarelereSimgeAtamak();
        }

        private void label_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            if (firstClicked != null && secondClicked != null)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;
            if (clickedLabel.ForeColor == Color.Black)
                return;
            if (firstClicked == null) 
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();//kazanan için kontrol et


            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
              timer1.Start();
        }

        private void CheckForWinner()
        {
            
            Label label;
            for(int i=0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            timer2.Enabled = false;
            int sure = Convert.ToInt32(label17.Text);
            int dakika, saniye;
            if(sure>=60)
            {
                dakika = sure / 60;
                saniye = sure % 60;

                MessageBox.Show(dakika+" dakika "+saniye+" saniye içerisinde buldunuz.");
            }
            else
            {
                saniye = sure;
                MessageBox.Show(saniye + " saniye içerisinde buldunuz.");
            }
            timer2.Stop();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(label17.Text);
            sayi++;
            label17.Text = sayi.ToString();
        }

        private void KarelereSimgeAtamak()
        {
            Label label;
            int randomNumber;

            for(int i=0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];

                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);
            }
        }
        
    }
}
