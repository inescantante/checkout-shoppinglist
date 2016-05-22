namespace ShoppingList.Models
{
    public class Item
    {
        public int Id { get; set; }
        //[Index("NameIndex", IsUnique = true)]
        public string Name { get; set; }
        public int Quantity { get; set; }        
    }
}