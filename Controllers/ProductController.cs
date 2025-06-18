using Microsoft.AspNetCore.Mvc;
using QHRMProductsManagement.Models;
using QHRMProductsManagement.Services;

namespace QHRMProductsManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            pageNumber = Math.Max(1, pageNumber);
            pageSize = Math.Clamp(pageSize, 5, 100);

            var pagedProducts = await _productRepository.GetProductsPaged(pageNumber, pageSize);

            ViewBag.PageSize = pageSize;

            return View(pagedProducts);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddProduct(product);
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProduct(product);
                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteProduct(id);
            TempData["SuccessMessage"] = "Product deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
