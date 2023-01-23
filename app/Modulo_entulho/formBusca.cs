using System;
using System.Windows.Forms;

namespace app
{
    public partial class formBusca : Form
    {
        public delegate void PassControl(object sender);
        public PassControl passControl;

        public formBusca()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (passControl != null)
            {
                passControl(textBox1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void formBusca_Load(object sender, EventArgs e)
        {

        }

        private void formBusca_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
