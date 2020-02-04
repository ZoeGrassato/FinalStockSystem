using FinalSystem.Data;
using FinalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.UI
{
    public class UiInteraction
    {
        private UnitOfWork unitOfWork;

        public IEnumerable<ProductModel> GetProductModels()
        {
            return unitOfWork.ProductRepository.GetItems();
        }
    }
}
