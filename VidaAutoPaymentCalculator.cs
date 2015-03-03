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
    public partial class VidaAutoPaymentCalculator : UserControl
    {
        public VidaAutoPaymentCalculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double monthlyPayment = Calculate();
            label8.Text = string.Format("An estimated monthly payment of $ {0}", monthlyPayment.ToString());
        }

        private double Calculate()
        {
            decimal price;
            decimal trade;
            decimal taxes;
            decimal fees;
            decimal downpayment;
            int months;
            decimal APR;
            double MPR;
            double powerMonths;
            decimal priceAfterTrade;
            decimal salesTax;
            decimal priceWithTaxes;
            decimal priceAfterFees;
            decimal priceAfterDownpayment;
            double monthlyPayment;
            
            price = Convert.ToDecimal(textBox1.Text);
            trade = Convert.ToDecimal(textBox2.Text);
            taxes = Convert.ToDecimal(textBox3.Text) / 100;
            fees = Convert.ToDecimal(textBox4.Text);
            downpayment = Convert.ToDecimal(textBox5.Text);
            months = Convert.ToInt32(textBox6.Text);
            APR = Convert.ToDecimal(textBox7.Text) / 100;
            MPR = Convert.ToDouble(APR)/12;
            powerMonths = Convert.ToDouble(months);

            priceAfterTrade = price - trade;
            salesTax = priceAfterTrade * taxes;
            priceWithTaxes = priceAfterTrade + salesTax;
            priceAfterFees = priceWithTaxes + fees;
            priceAfterDownpayment = priceAfterFees - downpayment;


            monthlyPayment = (Convert.ToDouble(priceAfterDownpayment) * MPR) / (1 - Math.Pow((1 + MPR),(months*-1)));

            return Math.Round(monthlyPayment, 2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            foreach (Control tb in this.Controls)
            {
                if (tb is TextBox)
                {
                    tb.Text = "0";
                }
            }
        }
    }
}
