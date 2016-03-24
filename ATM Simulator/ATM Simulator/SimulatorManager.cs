using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public class SimulatorManager
    {
        public List<Simulator> Simulators { get; private set; }
        public List<Account> Accounts { get; private set; }
        public Forms.Master Master { get; private set; }
        public Forms.Control Control { get; private set; }

        public Forms.AccountManagement AccountManagement { get; private set; }

        public Semaphore ThreadManager { get; private set; }

        public SimulatorManager()
        {
            this.Simulators = new List<Simulator>();
            this.Accounts = new List<Account>();    

            // make three sample accounts as required
            Account ac1 = new Account("111111", "1111", 300.00m);
            Account ac2 = new Account("222222", "2222", 750.00m);
            Account ac3 = new Account("333333", "3333", 3000.00m);

            this.Accounts.Add(ac1);
            this.Accounts.Add(ac2);
            this.Accounts.Add(ac3);

            this.Master = new Forms.Master(this);

            this.Control = new Forms.Control(this);
            this.Control.MdiParent = this.Master;
            this.Control.Show();

            this.AccountManagement = new Forms.AccountManagement(this);
            this.AccountManagement.MdiParent = this.Master;

            this.ThreadManager = new Semaphore(5, 5);
            
            Application.Run(this.Master);
        }        
    }
}
