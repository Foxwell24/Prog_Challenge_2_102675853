using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    class Program {

        static List<Item> items = new List<Item>();
        static void Main(string[] args) {
            float budget = getBudget();
            string input = "";

            while(input.ToLower() != "e") {
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Would you like to: ");
                Console.WriteLine("(A)dd and item");
                Console.WriteLine("(C)heck budget");
                Console.WriteLine("(E)xit");
                Console.Write("Enter selection: ");

                input = Console.ReadLine();

                if(input.ToLower() == "a") {
                    addItem();
                } else if(input.ToLower() == "c") {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine();
                    //------- Add Code to calculate if items exceed the budget ----//
                    float workingBudget = 0;
                    //------- Example below gets everything from items and prints name and price ----/
                    foreach (Item i in items) {
                        Console.WriteLine(i.Name + "  $" + i.Price);
                        workingBudget += i.Price;
                    }
                    // Print message indicating current budget and whether items exceed budget or not
                    workingBudget = budget - workingBudget;
                    if(workingBudget >= 0)
                    {
                        Console.WriteLine("Total budget left is $" + workingBudget);
                    }
                    else
                    {
                        Console.WriteLine("Over budget by $" + -workingBudget);
                    }
                    
                }
            }
        }

        static float getBudget() {
            Console.Write("Please enter budget: $");
            float price = float.Parse(Console.ReadLine());
        
            return price;
        }

        static void addItem() {
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            Console.Write("Enter Item name: ");
            string name = Console.ReadLine();
        
            Console.Write("Enter Item price(float) $: ");
            float price = float.Parse(Console.ReadLine());

            //------------- Edit from this point to implement Clothing --------//
            // Get Item type
            Console.Write("Enter Item type : (F)ood, (C)lothing : ");
            string itemType = Console.ReadLine();
            
            // Get data for food - this may be of use as an example
            if(itemType.ToLower() == "f") {
                Console.Write("(P)erishable or (N)ot? : ");
                string perish = Console.ReadLine();
                if (perish.ToLower() == "p")
                {
                    Console.Write("Enter Gross Weight: ");
                    int grossWeight = int.Parse(Console.ReadLine());
                    Console.Write("Enter Expiery Month(1-12): ");
                    int expireMonth = int.Parse(Console.ReadLine());
                    Console.Write("Enter Expiery Year: ");
                    int expireYear = int.Parse(Console.ReadLine());

                    Perishable newFood = new Perishable(name, price, grossWeight, expireMonth, expireYear);
                    items.Add(newFood);
                }
                else if (perish.ToLower() == "n")
                {
                    Console.Write("Enter Gross Weight(g): ");
                    int grossWeight = int.Parse(Console.ReadLine());
                    Console.Write("Enter Net Weight(g): ");
                    int netWeight = int.Parse(Console.ReadLine());

                    NonPerishable newFood = new NonPerishable(name, price, grossWeight, netWeight);
                    items.Add(newFood);
                }                  
            }
            else if (itemType.ToLower() == "c")
            {
                Console.Write("Enter Size: S, M, L, XL : ");
                string size = Console.ReadLine().ToUpper();                

                Console.Write("(S)afty-Clothing or (C)asual-Clothing : ");
                string type = Console.ReadLine().ToUpper();
                if (type.ToLower() == "s")
                {
                    Console.Write("Enter Rating: L, M, H : ");
                    string rating = Console.ReadLine().ToUpper();

                    Safety newClothing = new Safety(name, price, size, false, rating);
                    items.Add(newClothing);
                }
                else if (type.ToLower() == "c")
                {
                    Console.Write("Enter Style: DayWear, NightWear, SwimWear : ");
                    string style = Console.ReadLine().ToUpper();

                    Safety newClothing = new Safety(name, price, size, false, style);
                    items.Add(newClothing);
                }
            }
            // ---------------------------------------------------------------//
        }        
    }   
}
