using Chapter4.Models.Pages;
using System.Collections.Generic;

namespace Chapter4.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        PagedList<Product> GetProducts(QueryOptions options, long category = 0);
        PagedList<Product> GetProducts(QueryOptions options);
        Product GetProduct(long key);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateAll(Product[] products);
        void Delete(Product product);
    }
}
