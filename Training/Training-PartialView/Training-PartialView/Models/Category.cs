namespace Fiorello_backend.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        ICollection<Product> Products { get; set; }
    }
}
