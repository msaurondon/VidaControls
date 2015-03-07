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
    public partial class VidaAutoEstimator : UserControl
    {
        int calculcateCustom = 0;
        public VidaAutoEstimator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculcateCustom = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            this.dataGridView1.Rows.Clear();
            if (textBox11.Text.Length == 0) { MessageBox.Show("Need a desired payment"); }
            else if (textBox12.ReadOnly == false) { calculcateCustom = 1; CalculateAmount(); }
            else { CalculateAmount(); }
        }

        private void CalculateAmount()
        {
            decimal payment = GetPayment();
            decimal interest;
            decimal totalInterest = 0;
            decimal principal;
            decimal totalPrincipal= 0;
            decimal taxes = 0 ;
            decimal tradeValue = GetTrade();
            decimal downPayment = GetDownpayment();
            decimal __36 = 0;
            decimal __48 = 0;
            decimal __60 = 0;
            decimal __72 = 0;
            decimal balance = 0;
            decimal yearCount = 0;
            decimal taxRate = GetTaxes();
            
            if (payment > 0) 
            for (int APR = 15; APR >= 0; APR--)
            {
                decimal _apr = Convert.ToDecimal(APR) / 100;
                decimal _mpr = _apr / 12;
                if (taxRate != 0) { taxes = payment * (taxRate/100); }
                for (int i = 1; i <= 72; i++)
                {
                    balance += payment;
                    interest = balance * _mpr;
                    principal = payment - interest;
                    totalInterest += interest;
                    totalPrincipal += principal;
                    yearCount = (decimal)i / 12;
                    if (yearCount == Convert.ToDecimal(3)) { __36 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }
                    if (yearCount == Convert.ToDecimal(4)) { __48 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }
                    if (yearCount == Convert.ToDecimal(5)) { __60 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }
                    if (yearCount == Convert.ToDecimal(6)) { __72 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }

                }

                this.dataGridView1.Rows.Add(
                    string.Format("{0}%", APR),
                    string.Format("$ {0}", Math.Round(__36,2)),
                    string.Format("$ {0}", Math.Round(__48,2)),
                    string.Format("$ {0}", Math.Round(__60,2)),
                    string.Format("$ {0}", Math.Round(__72, 2))
                    );

                totalInterest = 0;
                totalPrincipal = 0;
                balance = 0;
                yearCount = 0;
            }

            if (calculcateCustom == 1)
            {

                decimal CustomAPR = GetAPR();
                decimal _apr = Convert.ToDecimal(CustomAPR) / 100;
                decimal _mpr = _apr / 12;
                if (taxRate != 0) { taxes = payment * (taxRate / 100); }

                for (int i = 1; i <= 72; i++)
                {
                    balance += payment;
                    interest = balance * _mpr;
                    principal = payment - interest;
                    totalInterest += interest;
                    totalPrincipal += principal;
                    yearCount = (decimal)i / 12;
                    if (yearCount == Convert.ToDecimal(3)) { __36 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }
                    if (yearCount == Convert.ToDecimal(4)) { __48 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }
                    if (yearCount == Convert.ToDecimal(5)) { __60 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }
                    if (yearCount == Convert.ToDecimal(6)) { __72 = ((totalPrincipal - (taxes * i)) + (tradeValue + downPayment)); }

                }

                textBox1.Text = string.Format("{0}%", CustomAPR);
                textBox2.Text = string.Format("$ {0}", Math.Round(__36,2));
                textBox3.Text = string.Format("$ {0}", Math.Round(__48,2));
                textBox4.Text = string.Format("$ {0}", Math.Round(__60,2));
                textBox5.Text = string.Format("$ {0}", Math.Round(__72,2));
            }

            this.dataGridView1.Refresh();
        }

        private decimal GetAPR()
        {
            decimal APR = 0;
            if (textBox12.Text.Length > 0)
            {
                string downPaymentStr = textBox12.Text;
                try
                {
                    APR = Convert.ToDecimal(downPaymentStr);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Custom APR must be a decimal value");
                    APR = 0;
                }

            }
            return APR;
        }

        private decimal GetDownpayment()
        {
            decimal downPayment = 0;
            if (textBox14.Text.Length > 0)
            {
                string downPaymentStr = textBox14.Text;
                try
                {
                    downPayment = Convert.ToDecimal(downPaymentStr);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Down payment must be a decimal value");
                    downPayment = 0;
                }

            }
            return downPayment;
        }

        private decimal GetTrade()
        {
            decimal tradeValue = 0;
            if (textBox13.Text.Length > 0)
            {
                string tradeValueStr = textBox13.Text;
                try
                {
                    tradeValue = Convert.ToDecimal(tradeValueStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trade Value must be a decimal value");
                    tradeValue = 0;
                }
            }
            return tradeValue;
        }

        private decimal GetPayment()
        {
            decimal payment = 0;
            if (textBox11.Text.Length > 0)
            {
                string paymentStr = textBox11.Text;
                try
                {
                    payment = Convert.ToDecimal(paymentStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Payment must be a decimal value");
                    payment = 0;
                }
            }

            return payment;
        }

        private decimal GetTaxes()
        {
            decimal taxes = 0;
            if (textBox15.Text.Length > 0)
            {
                string taxesStr = textBox15.Text;
                try
                {
                    taxes = Convert.ToDecimal(taxesStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Illegal number in taxes");
                    taxes = 0;
                }
            }
            return taxes;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox12.ReadOnly = false;
            }
            else
            {
                textBox12.ReadOnly = true;
                textBox12.Text = "";
            }
        }

    }
}
