namespace Assignment5MusicShop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Adds an item to the cart
        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.MusicId == item.MusicId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        // Removes an item from the cart
        public void RemoveItem(int musicId)
        {
            var item = Items.FirstOrDefault(i => i.MusicId == musicId);
            if(item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                Items.Remove(item);
            }
        }

        // Clears all items from the cart
        public void Clear()
        {
            Items.Clear();
        }

        // Calculates the total price of all items in the cart
        public decimal TotalPrice()
        {
            return Items.Sum(i => i.Price * i.Quantity);
        }
    }

}
