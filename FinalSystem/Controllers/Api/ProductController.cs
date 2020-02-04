using FinalSystem.Models;
using System.Web.Http;

namespace FinalSystem.Controllers.Api
{
    public class ProductController : ApiController
    {
        private readonly Generics.IUnitOfWork _unitOfWork;

        public ProductController(Generics.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route(Name = "{id}")]
        public IHttpActionResult GetItem([FromUri]int id)
        {
            var product = _unitOfWork.ProductRepository.GetItem(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult AddItem([FromBody]ProductModel model)
        {
            _unitOfWork.ProductRepository.AddItem(model);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteItem(int id)
        {
            _unitOfWork.ProductRepository.DeleteItem(id);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateItem(int? id, ProductModel model)
        {
            _unitOfWork.ProductRepository.UpdateItem(id, model);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult GetItems()
        {
            _unitOfWork.ProductRepository.GetItems();
            return Ok();
        }
    }
}