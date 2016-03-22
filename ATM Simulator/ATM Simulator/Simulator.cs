﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public class Simulator
    {
        public Forms.Screen Screen { get; private set; }
        public Forms.PinEntry PinEntry { get; private set; }

        public Simulator(Forms.Master master, string instanceName)
        {
            this.Screen = new Forms.Screen();
            this.Screen.MdiParent = master;
            this.Screen.StartPosition = FormStartPosition.CenterScreen;
            this.Screen.Text = string.Format(this.Screen.Text + " [{0}]", instanceName);
            this.Screen.Show();
            this.Screen.Location = new System.Drawing.Point(this.Screen.Location.X, this.Screen.Location.Y - this.Screen.Height / 2 + 10);

            this.PinEntry = new Forms.PinEntry();
            this.PinEntry.MdiParent = master;
            this.PinEntry.StartPosition = FormStartPosition.CenterScreen;
            this.PinEntry.Text = string.Format(this.PinEntry.Text);
            this.PinEntry.Show();
            this.PinEntry.Location = new System.Drawing.Point(this.PinEntry.Location.X, this.PinEntry.Location.Y + this.PinEntry.Height / 2 + 10);

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
            this.PinEntry.btnCancel.Click += btnCancel_Click;
            this.PinEntry.btnClear.Click += btnClear_Click;
            this.PinEntry.btnEnter.Click += btnEnter_Click;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            this.Screen.lblDisplay.Text += number;
        }
    }
}
