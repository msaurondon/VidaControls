using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace VidaControls
{
    [DataContract]
    public class VidaAccounts
    {
        [DataMember]
        public int AccountID { get; set; }
        [DataMember]
        public string AccountType { get; set; }
        [DataMember]
        public int AccountTypeID { get; set; }
        [DataMember]
        public string Institution { get; set; }
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public int RoutingNumber { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public string AccountNickName { get; set; }
        [DataMember]
        public decimal Limit { get; set; }
        [DataMember]
        public decimal APR { get; set; }
        [DataMember]
        public decimal MinimumPayment { get; set; }
        [DataMember]
        public decimal MaximumPayment { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
    }
}
