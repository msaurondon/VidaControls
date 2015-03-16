using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaControls
{
    public class Register
    {
        public DateTime Date { get; set; }
        public bool CLR { get; set; }
        public string Payee { get; set; }
        public string Memo { get; set; }
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public decimal Deposit { get; set; }
        public decimal Withdraw { get; set; }
        public decimal Balance { get; set; }
    }
}
