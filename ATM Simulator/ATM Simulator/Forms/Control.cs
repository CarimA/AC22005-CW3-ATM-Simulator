using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator.Forms
{
    public partial class Control : Form
    {
        public SimulatorManager Manager;

        public Control(SimulatorManager manager)
        {
            InitializeComponent();
            this.Manager = manager;
        }

        private void btnInstance_Click(object sender, EventArgs e)
        {
            Simulator s = new Simulator(this.Manager.Master, Guid.NewGuid().ToString());
            Thread thread = new Thread(new ThreadStart(s.Run));
            this.Manager.Simulators.Add(s);
            thread.Start();
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            this.Manager.AccountManagement.Show();
        }

        private void Control_Load(object sender, EventArgs e)
        {

        }
    }
}
