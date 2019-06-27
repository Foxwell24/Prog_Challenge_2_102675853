using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Food : Item
    {
        public int GrossWeight;

        public Food(string n, float p, int gw)
        {
            Name = n;
            Price = p;
            GrossWeight = gw;
        }

        public void Eat()
        {
            GrossWeight = 0;
        }
    }

    public class Perishable : Food
    {
        public int ExpiryMonth;
        public int ExpiryYear;

        public Perishable(string n, float p, int gw, int em, int ey) : base(n, p, gw)
        {
            ExpiryMonth = em;
            ExpiryYear = ey;
        }
    }

    public class NonPerishable : Food
    {
        public int NetWeight;

        public NonPerishable(string n, float p, int gw, int nw) : base(n, p, gw)
        {
            NetWeight = nw;
        }
    }
}
