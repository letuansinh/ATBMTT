using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaBang
{
    public partial class Form1 : Form
    {
        DaBangHelper db = new DaBangHelper();
        public Form1()
        {
            InitializeComponent();
        }
        private async void btopen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        tbDuLieuCanMaHoa.Text = await sr.ReadToEndAsync();
                    }
                }
            }
        }
        private void btMaHoa_Click(object sender, EventArgs e)
        {

            if (tbDuLieuCanMaHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập dữ liệu cần mã hoá");
                tbDuLieuCanMaHoa.Focus();
                return;
            }
            else
            {
                tbDuLieuDaMaHoa.Text = db.MaHoa(tbDuLieuCanMaHoa.Text);
            }
        }

        private void btGiaiMa_Click(object sender, EventArgs e)
        {

            if (tbDuLieuDaMaHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập dữ liệu:");
            }
            else
            {
                String key = db.khoa;
                tbDuLieuDaGiaiMa.Text = db.GiaiMa(tbDuLieuDaMaHoa.Text, key);
            }
        }  
    }
}
