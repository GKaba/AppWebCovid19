using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tp_Comerce.Data;
using Tp_Comerce.Models;
using Tp_Comerce.utils;
using Microsoft.AspNetCore.Authorization;
namespace Tp_Comerce.Controllers
{
    [Area("Customer")]
  
    public class CheckOutController : Controller
    {
        //Get Check out Method
        private ApplicationDbContext _context;

        public CheckOutController(ApplicationDbContext context)
        {
            _context = context;

        }
        //Get
        public IActionResult CheckOut()
        {

            return View();
        }

        //Post CheckOut Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(Order anorder)
        {

            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetaile orderDetails = new OrderDetaile();
                    orderDetails.ProductId = product.Id;

                    anorder.OrderDetailes.Add(orderDetails);
                }
                anorder.OrderNo = GetOrderNo();
                _context.Orders.Add(anorder);
                await _context.SaveChangesAsync();
                HttpContext.Session.Set("products", new List<Product>());
                return RedirectToAction("Remerci");
            }
            else
            {
                return View();
            }
           // return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private string GetOrderNo()
        {
            int rowCount = _context.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
        
        //Get
        public IActionResult Remerci()
        {

            return View();
        }
    }
}
