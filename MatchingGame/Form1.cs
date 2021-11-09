using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };

        public Form1()
        {
            InitializeComponent();
            initializeIcons();
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
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
