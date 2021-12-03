using AutoMapper;
using ECommerceShop.BL.Interfaces;
using ECommerceShop.BL.ViewModels;
using ECommerceShop.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceShop.PL.Areas.Dashboard.Controllers
{
    public class CustomerController : Controller
    {
        #region Fields
        private readonly ICustomerRepo customerRepo;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public CustomerController(ICustomerRepo customerRepo, IMapper mapper)
        {
            this.customerRepo = customerRepo;
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
        public IActionResult Create(CustomerVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Customer>(model);
                    customerRepo.Create(data);
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
            var data = customerRepo.ReadAll();
            var model = mapper.Map<IEnumerable<CustomerVM>>(data);
            return View(model);
        }
        public IActionResult Read(int id)
        {
            var data = customerRepo.Read(id);
            var model = mapper.Map<CustomerVM>(data);
            return View(model);
        }
        #endregion

        #region Update Actions
        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = customerRepo.Read(id);
            var model = mapper.Map<CustomerVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(CustomerVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Customer>(model);
                    customerRepo.Update(data);
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
            var data = customerRepo.Read(id);
            var model = mapper.Map<CustomerVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(CustomerVM model)
        {
            var data = mapper.Map<Customer>(model);
            customerRepo.Delete(data);
            return RedirectToAction("Index");
        }
        #endregion

        #region Ajax Requests
        [HttpGet]
        public IActionResult CheckProducts()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckProducts(int custId)
        {
            var products = customerRepo.ProductByCustomerId(custId);
            var model = mapper.Map<IEnumerable<ProductVM>>(products);
            return Json(model);
        }
        #endregion
    }
}
