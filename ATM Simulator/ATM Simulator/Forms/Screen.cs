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
        public SimulatorManager Manager;

        public Screen(SimulatorManager manager)
        {
            InitializeComponent();
            this.Manager = manager;
        }

        private void Screen_Load(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
