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
using ReflectionIT.Mvc.Paging;

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
        [HttpGet]
        public IActionResult DeleteProduct(string ProductSearchDelete)
        {
            ViewData["GetDetailsDelete"] = ProductSearchDelete;
            var query = from x in _unitOfWork.ProductRepository.GetItems() select x;
            if (!String.IsNullOrEmpty(ProductSearchDelete))
            {
                query = query.Where(x => x.Name.ToLower().Contains(ProductSearchDelete.ToLower())).OrderBy(x => x.Name).ToList();
            }
            return View(query);
        }

        [HttpPost]
        public void DeleteProductFromDb([FromBody] DeleteProductByIDObjectBinder product)
        {
            _unitOfWork.ProductRepository.DeleteItem(product.Id);
            _unitOfWork.Save();
        }

        public IActionResult DeleteProduct()
        {
            return View(GetProducts().OrderBy(x => x.Name));
        }

        public IActionResult ProductList(int page = 1)
        {
            var query = GetProducts().OrderBy(x => x.Name);
            var model = PagingList.Create(query, 5, page);
            return View(model);
        }

  

        [HttpGet]
        public IActionResult ProductList(string ProductSearch, int page = 1)
        {
            ViewData["GetDetails"] = ProductSearch;
            var query = from x in _unitOfWork.ProductRepository.GetItems() select x;
            if (!String.IsNullOrEmpty(ProductSearch))
            {
                query = query.Where(x => x.Name.Contains(ProductSearch)).ToList();
            }
            var model = PagingList.Create(query, 5, page);
            return View(query);
        }

        public IActionResult EditProduct(int id)
        {
            var item = _unitOfWork.ProductRepository.GetItem(id);
            var categoryName = GetProductCategories().SingleOrDefault(x => x.Id == item.ProductCategoryId).CategoryName;

            var model = new EditProductModel()
            {
                Id = id,
                Name = item.Name,
                Price = item.Price,
                Description = item.Description,
                categories = GetProductCategories(),
                productModels = GetProducts(),
                CategoryName = categoryName,
                ProductCategoryId = item.ProductCategoryId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductModel productModel)
        {
            var model = new ProductModel()
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                ProductCategoryId = GetProductCategories().SingleOrDefault(x => x.CategoryName == productModel.CategoryName).Id,
                Id = productModel.Id
            };
            _unitOfWork.ProductRepository.UpdateItem(model.Id, model);
            _unitOfWork.Save();
            return RedirectToAction("EditProductList");
        }

        [HttpGet]
        public IActionResult EditProductList()
        {
            return View(GetProducts());
        }
    }
}
