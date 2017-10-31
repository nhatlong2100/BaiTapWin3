using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Bai_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenApplication_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            string targetName;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    try
                    {
                        Process.Start(openFileDialog1.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn file");
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
