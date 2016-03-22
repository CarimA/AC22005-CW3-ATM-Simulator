using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public class SimulatorManager
    {
        public List<Simulator> Simulators { get; private set; }
        public Forms.Master Master { get; private set; }
        public Forms.Control Control { get; private set; }

        public SimulatorManager()
        {
            this.Simulators = new List<Simulator>();

            this.Master = new Forms.Master();

            this.Control = new Forms.Control();
            this.Control.MdiParent = this.Master;
            this.Control.Show();


            this.Control.btnInstance.Click += btnInstance_Click;
            this.Control.btnNewAccount.Click += btnNewAccount_Click;

            Application.Run(this.Master);
        }

        void btnNewAccount_Click(object sender, EventArgs e)
        {
            Forms.AccountManagement am = new Forms.AccountManagement();
            am.MdiParent = this.Master;
            am.Show();
        }

        void btnInstance_Click(object sender, EventArgs e)
        {
            Simulators.Add(new Simulator(this.Master, Guid.NewGuid().ToString()));
        }
    }
}
