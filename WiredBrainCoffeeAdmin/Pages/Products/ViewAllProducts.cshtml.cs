using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class ViewAllProductsModel : PageModel
    {
        private readonly IProductRepository _repository;

        public List<Product> Products { get; set; }

        public ViewAllProductsModel(IProductRepository repository)
        {
            _repository = repository;
        }

        public void OnGet()
        {
            Products = _repository.GetAll();
        }
    }
}
