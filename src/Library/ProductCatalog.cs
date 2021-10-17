using System.Linq;

namespace Full_GRASP_And_SOLID
{
    public class ProductCatalog : Catalog<Product>
    {
        public ProductCatalog() {}

        public void AddToCatalog(string description, double unitCost)
        {
            Product product = new Product(description, unitCost);
            itemCatalog.Add(product);
        }

        public override Product GetItem(string description)
        {
            var query = from Product product in itemCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }
    }
}