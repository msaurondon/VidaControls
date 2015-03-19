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
    public partial class CreditCards : UserControl
    {

        List<VidaAccounts> vidaAccounts = new List<VidaAccounts>();

        public CreditCards()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VidaAccounts vidaAccount = new VidaAccounts();

            this.dataGridView1.Rows.Add(
                textBox1.Text,
            textBox2.Text,
            textBox3.Text,
            textBox4.Text,
            textBox5.Text,
            textBox6.Text,
            textBox7.Text,
            textBox8.Text
                );

            this.dataGridView1.Refresh();

            // add to vidaAccounts

            vidaAccount.Institution = textBox1.Text;
            vidaAccount.AccountNumber = textBox2.Text;
            vidaAccount.Limit = Convert.ToDecimal(textBox3.Text);
            vidaAccount.Balance = Convert.ToDecimal(textBox4.Text);
            vidaAccount.APR = Convert.ToDecimal(textBox5.Text);
            vidaAccount.MinimumPayment = Convert.ToDecimal(textBox6.Text);
            vidaAccount.DueDate = Convert.ToDateTime(textBox7.Text);
            vidaAccount.AccountNickName = textBox8.Text;

            vidaAccounts.Add(vidaAccount);

            foreach (Control t in this.Controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    t.Text = String.Empty;
                }
            }
        }

        public event EventHandler DoneAndSave_Clicked;

        private void button2_Click(object sender, EventArgs e)
        {
            DoneAndSave_Clicked(sender, e);
        }

        public string GetFilledVidaAccountList()
        {
            JSonHelper helper = new JSonHelper();
            string json = helper.ConvertObjectToJSon(vidaAccounts);
            return json;
        }

        public void SetFilledVidaAccountList(string incoming)
        {
            JSonHelper helper = new JSonHelper();
            List<VidaAccounts> vidaAccounts = helper.ConvertJSonToObject<List<VidaAccounts>>(incoming);

            if (vidaAccounts.Count > 0)
            {
                foreach (VidaAccounts va in vidaAccounts)
                {
                    this.dataGridView1.Rows.Add(va.Institution,
                        va.AccountNumber,
                        va.Limit,
                        va.Balance,
                        va.APR,
                        va.MinimumPayment,
                        va.DueDate,
                        va.AccountNickName);
                }
            }
            this.dataGridView1.Refresh();
        }
    }
}
