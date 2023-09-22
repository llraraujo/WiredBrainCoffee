using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _webEnv;

        [BindProperty]
        public Product EditProduct { get; set; }

        [FromRoute]
        public int Id { get; set; }

        public EditProductModel(IProductRepository repository, IWebHostEnvironment environment)
        {
            _repository = repository;
            _webEnv = environment;
        }
        public void OnGet()
        {
            EditProduct = _repository.GetById(Id);
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) { return Page(); }

            if (EditProduct.Upload is not null)
            {
                EditProduct.ImageFileName = EditProduct.Upload.FileName;

                var file = Path.Combine(_webEnv.ContentRootPath, "wwwroot/images/menu", EditProduct.Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await EditProduct.Upload.CopyToAsync(fileStream);
                }
            }
            EditProduct.Created = DateTime.Now;
            EditProduct.Id = Id;

            this._repository.Update(EditProduct);

            return RedirectToPage("ViewAllProducts");
        }

        public IActionResult OnPostDelete()
        {
            _repository.Delete(Id);
            return RedirectToPage("ViewAllProducts");
        }
    }
}
