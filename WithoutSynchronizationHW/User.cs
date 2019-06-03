using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutSynchronizationHW
{
    public class User
    {
        private object lockObject = new object();
        public string FullName { get; set; }
        public Money BankAccountInUsd { get; set; }

        public void BankAccountChange(double changeInUsd)
        {
            //lock (lockObject)
            //{
              BankAccountInUsd.Column += changeInUsd;
            //}
        }
    }
}
