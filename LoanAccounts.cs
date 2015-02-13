using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VidaControls
{
    public partial class LoanAccounts : UserControl
    {
        public LoanAccounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text
                );

            this.dataGridView1.Refresh();
            foreach (Control t in this.Controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    t.Text = String.Empty;
                }
            }
        }
    }
}
