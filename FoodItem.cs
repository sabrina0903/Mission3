using System;
using System.Collections.Generic;
using System.Text;

namespace Mission3
{
    internal class FoodItem
    {
        public string Name;
        public string Category;
        public int Quantity;
        public DateTime ExpirationDate;

        public FoodItem(string Name, string Category, int Quantity, DateTime ExpirationDate)
        {
            this.Name = Name;
            this.Category = Category;
            this.Quantity = Quantity;
            this.ExpirationDate = ExpirationDate;
        }
    }
}
