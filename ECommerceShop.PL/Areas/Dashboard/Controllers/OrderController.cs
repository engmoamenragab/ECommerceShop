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
    public class OrderController : Controller
    {
        #region Fields
        private readonly IOrderRepo orderRepo;
        private readonly IProductRepo productRepo;
        private readonly IOrderProductRepo orderProductRepo;
        private readonly ICustomerRepo customerRepo;
        private readonly IMapper mapper;
        #endregion

        #region Constructors
        public OrderController(IOrderRepo orderRepo, IProductRepo productRepo, IOrderProductRepo orderProductRepo, ICustomerRepo customerRepo, IMapper mapper)
        {
            this.orderRepo = orderRepo;
            this.productRepo = productRepo;
            this.orderProductRepo = orderProductRepo;
            this.customerRepo = customerRepo;
            this.mapper = mapper;
        }
        #endregion

        #region Create Actions
        [HttpGet]
        public IActionResult Create()
        {
            var customers = customerRepo.ReadAll();
            var products = productRepo.ReadAll();
            ViewBag.cust = new SelectList(customers, "id", "name");
            ViewBag.prod = new SelectList(products, "id", "name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var order = mapper.Map<Order>(model);
                    var data = orderRepo.Create(order);
                    foreach (var item in model.ProductId)
                    {
                        orderProductRepo.Create(new OrderProduct() {OrderId = data.Id, ProductId = item });
                    }
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
            var data = orderRepo.ReadAll();
            var model = mapper.Map<IEnumerable<OrderVM>>(data);
            return View(model);
        }
        public IActionResult Read(int id)
        {
            var data = orderRepo.Read(id);
            var model = mapper.Map<OrderVM>(data);
            return View(model);
        }
        #endregion

        #region Delete Actions
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = orderRepo.Read(id);
            var model = mapper.Map<OrderVM>(data);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(OrderVM model)
        {
            var data = mapper.Map<Order>(model);
            orderRepo.Delete(data);
            return RedirectToAction("Index");
        }
        #endregion

        #region Ajax Requests
        [HttpPost]
        public JsonResult Count()
        {
            var data = orderRepo.Count();
            return Json(data);
        }
        #endregion
    }
}
