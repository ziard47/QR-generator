using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QRCodeGenerator
{
    public partial class QRGen : Form
    {
        public QRGen()
        {
            InitializeComponent();
        }
        private Bitmap GenerateQRCode(string text)
        {
            var url = "https://chart.googleapis.com/chart?cht=qr&chs=300x300&chl=" + text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            var stream = response.GetResponseStream();
            return new Bitmap(stream);
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            var text = txtText.Text;
            var qrCode = GenerateQRCode(text);
            pictureBox1.Image = qrCode;
        }
    }
}
