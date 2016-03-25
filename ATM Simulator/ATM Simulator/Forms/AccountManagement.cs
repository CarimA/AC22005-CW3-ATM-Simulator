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
    public partial class AccountManagement : Form
    {
        public SimulatorManager Manager;

        public AccountManagement(SimulatorManager manager)
        {
            InitializeComponent();
            this.Manager = manager;

            this.OKBtn.Click += OKBtn_Click;
        }

        void OKBtn_Click(object sender, EventArgs e)
        {
            string accountID = this.AccNoBox.Text;
            string pin = this.PinBox.Text;
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
            if (this.Manager.Accounts.SingleOrDefault((x) => x.ID == accountID.Trim()) != null)
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
            this.Manager.Accounts.Add(new Account(accountID, pin, new Random().Next(1, 5) * 100));
            MessageBox.Show("Account added.");

            this.Hide();
            this.AccNoBox.Text = string.Empty;
            this.PinBox.Text = string.Empty;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.AccNoBox.Text = string.Empty;
            this.PinBox.Text = string.Empty;
        }

        private void AccNoBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
