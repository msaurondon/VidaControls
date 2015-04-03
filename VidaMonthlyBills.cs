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
    public partial class VidaMonthlyBills : UserControl
    {
        private List<Categories> categories { get; set; }
        private List<VidaAccounts> vidaAccounts = new List<VidaAccounts>();

        public VidaMonthlyBills()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            VidaAccounts vidaAccount = new VidaAccounts();
            vidaAccount.Institution = textBox1.Text;
            vidaAccount.Balance = Convert.ToDecimal(textBox2.Text);
            try
            {
                vidaAccount.Category = comboBox1.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                vidaAccount.Category = ":";
            }
            vidaAccount.DueDate = Convert.ToDateTime(textBox3.Text);
            this.dataGridView1.Rows.Add(
                vidaAccount.Institution.ToString(),
                vidaAccount.Balance.ToString(),
                vidaAccount.Category.ToString(),
                vidaAccount.DueDate.ToString()
                );

            vidaAccounts.Add(vidaAccount);

            this.dataGridView1.Refresh();
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
        }

        public string GetFilledVidaAccountList()
        {
            string json;
            JSonHelper helper = new JSonHelper();
            json = helper.ConvertObjectToJSon(vidaAccounts);

            return json;
        }

        public void LoadCategories(string json)
        {
            List<Categories> ca = new List<Categories>();
            JSonHelper helper = new JSonHelper();
            ca = helper.ConvertJSonToObject<List<Categories>>(json);

            foreach (Categories c in ca)
            {
                this.comboBox1.Items.Add(c.Category);
            }

        }
    }
}
