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
        public List<Account> Accounts { get; private set; }
        public Forms.Master Master { get; private set; }
        public Forms.Control Control { get; private set; }

        public Forms.AccountManagement AccountManagement { get; private set; }


        public SimulatorManager()
        {
            this.Simulators = new List<Simulator>();
            this.Accounts = new List<Account>();    

            this.Master = new Forms.Master();

            this.Control = new Forms.Control();
            this.Control.MdiParent = this.Master;
            this.Control.Show();

            this.AccountManagement = new Forms.AccountManagement();
            this.AccountManagement.MdiParent = this.Master;
            this.AccountManagement.OKBtn.Click += OKBtn_Click;

            this.Control.btnInstance.Click += btnInstance_Click;
            this.Control.btnNewAccount.Click += btnNewAccount_Click;

            Application.Run(this.Master);
        }

        void btnNewAccount_Click(object sender, EventArgs e)
        {
            this.AccountManagement.Show();

        }

        void OKBtn_Click(object sender, EventArgs e)
        {
            string accountID = this.AccountManagement.AccNoBox.Text;
            string pin = this.AccountManagement.PinBox.Text;
            int temp;

            // check if accout ID is valid
            if (!int.TryParse(accountID, out temp)) 
            {
                MessageBox.Show("Given Account Number is not numeric.");
                return;
            }

            // check if account ID has 6 digits
            if (accountID.Length != 6)
            {
                MessageBox.Show("Given Account Number is not 6 digits.");
                return;
            }

            // check if account ID is taken
            if (this.Accounts.SingleOrDefault((x) => x.ID == accountID.Trim()) != null)
            {
                MessageBox.Show("Given Account Number is taken.");
                return;
            }

            // check if PIN is valid
            if (!int.TryParse(pin, out temp))
            {
                MessageBox.Show("Given PIN is not numeric.");
                return;
            }

            // check if PIN has 4 digits
            if (pin.Length != 4)
            {
                MessageBox.Show("Given PIN is not 4 digits.");
                return;
            }

            // everything is fine: add.
            this.Accounts.Add(new Account(accountID, pin, new Random().Next(1, 5) * 100));
            MessageBox.Show("Account added.");

            this.AccountManagement.Hide();
            this.AccountManagement.AccNoBox.Text = string.Empty;
            this.AccountManagement.PinBox.Text = string.Empty;
        }

        void btnInstance_Click(object sender, EventArgs e)
        {
            Simulators.Add(new Simulator(this.Master, Guid.NewGuid().ToString()));
        }
    }
}
