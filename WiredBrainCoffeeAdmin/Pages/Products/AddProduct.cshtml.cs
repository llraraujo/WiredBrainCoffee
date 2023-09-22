using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _webEnv;

        public AddProductModel(IProductRepository repository, IWebHostEnvironment environment) 
        { 
            _repository = repository;
            this._webEnv = environment;
        }

        [BindProperty]
        public Product NewProduct { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid) { return Page(); }

            if(NewProduct.Upload is not null)
            {
                NewProduct.ImageFileName = NewProduct.Upload.FileName;

                var file = Path.Combine(_webEnv.ContentRootPath, "wwwroot/images/menu", NewProduct.Upload.FileName);
                using(var fileStream = new FileStream(file, FileMode.Create))
                {
                    await NewProduct.Upload.CopyToAsync(fileStream);
                }
            }
            NewProduct.Created = DateTime.Now;
            this._repository.Add(NewProduct);

            return RedirectToPage("ViewAllProducts");
        }

    }
}
