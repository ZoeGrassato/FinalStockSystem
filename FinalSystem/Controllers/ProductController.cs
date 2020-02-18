using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalSystem.DataBinding;
using FinalSystem.Generics;
using FinalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Guid GetUniqueIdentifier()
        {
            var identity = (ClaimsIdentity)this.User.Identity;
            var claim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            return userId;
        }

        public List<ProductModel> GetProducts()
        {
            return _unitOfWork.ProductRepository.GetItems().ToList();
        }
        public List<ProductCategoryModel> GetProductCategories()
        {
            return _unitOfWork.ProductCategoryRepository.GetItems().ToList();
        }

        [HttpPost]
        public void SaveProduct([FromBody] AddProductObjectBinder product)
        {
            var userId = GetUniqueIdentifier();
            var newProduct = new ProductModel();
            var categories = GetProductCategories();
            var current = categories.FirstOrDefault(x => x.CategoryName == product.CategoryName);

            newProduct.Name = product.Name;
            newProduct.Price = float.Parse(product.Price);
            newProduct.Description = product.Description;
            newProduct.ProductCategoryId = current.Id;
            newProduct.ShopId = userId;

            _unitOfWork.ProductRepository.AddItem(newProduct);
            _unitOfWork.Save();
        }

        public IActionResult AddProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                var newProd = new ProductModel();
                newProd.categories = GetProductCategories();
                return View(newProd);
            }
            else return View("Home/Index");
        }

        [HttpPost]
        public IActionResult FilterDeletionByCategory([FromBody] DeleteProductObjectBinder categoryInfo)
        {
            var currentCategory = GetProductCategories().FirstOrDefault(x => x.CategoryName == categoryInfo.CategoryName);
            var filteredProducts = GetProducts().Where(x => x.ProductCategoryId == currentCategory.Id).ToList();
            //var model = new DeleteSearchFilterModel() { ProductCategoryModels = GetProductCategories().ToList(), ProductModels = filteredCategories };
            return RedirectToAction("DeleteProduct", new { filteredProducts });
        }

        [HttpPost]
        public IActionResult DeleteProductMethod()
        {
            //_unitOfWork.ProductRepository.DeleteItem(GetProducts()
            //    .FirstOrDefault(x => x.Name == productToDelete.ProductName)
            //    .Id);
            //_unitOfWork.Save();
            return View();
        }

        public IActionResult DeleteProduct(List<ProductModel> productModels = null)
        {
            var validModels = new List<ProductModel>();
            validModels = productModels.Count() > 0 ? productModels : new List<ProductModel>();

            var newItem = new DeleteSearchFilterModel() { ProductCategoryModels = GetProductCategories(), ProductModels = validModels };
            return View("DeleteProduct", newItem);
        }

        [HttpGet]
        public IActionResult ProductList(ProductObjectBinder product)
        {
            
            if (product != null)
            {
                var stored = new ProductModel() { productModels = GetProducts() };
                return View(stored);
            }
            else
            {
                var selectedObject = GetProducts().Single(x => x.Name == product.ProductName);
                var model = new ProductModel();
                model = selectedObject;
                return View(model);
            }
        }
    }
}