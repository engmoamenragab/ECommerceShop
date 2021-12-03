using AutoMapper;
using ECommerceShop.BL.Interfaces;
using ECommerceShop.BL.Repositories;
using ECommerceShop.BL.ViewModels;
using ECommerceShop.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceShop.PL.Areas.Dashboard.Controllers
{
    public class ProductController : Controller
    {
        //ProductRepo productRepo = new ProductRepo();

        #region Fields
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public ProductController(IProductRepo productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }
        #endregion

        #region Create Actions
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Product>(model);
                    productRepo.Create(data);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        #endregion

        #region Read Actions
        public IActionResult Index()
        {
            var data = productRepo.ReadAll();
            var model = mapper.Map<IEnumerable<ProductVM>>(data);
            return View(model);
        }
        public IActionResult Read(int id)
        {
            var data = productRepo.Read(id);
            var model = mapper.Map<ProductVM>(data);
            return View(model);
        }
        #endregion

        #region Update Actions
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = productRepo.Read(id);
            var model = mapper.Map<ProductVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ProductVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Product>(model);
                    productRepo.Update(data);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        #endregion

        #region Delete Actions
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = productRepo.Read(id);
            var model = mapper.Map<ProductVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(ProductVM model)
        {
            var data = mapper.Map<Product>(model);
            productRepo.Delete(data);
            return RedirectToAction("Index");
        }
        #endregion

        #region Ajax Requests
        [HttpGet]
        public IActionResult InStock()
        {
            return View();
        }
        [HttpPost]
        public JsonResult InStock(int prodId)
        {
            var data = productRepo.InStockProduct(prodId);
            return Json(data);
        }
        #endregion
    }
}
