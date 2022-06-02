using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Konvolucio.TestExec.Simulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debug Assert Failed!", "Microsoft Visual C++ Debug Library", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
