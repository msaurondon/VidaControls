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
    public partial class VidaMonthAssignement : UserControl
    {
        private string _assignedMonth;

        public VidaMonthAssignement()
        {
            InitializeComponent();
            controlSetup();
        }

        private string _AssignmentMonth { set { _assignedMonth = value; } }
        public string AssignmentMonth { get { return _assignedMonth; } }


        private void controlSetup()
        {
            DateTime dt = DateTime.Now;
            comboBox1.Items.Add(dt.ToString("MMMM") + " " + dt.ToString("yyyy"));
            for (int i = 0; i < 12; i++)
            {
                dt = dt.AddMonths(1);
                comboBox1.Items.Add(dt.ToString("MMMM") + " " + dt.ToString("yyyy"));
            }
        }

        public event EventHandler VidaMonthAssignment_SelectedIndexChanged;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _AssignmentMonth = comboBox1.SelectedItem.ToString();
            this.VidaMonthAssignment_SelectedIndexChanged(sender, e);
        }
    }
}
