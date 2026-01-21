using Mission3;

internal class Program
{
    private static void Main(string[] args)
    {
        List<FoodItem> foodItems = new List<FoodItem>();
        bool running = true;

        while (running)
        {
            // Display menu
            Console.WriteLine("Food Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                // Add Food Item
                Console.Write("Enter food name: ");
                string name = Console.ReadLine();

                Console.Write("Enter category: ");
                string category = Console.ReadLine();

                Console.Write("Enter quantity (0 or higher): ");
                string quantityInput = Console.ReadLine();
                int quantity;

                //error handling
                if (!int.TryParse(quantityInput, out quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid quantity. Setting to 0.");
                    quantity = 0;
                }

                Console.Write("Enter expiration date (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();
                DateTime expirationDate;

                if (!DateTime.TryParse(dateInput, out expirationDate))
                {
                    Console.WriteLine("Invalid date. Setting to today.");
                    expirationDate = DateTime.Today;
                }

                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                foodItems.Add(newItem);

                Console.WriteLine("Food item added: " + name + ", " + category + ", " + quantity + ", " + expirationDate.ToShortDateString());
            }
            else if (choice == "2")
            {
                // Delete Food Item
                Console.Write("Enter the name of the food item to delete: ");
                string nameToDelete = Console.ReadLine();

                FoodItem itemToRemove = null;
                for (int i = 0; i < foodItems.Count; i++)
                {
                    if (foodItems[i].Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        itemToRemove = foodItems[i];
                    }
                }

                //error handling
                if (itemToRemove != null)
                {
                    foodItems.Remove(itemToRemove);
                    Console.WriteLine("Food item deleted.");
                }
                else
                {
                    Console.WriteLine("Food item not found.");
                }
            }
            else if (choice == "3")
            {
                // Print all food items
                if (foodItems.Count == 0)
                {
                    Console.WriteLine("No food items in inventory.");
                }
                else
                {
                    Console.WriteLine("Current Food Inventory:");
                    for (int i = 0; i < foodItems.Count; i++)
                    {
                        Console.WriteLine("Name: " + foodItems[i].Name +
                                          ", Category: " + foodItems[i].Category +
                                          ", Quantity: " + foodItems[i].Quantity +
                                          ", Expiration: " + foodItems[i].ExpirationDate.ToShortDateString());
                    }
                }
            }
            else if (choice == "4")
            {
                running = false;
                Console.WriteLine("Exiting program...");
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }

            Console.WriteLine();
        }
    }
}
