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
    public partial class VidaCategories : UserControl
    {
        List<Categories> parentCategories = new List<Categories>();
        List<Categories> childCategories = new List<Categories>();
        List<Categories> expenseCategories = new List<Categories>();

        public VidaCategories()
        {
            InitializeComponent();
        }

        public event EventHandler AddParentCategory_Clicked;
        public event EventHandler AddChildCategory_Clicked;
        public event EventHandler AddExpenseCategory_Clicked;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && listBox1.Items.Contains(textBox1.Text) == false)
            {
                Categories parent = new Categories();
                parent.Category = textBox1.Text;
                parentCategories.Add(parent);
                listBox1.Items.Add(textBox1.Text);
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                this.AddParentCategory_Clicked(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0 && listBox2.Items.Contains(textBox2.Text) == false)
            {
                Categories child = new Categories();
                child.Category = textBox2.Text;
                childCategories.Add(child);
                listBox2.Items.Add(textBox2.Text);
                comboBox2.Items.Add(textBox2.Text);
                textBox2.Text = "";
                this.AddChildCategory_Clicked(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string expenseStr = comboBox1.SelectedItem.ToString() + ":" + comboBox2.SelectedItem.ToString();

            if (comboBox1.SelectedItem.ToString().Length > 0 && comboBox2.SelectedItem.ToString().Length > 0 && listBox3.Items.Contains(expenseStr)==false)
            {
                Categories expense = new Categories();    
                listBox3.Items.Add(expenseStr);
                expense.Category = expenseStr;
                expenseCategories.Add(expense);
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                this.AddExpenseCategory_Clicked(sender, e);
            }
        }

        public string GetNewParentCategory()
        {
            JSonHelper helper = new JSonHelper();
            string json = helper.ConvertObjectToJSon(parentCategories);

            return json;
        }

        public string GetNewChildCategory()
        {
            JSonHelper helper = new JSonHelper();
            string json = helper.ConvertObjectToJSon(childCategories);

            return json;
        }

        public string GetNewExpenseCategory()
        {
            JSonHelper helper = new JSonHelper();
            string json = helper.ConvertObjectToJSon(expenseCategories);

            return json;
        }

        public void SetParentCategories(string incoming)
        {
            JSonHelper helper = new JSonHelper();
            List<Categories> ca = helper.ConvertJSonToObject<List<Categories>>(incoming);
            foreach (Categories c in ca)
            {
                listBox1.Items.Add(c.Category);
                comboBox1.Items.Add(c.Category);
            }

            listBox1.Refresh();
        }

        public void SetChildCategories(string incoming)
        {
            JSonHelper helper = new JSonHelper();
            List<Categories> ca = helper.ConvertJSonToObject<List<Categories>>(incoming);
            foreach (Categories c in ca)
            {
                listBox2.Items.Add(c.Category);
                comboBox2.Items.Add(c.Category);
            }

            listBox1.Refresh();        
        }

        public void SetExpenseCategories(string incoming)
        {
            JSonHelper helper = new JSonHelper();
            List<Categories> ca = helper.ConvertJSonToObject<List<Categories>>(incoming);
            foreach (Categories c in ca)
            {
                listBox3.Items.Add(c.Category);
            }

            listBox1.Refresh();            
        }
    }
}
