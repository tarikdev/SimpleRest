using Coolblue.Assigment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolblue.Assigment.DAL.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProduct(string productId);

        Product AddProduct(Product item);

        bool RemoveProduct(string productId);

        bool UpdateProduct(string productId, Product item);
    }
}
