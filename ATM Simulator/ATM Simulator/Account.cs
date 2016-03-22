using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulator
{
    public class Account
    {
        public string ID;
        public string Pin;
        public decimal Balance
        {
            get { return Balance; }
            set {
                Balance = decimal.Round(value, 2);
            }
        }

        public Account(string id, string pin, decimal balance)
        {
            this.ID = id;
            this.Pin = pin;
            this.Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            bool action = false;

            lock(this)
            {
                if (this.Balance > amount)
                {
                    this.Balance -= amount;
                    action = true;
                }
            }

            return action;
        }

        public bool CheckPin(string pin)
        {
            return (this.Pin == pin);
        }
    }
}
