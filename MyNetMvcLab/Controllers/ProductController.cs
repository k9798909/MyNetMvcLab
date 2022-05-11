using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using MyNetMvcLab.IServices;
using MyNetMvcLab.Models;

namespace MyNetMvcLab.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productSrevice;

        public ProductController(ILogger<ProductController> logger, IProductService productSrevice)
        {
            _logger = logger;
            _productSrevice = productSrevice;
        }

        public IActionResult Index()
        {
            try
            {
                List<Product> productList = _productSrevice.FindAll();

                if (TempData.ContainsKey("msg"))
                {
                    ViewData["msg"] = TempData["msg"];
                }

                return View(productList);
            }
            catch (Exception e)
            {
                _logger.LogError("進入商品時發生錯誤：{}", e);
                return View();
            }
        }

        public IActionResult Add()
        {
            return View("Edit",new Product());
        }

        [HttpGet("Edit/{proid}")]
        public IActionResult Edit(int proid)
        {
            try
            {
                return View("Edit", _productSrevice.FindByProid(proid));
            }
            catch (Exception e)
            {
                _logger.LogError("進入商品修改時發生錯誤：{}", e);
                return Index();
            }
        }

        public IActionResult Dt()
        {
            return View();
        }

        [HttpPost("Save")]
        public IActionResult Save(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", product);
                }

                if (product.Proid == null)
                {
                    _productSrevice.Insert(product);
                    TempData.Add("msg","商品新增成功");
                }
                else {
                    _productSrevice.Update(product);
                    TempData.Add("msg", "商品修改成功");
                }
                return RedirectToAction(actionName: "Index");
            }
            catch (Exception e)
            {
                _logger.LogError("儲存商品時發生錯誤：{}", e);
                return View("Edit");
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int deleteId)
        {
            try
            {
                _productSrevice.Delete(deleteId);
                TempData.Add("msg", "商品刪除成功");
                return RedirectToAction(actionName: "Index");
            }
            catch (Exception e)
            {
                _logger.LogError("新增商品時發生錯誤：{}", e);
                return View("List");
            }
            
        }
    }
}
