using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public class Simulator
    {
        public SimulatorManager Manager { get; set; }

        public BackgroundWorker DepositWorker { get; set; }
        public BackgroundWorker WithdrawWorker { get; set; }

        public AtmState State { get; set; }

        public string InstanceName { get; private set; }
        public Forms.Screen Screen { get; private set; }
        public Forms.PinEntry PinEntry { get; private set; }

        public string KeyedInput { get; set; }
        public bool DecimalAdded { get; set; }

        private string Account { get; set; }
        //private int PinAttempts { get; set; }

        public Simulator(SimulatorManager manager, string instanceName)
        {
            //this.Master = master;
            this.InstanceName = instanceName;
            this.Manager = manager;
            
            this.Screen = new Forms.Screen();
            //this.Screen.MdiParent = master;
            this.Screen.StartPosition = FormStartPosition.CenterScreen;
            this.Screen.Text = string.Format(this.Screen.Text + " [{0}]", this.InstanceName);
            this.Screen.Location = new System.Drawing.Point(this.Screen.Location.X, this.Screen.Location.Y - this.Screen.Height / 2 + 10);
            this.Screen.Size = new System.Drawing.Size(388, 320);

            this.PinEntry = new Forms.PinEntry();
            //this.PinEntry.MdiParent = master;
            this.PinEntry.StartPosition = FormStartPosition.CenterScreen;
            this.PinEntry.Text = string.Format(this.PinEntry.Text);
            this.PinEntry.Location = new System.Drawing.Point(this.PinEntry.Location.X, this.PinEntry.Location.Y + this.PinEntry.Height / 2 + 10);
            this.PinEntry.Size = new System.Drawing.Size(300, 321);

            this.Screen.Move += Screen_Move;
            this.PinEntry.Move += PinEntry_Move;

            this.PinEntry.btnOne.Click += btnOne_Click;
            this.PinEntry.btnTwo.Click += btnTwo_Click;
            this.PinEntry.btnThree.Click += btnThree_Click;
            this.PinEntry.btnFour.Click += btnFour_Click;
            this.PinEntry.btnFive.Click += btnFive_Click;
            this.PinEntry.btnSix.Click += btnSix_Click;
            this.PinEntry.btnSeven.Click += btnSeven_Click;
            this.PinEntry.btnEight.Click += btnEight_Click;
            this.PinEntry.btnNine.Click += btnNine_Click;
            this.PinEntry.btnZero.Click += btnZero_Click;
            this.PinEntry.btnDecimal.Click += btnDecimal_Click;
            this.PinEntry.btnCancel.Click += btnCancel_Click;
            this.PinEntry.btnClear.Click += btnClear_Click;
            this.PinEntry.btnEnter.Click += btnEnter_Click;

            DepositWorker = new BackgroundWorker();
            DepositWorker.DoWork += DepositWorker_DoWork;

            WithdrawWorker = new BackgroundWorker();
            WithdrawWorker.DoWork += WithdrawWorker_DoWork;
        }

        public void Run()
        {
            this.State = AtmState.EnterAccount;

            this.DisplayMenu();

            InvokeShowScreen();
            InvokeShowPinEntry();
        }

        public void Stop()
        {
            this.Screen.Close();
            this.PinEntry.Close();
        }

        delegate void ShowScreenCallback();
        public void InvokeShowScreen()
        {
            if (this.Screen.InvokeRequired)
            {
                ShowScreenCallback c = new ShowScreenCallback(this.ShowScreen);
                this.Screen.Invoke(c, new object[] {});
            }
            else
                ShowScreen();
        }

        private void ShowScreen()
        {
            this.Screen.Show();
        }


        delegate void ShowPinEntryCallback();
        public void InvokeShowPinEntry()
        {
            if (this.PinEntry.InvokeRequired)
            {
                ShowPinEntryCallback c = new ShowPinEntryCallback(this.ShowPinEntry);
                this.PinEntry.Invoke(c, new object[] { });
            }
            else
                ShowPinEntry();
        }

        private void ShowPinEntry()
        {
            this.PinEntry.Show();
        }

        delegate void SetScreenTextCallback(string Text);
        public void SetScreenText(string Text)
        {
            if (this.Screen.InvokeRequired)
            {
                SetScreenTextCallback c = new SetScreenTextCallback(this.Screen.SetText);
                this.Screen.Invoke(c, new object[] { Text });
            }
            else
                this.Screen.SetText(Text);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // I don't like this.
            switch (this.State)
            {
                case AtmState.EnterAccount:
                    if (this.Manager.AccountExists(this.KeyedInput))
                    {
                        this.Account = KeyedInput;
                        this.State = AtmState.EnterPin;
                    }
                    Clear();
                    break;

                case AtmState.EnterPin:
                    if (this.Manager.CheckPin(this.Account, this.KeyedInput))
                    {
                        this.State = AtmState.AtmMenu;
                    }
                    Clear();
                    break;

                case AtmState.AtmMenu:
                    switch (this.KeyedInput)
                    {
                        case "1": // Deposit
                            this.State = AtmState.Deposit;
                            break;

                        case "2": // Withdraw
                            this.State = AtmState.Withdraw;
                            break;

                        case "3":
                            this.State = AtmState.Balance;
                            break;

                        case "4":
                            this.Stop();
                            break;
                    }
                    Clear();
                    break;
                    

                case AtmState.Deposit:
                    DepositWorker.RunWorkerAsync();
                    break;
                    
                case AtmState.Withdraw:
                    WithdrawWorker.RunWorkerAsync();
                    break;


                case AtmState.Balance:
                case AtmState.DepositSuccess:
                case AtmState.WithdrawFail:
                case AtmState.WithdrawSuccess:
                    this.State = AtmState.AtmMenu;
                    Clear();
                    break;
            }
        }


        void DepositWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DisableButtons();

            decimal amount = 0;
            decimal.TryParse(this.KeyedInput, out amount);
            System.Threading.Thread.Sleep(new Random().Next(10, 20) * 1000);
            this.Manager.Deposit(this.Account, amount);
            this.State = AtmState.DepositSuccess;
            Clear();

            this.EnableButtons();
        }

        void WithdrawWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.DisableButtons();
            decimal amount = 0;
            decimal.TryParse(this.KeyedInput, out amount);
            System.Threading.Thread.Sleep(new Random().Next(10, 20) * 1000);
            if (this.Manager.Withdraw(this.Account, amount))
            {

                this.State = AtmState.WithdrawSuccess;
            }
            else
            {
                this.State = AtmState.WithdrawFail;
            }
            Clear();

            this.EnableButtons();
        }

        private void EnableButtons()
        {
            ToggleButtons(true);
        }

        public void DisableButtons()
        {
            ToggleButtons(false);
        }

        delegate void DisableButtonCallback(Button button, bool state);
        public void ToggleButtons(bool state)
        {
            if (this.PinEntry.InvokeRequired)
            {
                DisableButtonCallback a = new DisableButtonCallback(this.PinEntry.ToggleButton);
                this.PinEntry.Invoke(a, new object[] { this.PinEntry.btnClear, state });
                DisableButtonCallback b = new DisableButtonCallback(this.PinEntry.ToggleButton);
                this.PinEntry.Invoke(b, new object[] { this.PinEntry.btnEnter, state });
                DisableButtonCallback c = new DisableButtonCallback(this.PinEntry.ToggleButton);
                this.PinEntry.Invoke(c, new object[] { this.PinEntry.btnCancel, state });
            }
            else
            {
                this.PinEntry.btnClear.Enabled = state;
                this.PinEntry.btnEnter.Enabled = state;
                this.PinEntry.btnCancel.Enabled = state;
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            this.KeyedInput = string.Empty;
            this.DisplayMenu();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Stop();
        }

        public void DisplayMenu()
        {
            switch (this.State)
            {
                case AtmState.EnterAccount:
                    this.SetScreenText("Please enter your account number: \r\n");
                    break;

                case AtmState.EnterPin:
                    this.SetScreenText("Please enter your PIN: \r\n");
                    break;

                case AtmState.AtmMenu:
                    this.SetScreenText(string.Format("Welcome, {0}.\r\nPlease select your option and press enter:\r\n1) Deposit Money\r\n2) Withdraw Money\r\n3) Check Balance\r\n4) Return Card\r\n", this.Account));
                    break;

                case AtmState.Balance:
                    this.SetScreenText(string.Format("Your balance is £{0}.\r\nPress Enter to continue.\r\n", this.Manager.GetBalance(this.Account)));
                    break;

                case AtmState.Deposit:
                    this.SetScreenText(string.Format("Enter the amount to deposit in to your account:\r\n"));
                    break;

                case AtmState.DepositSuccess:
                    this.SetScreenText(string.Format("Deposit entered. Your balance is £{0}.\r\nPress Enter to continue.\r\n", this.Manager.GetBalance(this.Account)));
                    break;

                case AtmState.Withdraw:
                    this.SetScreenText(string.Format("Enter the amount to withdraw from your account:\r\n"));
                    break;

                case AtmState.WithdrawSuccess:
                    this.SetScreenText(string.Format("Success. Your balance is £{0}.\r\nPress Enter to continue.\r\n", this.Manager.GetBalance(this.Account)));
                    break;

                case AtmState.WithdrawFail:
                     this.SetScreenText(string.Format("You do not have sufficient funds in your account.\r\nPress Enter to return.\r\n"));
                     break; 
            }
        }
           
        private void btnZero_Click(object sender, EventArgs e)  { this.AddPin(0); }
        private void btnNine_Click(object sender, EventArgs e)  { this.AddPin(9); }
        private void btnEight_Click(object sender, EventArgs e) { this.AddPin(8); }
        private void btnSeven_Click(object sender, EventArgs e) { this.AddPin(7); }
        private void btnSix_Click(object sender, EventArgs e)   { this.AddPin(6); }
        private void btnFive_Click(object sender, EventArgs e)  { this.AddPin(5); }
        private void btnFour_Click(object sender, EventArgs e)  { this.AddPin(4); }
        private void btnThree_Click(object sender, EventArgs e) { this.AddPin(3); }
        private void btnTwo_Click(object sender, EventArgs e)   { this.AddPin(2); }
        private void btnOne_Click(object sender, EventArgs e)   { this.AddPin(1); }
        private void btnDecimal_Click(object sender, EventArgs e) { this.AddDecimal(); }

        private void PinEntry_Move(object sender, EventArgs e)
        {
            this.Screen.Location = new System.Drawing.Point(
                this.PinEntry.Location.X + (this.PinEntry.Width / 2) - (this.Screen.Width / 2),
                this.PinEntry.Location.Y - this.Screen.Height);
        }

        private void Screen_Move(object sender, EventArgs e)
        {
            this.PinEntry.Location = new System.Drawing.Point(
                this.Screen.Location.X + (this.Screen.Width / 2) - (this.PinEntry.Width / 2), 
                this.Screen.Location.Y + this.Screen.Height);
        }

        private void AddPin(int number)
        {
            if (this.State == AtmState.Balance)
                return;

            this.Screen.lblDisplay.Text += number;
            KeyedInput += number;
        }

        private void AddDecimal()
        {
            if (DecimalAdded)
                return;

            if (!(this.State == AtmState.Deposit || this.State == AtmState.Withdraw))
                return;

            this.Screen.lblDisplay.Text += ".";
            KeyedInput += ".";
            this.DecimalAdded = true;
        }
    }

    public enum AtmState
    {
        EnterAccount = 0,
        EnterPin,
        AtmMenu,
        Deposit,
        DepositSuccess,
        Withdraw, 
        WithdrawSuccess,
        WithdrawFail,
        Balance
    }
}
