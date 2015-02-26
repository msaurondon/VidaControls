using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaControls
{
    public class VidaAccounts
    {
        public int AccountID { get; set; }
        public int AccountTypeID { get; set; }
        public string Institution { get; set; }
        public int AccountNumber { get; set; }
        public int RoutingNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountNickName { get; set; }
        public decimal Limit { get; set; }
        public decimal APR { get; set; }
        public decimal MinimumPayment { get; set; }
        public decimal MaximumPayment { get; set; }
        public DateTime DueDate { get; set; }

    }
}
