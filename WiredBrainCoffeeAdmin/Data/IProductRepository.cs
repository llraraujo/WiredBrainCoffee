using Microsoft.EntityFrameworkCore.Update.Internal;

namespace WiredBrainCoffeeAdmin.Data
{
    public interface IProductRepository
    {
        void Add(Product product);
        void  Update(Product product);
        Product GetById(int id);
        List<Product> GetAll();
        void Delete(int id);
    }
}
