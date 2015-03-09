using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaControls
{
    public class Register
    {
        DateTime Date { get; set; }
        bool CLR { get; set; }
        string Payee { get; set; }
        string Memo { get; set; }
        List<string> Categories { get; set; }
        string SelectedCategory { get; set; }
        decimal Deposit { get; set; }
        decimal Withdraw { get; set; }
        decimal Balance { get; set; }
    }
}
