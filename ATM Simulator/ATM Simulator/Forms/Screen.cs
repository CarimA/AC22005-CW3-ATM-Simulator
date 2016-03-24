using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator.Forms
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }

        public void SetText(string Text)
        {
            this.lblDisplay.Text = Text;
        }
    }
}
