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
                    float totalPrice = 0;
                    //------- Example below gets everything from items and prints name and price ----/
                    foreach (Item i in items) {
                        Console.WriteLine(i.Name + "  $" + i.Price);
                        totalPrice += i.Price;
                    }
                    // Print message indicating current budget and whether items exceed budget or not
                    Console.WriteLine();
                    Console.WriteLine("Total price : $"+ totalPrice);
                    float checker = budget - totalPrice;
                    if(checker < 0)
                        Console.WriteLine("Over budget by : $" + -checker);
                    else if (checker >= 0)
                        Console.WriteLine("Budget left : $" + checker);
                }
            }
            

            

        }

        static float getBudget() {
            string input = "";
            float price = -1f;

            Console.Write("Please enter budget: $");
            input = Console.ReadLine();
            price = float.Parse(input);
        
            return price;
        }

        static void addItem() {
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            string input = "";
            string name;
            float price = -1f;
            string itemType = "";

            Console.Write("Enter Item name: ");
            name = Console.ReadLine();
        
            Console.Write("Enter Item price: ");
            input = Console.ReadLine();
            price = float.Parse(input);

            //------------- Edit from this point to implement Clothing --------//
            // Get Item type
            Console.Write("Enter Item type : (F)ood or (C)lothing");
            itemType = Console.ReadLine();
            
            // Get data for food - this may be of use as an example
            if(itemType.ToLower() == "f") {
                int grossWeight = -1;

                Console.Write("Enter Gross Weight: ");
                input = Console.ReadLine();
                grossWeight = int.Parse(input);

                Console.Write("Is Food (P)erishable or (N)ot: ");
                string pOrN = Console.ReadLine();
                // I did not mean for it to be Porn, acedent.... honestly its meant to stand for Perishable Or Not //
                if (pOrN.ToLower() == "p")
                {
                    int elpireY = 1;
                    int elpireM = 1;

                    Console.Write("Enter Expirey Year: ");
                    elpireY = int.Parse(Console.ReadLine());
                    Console.Write("Enter Expirey Month: ");
                    elpireM = int.Parse(Console.ReadLine());

                    Perishable newFood = new Perishable(name, price, grossWeight, elpireM, elpireY);
                    items.Add(newFood);
                }else if (pOrN.ToLower() == "n")
                {
                    int netWeight = 1;

                    Console.Write("Enter Expirey Year: ");
                    netWeight = int.Parse(Console.ReadLine());

                    NonPerishable newFood = new NonPerishable(name, price, grossWeight, netWeight);
                    items.Add(newFood);
                }else
                    Console.WriteLine("Sorry, i dont understand that command");
            }
            else if (itemType.ToLower() == "c")
            {
                Console.Write("Enter Size of Clothing: ");
                string size = Console.ReadLine();

                Console.Write("Is Clothing (S)afty or (C)asual: ");
                string sOrC = Console.ReadLine();

                if (sOrC.ToLower() == "s")
                {
                    string rating = "";                    
                    Console.Write("What is the safty Rating (H, M, L): ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "h")
                        rating = "H";
                    else if (input.ToLower() == "M")
                        rating = "H";
                    else if (input.ToLower() == "L")
                        rating = "L";
                    else
                        Console.WriteLine("Sorry, i dont understand that command");
                    Console.Write("Is it already used y/n: ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        Safty newClothing = new Safty(name, price, size, true, rating);
                        items.Add(newClothing);
                    }
                    else if (input.ToLower() == "n")
                    {
                        Safty newClothing = new Safty(name, price, size, false, rating);
                        items.Add(newClothing);
                    }else
                        Console.WriteLine("Sorry, i dont understand that command");
                }
                else if (sOrC.ToLower() == "c")
                {
                    string style = "";
                    Console.Write("Is the Style (D)ayWear, (N)ightWear or (S)wimWear): ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "d")
                        style = "Daywear";
                    else if (input.ToLower() == "n")
                        style = "Nightware";
                    else if (input.ToLower() == "s")
                        style = "Swimwear";
                    Console.Write("Is it already used y/n: ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        Casual newClothing = new Casual(name, price, size, true, style);
                        items.Add(newClothing);
                    }
                    else if (input.ToLower() == "n")
                    {
                        Casual newClothing = new Casual(name, price, size, false, style);
                        items.Add(newClothing);
                    }else
                        Console.WriteLine("Sorry, i dont understand that command");
                }else
                    Console.WriteLine("Sorry, i dont understand that command");
            }else
                Console.WriteLine("Sorry, i dont understand that command");
        }
    }
}
