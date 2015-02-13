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
    public partial class MonthlyBudget : UserControl
    {
        public MonthlyBudget()
        {
            InitializeComponent();
            controlSetup();
        }

        private void controlSetup()
        {
            DateTime dt = DateTime.Now;
            comboBox1.Items.Add(dt.ToString("MMMM") + " " + dt.ToString("yyyy"));
            for (int i = 0; i < 12; i++)
            {
                dt = dt.AddMonths(1);
                comboBox1.Items.Add(dt.ToString("MMMM") + " " + dt.ToString("yyyy"));
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count-1)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
            }
        }
    }
}
