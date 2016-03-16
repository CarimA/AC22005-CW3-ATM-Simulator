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
        public Master()
        {
            InitializeComponent();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            Screen sc = new Screen();
            sc.MdiParent = this;
            sc.Show();

            PinEntry pe = new PinEntry();
            pe.MdiParent = this;
            pe.Show();
        }
    }
}
