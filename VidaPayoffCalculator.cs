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
    public partial class VidaPayoffCalculator : UserControl
    {
        DateTime originalPayoff;
        DateTime adjustedPayoff;

        public VidaPayoffCalculator()
        {
            InitializeComponent();
            this.chart2.ChartAreas[0].AxisX.Title = "Months";
            this.chart2.ChartAreas[0].AxisY.Title = "Owed";
            this.chart2.ChartAreas[0].AxisX.Minimum = 0;
            this.chart2.ChartAreas[0].AxisY.Minimum = 0;
            this.chart2.ChartAreas[0].AxisX.Interval = 3;
            textBox1.Focus();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            decimal apr;
            decimal mpr;
            string originalText = textBox1.Text.TrimEnd('%', ' ');
            try
            {
                int curPos = textBox1.SelectionStart;
                apr = Convert.ToDecimal(originalText);
                apr = apr / 100;
                mpr = ((apr / 12) * 100);
                textBox2.Text = Convert.ToString(Math.Round(mpr, 3)) + " %";
                textBox1.Text = originalText + " %";
                textBox1.SelectionStart = curPos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nope");
            }
        }

        private int checkTextBoxes()
        {
            int calculate = 0;

            string tb1 = textBox1.Text.TrimEnd('%', ' ');
            string tb3 = textBox3.Text.TrimStart('$', ' ');
            string tb4 = textBox4.Text.TrimStart('$', ' ');

            if (tb1.Length > 0 && tb3.Length > 0 && tb4.Length > 0)
            {
                calculate = 1;
            }

            return calculate;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int curPos = textBox3.SelectionStart;
            string balance = textBox3.Text;
            balance = balance.TrimStart('$', ' ');
            balance = "$ " + balance;
            textBox3.Text = balance;
            textBox3.SelectionStart = curPos + 2;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int curPos = textBox4.SelectionStart;
            string balance = textBox4.Text;
            balance = balance.TrimStart('$', ' ');
            balance = "$ " + balance;
            textBox4.Text = balance;
            textBox4.SelectionStart = curPos + 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Calculate")
            {
                int calculate = checkTextBoxes();
                if (calculate == 1)
                {
                    originalPayoff = calculatePayoff();
                }
                else
                {
                    MessageBox.Show("Nope");
                }
            }
            if (button1.Text == "ReCalculate")
            {
                adjustedPayoff = recalculatePayoff();
            }
            buildChart();
        }

        private DateTime recalculatePayoff()
        {

            DateTime month = new DateTime(
       Convert.ToInt32(DateTime.Now.Year.ToString())
       , Convert.ToInt32(DateTime.Now.Month.ToString())
       , 1);
            decimal balance = Convert.ToDecimal(textBox3.Text.TrimStart('$', ' '));
            decimal mpr = Convert.ToDecimal(textBox2.Text.TrimEnd('%', ' '));
            decimal payment = Convert.ToDecimal(textBox4.Text.TrimStart('$', ' '));
            decimal totalpayment;
            decimal xtra;
            decimal interest;
            decimal balanceAfterInterest;
            decimal balanceAfterPayment;
            int monthInt = 0;
            this.chart2.Series["Adjusted"].Points.Clear();
            DataGridView dgv1 = new DataGridView();
            DataGridViewRow row;

            foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
            {
                dgv1.Columns.Add(dgvc.Clone() as DataGridViewColumn);
            }
            this.chart2.Series["Adjusted"].Points.AddXY(monthInt, balance);
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {

                if (!dgvRow.IsNewRow)
                {

                    interest = balance * (mpr / 100);
                    balanceAfterInterest = balance + interest;
                    if (!String.IsNullOrWhiteSpace(dgvRow.Cells["colXtra"].Value.ToString())
                        || !String.IsNullOrEmpty(dgvRow.Cells["colXtra"].Value.ToString()))
                    {
                        xtra = Convert.ToDecimal(dgvRow.Cells["colXtra"].Value.ToString());
                    }
                    else
                    {
                        xtra = new decimal();
                    }

                    totalpayment = payment;

                    if (balanceAfterInterest < payment)
                    {
                        totalpayment = balanceAfterInterest;
                    }
                    else
                    {
                        totalpayment = payment + xtra;
                    }

                    balanceAfterPayment = balanceAfterInterest - totalpayment;

                    if (Math.Round(balance, 0) > 0)
                    {
                        dgv1.Rows.Add(month.ToString("MMM/yyyy")
                            , Math.Round(balance, 2)
                            , Math.Round(interest, 2)
                            , Math.Round(balanceAfterInterest, 2)
                            , Math.Round(totalpayment, 2)
                            , Math.Round(balanceAfterPayment, 2)
                            , Math.Round(xtra, 2));

                        balance = balanceAfterPayment;
                        month = month.AddMonths(1);
                        monthInt++;
                        this.chart2.Series["Adjusted"].Points.AddXY(monthInt, balance);
                    }
                }
            }


            dataGridView1.Rows.Clear();
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                row = (DataGridViewRow)dgv1.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dgv1.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                if (i <= dgv1.Rows.Count - 2)
                {
                    dataGridView1.Rows.Add(row);
                }
            }
            dataGridView1.Refresh();
            month = month.AddMonths(-1);
            label5.Text = "Estimated Payoff:" + month.ToString("MMM/yyyy");

            return month;
        }

        private DateTime calculatePayoff()
        {
            decimal mpr = Convert.ToDecimal(textBox2.Text.TrimEnd('%', ' '));
            decimal balance = Convert.ToDecimal(textBox3.Text.TrimStart('$', ' '));
            decimal payment = Convert.ToDecimal(textBox4.Text.TrimStart('$', ' '));
            decimal interest = 0;
            decimal balanceAfterInterest = 0;
            decimal balanceAfterPayment = 0;
            int monthInt = 0;
            DateTime month = new DateTime(
                Convert.ToInt32(DateTime.Now.Year.ToString())
                , Convert.ToInt32(DateTime.Now.Month.ToString())
                , 1);
            this.chart2.Series["Original"].Points.AddXY(monthInt, balance);
            do
            {
                interest = balance * (mpr / 100);
                balanceAfterInterest = balance + interest;

                if (balanceAfterInterest < payment)
                {
                    payment = balanceAfterInterest;
                }

                balanceAfterPayment = balanceAfterInterest - payment;
                this.dataGridView1.Rows.Add(month.ToString("MMM/yyyy"), Math.Round(balance, 2)
                    , Math.Round(interest, 2)
                    , Math.Round(balanceAfterInterest, 2)
                    , Math.Round(payment, 2)
                    , Math.Round(balanceAfterPayment, 2)
                    , "");
                balance = balanceAfterPayment;

                month = month.AddMonths(1);
                monthInt++;
                this.chart2.Series["Original"].Points.AddXY(monthInt, balance);
            } while (balance != 0);

            this.dataGridView1.Refresh();
            label5.Text = "Estimated Payoff:" + month.ToString("MMM/yyyy");

            return month;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // accidental click added this function.
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colXtra")
            {
                button1.Text = "ReCalculate";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Control tb in this.Controls)
            {
                if (tb is TextBox)
                {
                    tb.Text = String.Empty;
                }
            }
            this.chart1.Series["Original"].Points.Clear();
            this.chart1.Series["Adjusted"].Points.Clear();
            this.chart2.Series["Original"].Points.Clear();
            this.chart2.Series["Adjusted"].Points.Clear();
            button1.Text = "Calculate";
            label5.Text = "Estimated Payoff:";
            label6.Text = "";
        }

        private void buildChart()
        {
            this.chart1.Series["Original"].Points.Clear();
            this.chart1.Series["Adjusted"].Points.Clear();

            int originalMonths = ((originalPayoff.Year - DateTime.Now.Year) * 12) + originalPayoff.Month - DateTime.Now.Month;
            this.chart1.Series["Original"].Points.Add(originalMonths);

            if (button1.Text == "ReCalculate")
            {
                int adjustedMonths = ((adjustedPayoff.Year - DateTime.Now.Year) * 12) + adjustedPayoff.Month - DateTime.Now.Month;
                this.chart1.Series["Adjusted"].Points.Add(adjustedMonths);
                label6.Text = string.Format("Estimate original payoff in {0} months. Adjusted payoff in {1} months.", originalMonths, adjustedMonths);
            }
            else
            {
                label6.Text = string.Format("Estimate payoff in {0} months.", originalMonths);
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.chart2.Show();
                this.chart1.Hide();
            }
            else
            {
                this.chart2.Hide();
                this.chart1.Show();
            }
        }
    }
}
