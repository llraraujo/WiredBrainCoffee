using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
        private readonly WiredContext _wiredContext;
        private readonly IWebHostEnvironment _webEnv;

        public AddProductModel(WiredContext context, IWebHostEnvironment environment) 
        { 
            _wiredContext = context;
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
            this._wiredContext.Products.Add(NewProduct);
            this._wiredContext.SaveChanges();

            return RedirectToPage("ViewAllProducts");
        }

    }
}
