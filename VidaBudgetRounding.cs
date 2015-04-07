using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaControls
{
    public class VidaBudgetRounding
    {
        public decimal Deposit(decimal amount)
        {
            decimal returnAmount;

            if (amount > Convert.ToDecimal(100))
            {
                returnAmount = Math.Floor(amount / 10) * 10;
            }
            else if (amount < Convert.ToDecimal(100) && amount > Convert.ToDecimal(10))
            {
                returnAmount = Math.Floor(amount / 5) * 5;
            }
            else
            {
                returnAmount = Math.Floor(amount / 1) * 1;
            }
            return returnAmount;
        }

        public decimal Withdraw(decimal amount)
        {
            decimal returnAmount;
            if (amount > Convert.ToDecimal(100))
            {
                returnAmount = Math.Ceiling(amount / 10) * 10;
            }
            else if (amount < Convert.ToDecimal(100) && amount > Convert.ToDecimal(10))
            {
                returnAmount = Math.Ceiling(amount / 5) * 5;
            }
            else
            {
                returnAmount = Math.Ceiling(amount / 1) * 1;
            }
            return returnAmount;
        }
    }
}
