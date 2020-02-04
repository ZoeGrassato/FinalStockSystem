using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using FinalSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FinalSystem.Controllers.Api
{
    public class ProductCategoryController : ApiController
    {
        private readonly Generics.IUnitOfWork _unitOfWork;

        public ProductCategoryController(Generics.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route(Name = "{id}")]
        public IHttpActionResult GetItem([FromUri]int id)
        {
            var category = _unitOfWork.ProductCategoryRepository.GetItem(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddItem([System.Web.Http.FromBody]ProductCategoryModel model)
        {
            _unitOfWork.ProductCategoryRepository.AddItem(model);
            _unitOfWork.Save();
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult DeleteItem(int id)
        {
            _unitOfWork.ProductCategoryRepository.DeleteItem(id);
            _unitOfWork.Save();
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateItem(int? id, ProductCategoryModel model)
        {
            _unitOfWork.ProductCategoryRepository.UpdateItem(id, model);
            _unitOfWork.Save();
            return Ok();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult GetItems()
        {
            _unitOfWork.ProductCategoryRepository.GetItems();
            return Ok();
        }
    }
}