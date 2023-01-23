using System;
using System.Windows.Forms;

namespace app
{
    public partial class formWhatsApp : Form
    {
        public formWhatsApp()
        {
            InitializeComponent();
        }

        private void formWhatsApp_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://web.whatsapp.com/");
        }
    }
}
