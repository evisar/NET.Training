using Day3.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Day3.UnitTestingSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileService = new XmlFileService();
            var logger = new FileLogger();
            var ps = new PaymentService(fileService, logger);

            ps.Pay(textBox1.Text, textBox2.Text, double.Parse(textBox3.Text));
        }
    }
}
