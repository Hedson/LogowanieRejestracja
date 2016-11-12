using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogowanieRejestracja
{
    public partial class Biodata : Form
    {
        public Biodata()
        {
            InitializeComponent();
        }

        private void Biodata_Load(object sender, EventArgs e)
        {
            label1.Text = Login.AlreadyUserName;
        }

    }
}
