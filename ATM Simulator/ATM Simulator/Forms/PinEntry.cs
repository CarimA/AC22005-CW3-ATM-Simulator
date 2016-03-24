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
    public partial class PinEntry : Form
    {
        public PinEntry()
        {
            InitializeComponent();
        }

        private void PinEntry_Load(object sender, EventArgs e)
        {

        }

        public void ToggleButton(Button button, bool state)
        {
            button.Enabled = state;
        }
    }
}
