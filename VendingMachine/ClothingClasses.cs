using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    //----------------------------------------------------------//
    // Use the Food classes as an example to complete Clothing,
    // Safety and Casual.  Hint:  Think about inheritence
    //----------------------------------------------------------//
    public class Clothing : Item
    {
        public string Size;
        public bool Used;
        public Clothing(string Name, float Price, string Size, bool Used)
        {
            this.Name = Name;
            this.Price = Price;
            this.Size = Size;
            this.Used = Used;
        }
        public void Wear()
        {
            Used = true;
        }
    }

    //------- These two are part of the optional task ---------//
    public class Safety : Clothing
    {
        public string Rating;
        public Safety(string Name, float Price, string Size, bool Used, string Rating) : base(Name, Price, Size, Used)
        {
            this.Rating = Rating;
        }
    }

    public class Casual : Clothing
    {
        public string Style;
        public Casual(string Name, float Price, string Size, bool Used, string Style) : base(Name, Price, Size, Used)
        {
            this.Style = Style;
        }
    }
    //----------------------------------------------------------//

}
