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
    public partial class VidaRegister : UserControl
    {
        List<Register> register = new List<Register>();

        public VidaRegister()
        {
            InitializeComponent();
        }

        private void buildRegister()
        {
            register.Add(new Register() {Date = Convert.ToDateTime("2015/03/03"), CLR = false, Payee = "USAA Platinum", Memo="", Withdraw = 800});
            register.Add(new Register() { Date = Convert.ToDateTime("2015/03/03"), CLR = false, Payee = "Milpay", Memo = "", Deposit = Convert.ToDecimal(851.23) });
            register.Add(new Register() { Date = Convert.ToDateTime("2015/02/10"), CLR = true, Payee = "", Memo = "", Withdraw = Convert.ToDecimal(2.99)});
            register.Add(new Register() { Date = Convert.ToDateTime("2015/01/23"), CLR = true, Payee = "Milpay", Memo = "", Deposit = Convert.ToDecimal(587.53) });            
        }
    }
}
