using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalSystem.Models;
using FinalSystem.Generics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FinalSystem.DataBinding;

namespace FinalSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult ReturnLoginPage()
        {
            return Redirect("/Account/Login");
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;
            }
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public void SaveData([FromBody] ObjectBinder objectBinder)
        {

        }

        public IActionResult AddProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                var newProd = new ProductModel();
                newProd.categories = _unitOfWork.ProductCategoryRepository.GetItems().ToList();
                return View(newProd);
            }
            else return View("Index");
        }

        //uses ajax
        [HttpPost]
        public void SaveProduct([FromBody] ObjectBinder product)
        {
            var identity = (ClaimsIdentity)this.User.Identity;
            var claim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);

            var newProduct = new ProductModel();
            var categories = _unitOfWork.ProductCategoryRepository.GetItems();
            var current = categories.FirstOrDefault(x => x.CategoryName == product.CategoryName);

            newProduct.Name = product.Name;
            newProduct.Price = float.Parse(product.Price);
            newProduct.Description = product.Description;
            newProduct.ProductCategoryId = current.Id;
            newProduct.ShopId = userId;

            _unitOfWork.ProductRepository.AddItem(newProduct);
            _unitOfWork.Save();
        }


        public IActionResult AddCategory(ProductCategoryModel productCategory)
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)this.User.Identity;
                var claim = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = Guid.Parse(claim.Value);
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

        //uses mvc 
        [HttpPost]
        public void SaveProdCategory(ProductCategoryModel newCategory, Guid userId)
        {
            var category = new ProductCategoryModel();
            category.CategoryName = newCategory.CategoryName;
            category.ShopId = userId;
            _unitOfWork.ProductCategoryRepository.AddItem(category);
            _unitOfWork.Save();
        }



        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult CategoryList()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
