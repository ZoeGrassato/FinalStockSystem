using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalSystem.Generics;
using FinalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalSystem.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public ProductCategoryController(IUnitOfWork unitOfWork)
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

        public IEnumerable<ProductModel> GetProducts()
        {
            return _unitOfWork.ProductRepository.GetItems().ToList();
        }

        public IEnumerable<ProductCategoryModel> GetProductCategories()
        {
            return _unitOfWork.ProductCategoryRepository.GetItems().ToList();
        }

        public IActionResult DeleteProductCategory()
        {
            return View();
        }

        public IActionResult AddCategory(ProductCategoryModel productCategory)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = GetUniqueIdentifier();
                if (productCategory.CategoryName == null)
                {
                    return View("AddCategory");
                }
                else
                {
                    SaveProdCategory(productCategory, userId);
                    return View("Index");
                }
            }
            return View("Index");
        }

        [HttpPost]
        public void SaveProdCategory(ProductCategoryModel newCategory, Guid userId)
        {
            var category = new ProductCategoryModel();
            category.CategoryName = newCategory.CategoryName;
            category.ShopId = userId;
            _unitOfWork.ProductCategoryRepository.AddItem(category);
            _unitOfWork.Save();
        }

        public IActionResult CategoryList()
        {
            return View();
        }
    }
}