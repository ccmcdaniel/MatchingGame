using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;

        bool allowClicking = true;

        Random random = new Random();

        SoundPlayer pop;

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        public Form1()
        {
            InitializeComponent();
            initializeIcons();

            pop = new SoundPlayer(MatchingGame.Properties.Resources.popSound);
        }

        private void initializeIcons()
        {
            foreach(Control c in tableLayoutPanel1.Controls)
            {
                Label icon = c as Label;

                int chosen = random.Next(icons.Count);
                string chosenText = icons[chosen];

                icons.RemoveAt(chosen);

                icon.Text = chosenText;

                icon.ForeColor = icon.BackColor;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewForm();

            frm.Show();
            frm.Hide();

            Label icon = sender as Label;

            if (allowClicking == false)
                return;

            if (icon.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = icon;
            }
            else if(secondClicked == null && firstClicked != icon)
            {
                secondClicked = icon;

                if(firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                }
                else
                {
                    //Didn't match
                    hideMismatches.Start();
                    allowClicking = false;
                }
            }


            icon.ForeColor = Color.Black;

            pop.Play();

            if (checkWin() == true)
            {
                if(MessageBox.Show("You did it!!!", "Congrats") == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        private bool checkWin()
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                Label icon = c as Label;

                if (icon.ForeColor == icon.BackColor)
                    return false;
            }

            return true;
        }

        private void hideMismatches_Tick(object sender, EventArgs e)
        {
            hideMismatches.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;

            allowClicking = true;
        }
    }
}
