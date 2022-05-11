using MyNetMvcLab.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MyNetMvcLab.Models;
using System;

namespace MyNetMvcLab.Services
{
    public class ProductService : IProductService
    {
        private readonly DBContext _dBContext;

        public ProductService(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Product> FindAll()
        {
            return _dBContext.Product.ToListAsync().Result;
        }

        public Product FindByProid(int proid)
        {
            return _dBContext.Product.Find(proid);
        }

        public void Insert(Product product)
        {
            _dBContext.Product.Add(product);
            _dBContext.SaveChanges();
        }
        public void Update(Product product)
        {
            _dBContext.Update(product);
            _dBContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _dBContext.Remove(new Product { Proid = id });
            _dBContext.SaveChanges();
        }

    }
}
