using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Clothing : Item
    {
        public String Size;
        public bool Used;
        protected Clothing(string name, float price, string size, bool used)
        {
            this.Name = name;
            this.Price = price;
            this.Size = size;
            this.Used = used;
        }
        public void Wear()
        {
            Used = true;
        }
    }

    //------- These two are part of the optional task ---------//
    public class Safty : Clothing
    {
        public string Rating;
        
        public Safty(string name, float price, string size, bool used, string rating) : base(name, price, size, false)
        {
            this.Rating = rating;
        }
    }

    public class Casual : Clothing
    {
        public string Style;
        public Casual(string name, float price, string size, bool used, string style) : base(name, price, size, false)
        {
            this.Style = style;
        }
    }
}
