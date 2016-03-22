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
       // private Account[] acc = new Account[3]();


        public AccountManagement()
        {
            InitializeComponent();
        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Please enter your new account number.");
            //check if account exists 
            //create new account if not
            //save detail
            //must be 6 digits
            //try again if not
        }

        private void PinBox_TextChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Please enter your 4 digit pin number.");
            //enters 4 digit pin
            //check if 4 digits
            //try again if not
            //assign 4 digits to account no.
        }
    }
}
