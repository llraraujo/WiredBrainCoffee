using Microsoft.AspNetCore.Mvc;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Components
{
    public class ProductListViewComponent: ViewComponent
    {
        private readonly IProductRepository _repository;

        public ProductListViewComponent(IProductRepository repository)
        {
                _repository = repository;   
        }

        public IViewComponentResult Invoke(int count)
        {
            var items = _repository.GetAll();
            if(count > 0)
            {
                return View(items.Take(count).ToList());
            }
            return View(items);
        }
    }
}
