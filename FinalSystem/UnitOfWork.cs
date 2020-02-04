using FinalSystem.Data;
using FinalSystem.Generics;
using FinalSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IEventRepository _eventRepository;
        private IProductCategoryRepository _productCategoryRepository;
        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (_productCategoryRepository == null)
                {
                    _productCategoryRepository = new ProductCategoryRepository(_applicationDbContext);
                }
                return _productCategoryRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_applicationDbContext);
                }
                return _orderRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_applicationDbContext);
                }
                return _productRepository;
            }
        }

        public IEventRepository EventRepository
        {
            get
            {
                if (_eventRepository == null)
                {
                    _eventRepository = new EventRepository(_applicationDbContext);
                }
                return _eventRepository;
            }
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
