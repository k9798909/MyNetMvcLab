using System;
using System.Collections.Generic;
using MyNetMvcLab.Models;

namespace MyNetMvcLab.IServices
{
    public interface IProductService
    {
        List<Product> FindAll();
        Product FindByProid(int proid);
        void Insert(Product product);
        void Update(Product product);   
        void Delete(int id);
    }
}
