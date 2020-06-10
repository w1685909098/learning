using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
   public  class HelpMoneyChangedAttribute:Attribute
    {
        public HelpMoneyChangedAttribute(int amount)
        {
            _amount = amount;
        }
        private int _amount;
        public string Message { get; set; }
        public void Gain()
        {
            Console.WriteLine(_amount);
        }
    }
}
