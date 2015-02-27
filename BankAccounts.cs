using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace VidaControls
{
    public partial class BankAccounts: UserControl
    {
        List<VidaAccounts> vidaAccounts = new List<VidaAccounts>();

        public BankAccounts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ADD BUTTON
            VidaAccounts vidaAccount = new VidaAccounts();

            //add to grid
            this.dataGridView1.Rows.Add(comboBox1.SelectedItem.ToString(),
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text);

            this.dataGridView1.Refresh();
           
            //add to vidaAccounts
            vidaAccount.AccountTypeID = comboBox1.SelectedItem.ToString() == "Checking" ? 1 : 2; // Checking = 1, Savings = 2
            vidaAccount.Institution = textBox1.Text;
            vidaAccount.AccountNumber = textBox2.Text;
            vidaAccount.RoutingNumber = Convert.ToInt32(textBox3.Text);
            vidaAccount.Balance = Convert.ToDecimal(textBox4.Text);
            vidaAccount.AccountNickName = textBox5.Text;


            vidaAccounts.Add(vidaAccount);

            // reset for new selection;
            comboBox1.SelectedIndex = -1;
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
            this.DoneAndSave_Clicked(sender, e);
            //DONE button
            //Raise Event for external awareness to fetch the GetFilledVidaAccountList
            
        }

        public string GetFilledVidaAccountList()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(vidaAccounts.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, vidaAccounts);

            string json = Encoding.Default.GetString(stream.ToArray());

            return json;
        }
    }
}
