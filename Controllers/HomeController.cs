using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;

namespace UsingViewComponents.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository) => _productRepository = productRepository;

        public ViewResult Index() => View(_productRepository.Products);

        public ViewResult Create() => View();

        [HttpPost]
        public RedirectToActionResult Create(Product product)
        {
            _productRepository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}