using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.Barcode;

namespace inventory

{
    public partial class frmBarcode : Form
    {
        public frmBarcode()
        {
            InitializeComponent();
        }
        BarcodeEncoder Generator;
        BarcodeDecoder Scanner;
        SaveFileDialog SD;
        OpenFileDialog OD;
        private void button1_Click(object sender, EventArgs e)
        {
            Scanner = new BarcodeDecoder();
            Result result = Scanner.Decode(new Bitmap(pictureBox1.Image));
            MessageBox.Show(result.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Generator = new BarcodeEncoder();
            Generator.IncludeLabel = true;
            Generator.CustomLabel = textBox1.Text;
            if (textBox1.Text != "")
                pictureBox1.Image = new Bitmap(Generator.Encode(BarcodeFormat.Code39, textBox1.Text));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SD = new SaveFileDialog();
            SD.Filter = "PNG File|*.png";
            if (SD.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(SD.FileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OD = new OpenFileDialog();
            OD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if(OD.ShowDialog()==DialogResult.OK)
                pictureBox1.Load(OD.FileName);
        }
    }
}
