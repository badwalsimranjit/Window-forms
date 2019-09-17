using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class bank
    {
        public decimal bal;
        public decimal balance
        {
            get
            {
                return bal;
            }
            set
            {
                bal = value;
            }
        }
        public int acc=100;
        public int account
        {
            get
            {
                //acc++;
                return acc;
            }
            set
            {
                acc = value;
            }
        }
        public static int acc1=100;
        public bank()
        {
            acc1++;
            acc = acc1;
        }
    }
}


