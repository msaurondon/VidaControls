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
    public partial class VidaCompletePayoff : UserControl
    {
        List<Loans> loans = new List<Loans>();
        List<Loans> snowLoans = new List<Loans>();

        public VidaCompletePayoff()
        {
            InitializeComponent();
            setup();
            calculatePayoff();
            calculateSnowBall();
            setupChart();
        }

        private void setup()
        {
            // nickname, apr, mpr, balance, payment
            loans.Add(new Loans() { nickname = "Mortgage", apr = 8, balance = 37165.45, payment = 550 });
            loans.Add(new Loans() { nickname = "USAA Starter", apr = 2.99, balance = 6603.57, payment = 450 });
            loans.Add(new Loans() { nickname = "USAA Motorad", apr = 7.49, balance = 3235.51, payment = 200.26 });
            loans.Add(new Loans() { nickname = "USAA Platnium", apr = 7.75, balance = 3387.79, payment = 60 });
            loans.Add(new Loans() { nickname = "Honda Ruby", apr = 7.75, balance = 3299.79, payment = 123.46 });
            loans.Add(new Loans() { nickname = "Honda Rebel", apr = 7.75, balance = 3582.78, payment = 126.19 });
            loans.Add(new Loans() { nickname = "Insight", apr = 5.19, balance = 13610.4, payment = 500 });
            loans.Add(new Loans() { nickname = "Freedom Road", apr = 7.99, balance = 2533.19, payment = 176 });
            loans.Add(new Loans() { nickname = "Mil Star", apr = 10.24, balance = 6345.43, payment = 184 });

        }
        private void calculatePayoff()
        {
            foreach (Loans l in loans)
            {
                decimal mpr = Convert.ToDecimal(l.apr / 12);
                decimal balance = Convert.ToDecimal(l.balance);
                decimal payment = Convert.ToDecimal(l.payment);
                decimal interest = 0;
                decimal balanceAfterInterest = 0;
                decimal balanceAfterPayment = 0;
                int month = 1;

                do
                {
                    interest = balance * (mpr / 100);
                    balanceAfterInterest = balance + interest;

                    if (balanceAfterInterest < payment)
                    {
                        payment = balanceAfterInterest;
                    }

                    balanceAfterPayment = balanceAfterInterest - payment;
                    balance = balanceAfterPayment;


                    month++;
                } while (balance != 0);

                l.months = month - 1;
            }
        }

        public void setupChart()
        {
            var sortedLoans = loans.OrderBy(f => f.months);

            this.chart1.Series.Clear();
            this.chart2.Series.Clear();

            foreach (Loans l in sortedLoans)
            {
                this.chart1.Series.Add(l.nickname);
                this.chart1.Series[l.nickname].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                this.chart1.Series[l.nickname].Points.Add(l.months);
                this.chart1.Series[l.nickname].Label = l.months.ToString() + " mos"; //" mos @ $" + l.payment.ToString()
                this.chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            }

            foreach (Loans l in snowLoans)
            {
                this.chart2.Series.Add(l.nickname);
                this.chart2.Series[l.nickname].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                this.chart2.Series[l.nickname].Points.Add(l.months);
                this.chart2.Series[l.nickname].Label = l.months.ToString() + " mos"; // " mos @ $" + l.payment.ToString()
                this.chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            }
        }

        public void calculateSnowBall()
        {
            var sortedLoans = loans.OrderBy(f => f.months);
            decimal rollingPayment = 0;
            int snowMonthStart = 0;

            foreach (Loans l in sortedLoans)
            {
                decimal mpr = Convert.ToDecimal(l.apr / 12);
                decimal balance = Convert.ToDecimal(l.balance);
                rollingPayment += Convert.ToDecimal(l.payment);
                decimal payment = Convert.ToDecimal(l.payment);
                decimal interest = 0;
                decimal balanceAfterInterest = 0;
                decimal balanceAfterPayment = 0;
                int month = 1;


                do
                {
                    interest = balance * (mpr / 100);
                    balanceAfterInterest = balance + interest;
                    if (month > snowMonthStart)
                    {
                        payment = rollingPayment;
                    }

                    if (balanceAfterInterest < payment)
                    {
                        payment = balanceAfterInterest;
                    }

                    balanceAfterPayment = balanceAfterInterest - payment;
                    balance = balanceAfterPayment;

                    month++;
                } while (balance != 0);
                decimal total = (snowMonthStart * Convert.ToDecimal(l.payment)) + ((month - snowMonthStart) * rollingPayment);
                textBox1.Text += string.Format("{0}: {1} months at {2}, {3} months at {4} = ${5}\r\n", l.nickname, snowMonthStart == 0 ? month.ToString() : snowMonthStart.ToString(), l.payment.ToString(), (month - snowMonthStart).ToString(), rollingPayment.ToString(), total.ToString());
                snowLoans.Add(new Loans { nickname = l.nickname, apr = l.apr, mpr = Convert.ToDouble(mpr), months = month - 1, payment = Convert.ToDouble(rollingPayment) });
                snowMonthStart = month - 1;
            }
        }
    }
}
