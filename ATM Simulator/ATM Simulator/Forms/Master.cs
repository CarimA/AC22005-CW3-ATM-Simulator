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
    public partial class Master : Form
    {
        public SimulatorManager Manager; 
        public Master(SimulatorManager manager)
        {
            InitializeComponent();
            this.Manager = manager;
        }

        private void Master_Load(object sender, EventArgs e)
        {

        }

        public SimulatorManager GetManager()
        {
            return this.Manager;
        }

        public Master GetMaster()
        {
            return this;
        }
    }
}
