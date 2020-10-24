using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tp_Comerce.Data;
using Tp_Comerce.Models;
using Tp_Comerce.utils;


namespace Tp_Comerce.Controllers
{
   [Area("Customer")]
   
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            
        }
        
        public IActionResult Index(int? page)
        {
            return View(_context.Products.Include(c=>c.ProductTypes).ToList());
        }

        //GEt 
       
        [ActionName("AjuterPanier")]
        
        public IActionResult AjuterPanier(int? id)
        {
            
            List<Product> products = new List<Product>();
          if (id==null)
            {
                return NotFound();
            }
            var product = _context.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if(product==null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<Product>>("products");
            if(products==null)
            {
                products = new List<Product>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);

           
           
            return View("Index", _context.Products.Include(c => c.ProductTypes).ToList());

        }

       
        [ActionName("EnleverPanier")]
        public IActionResult EnleverPanier(int? id)
        {

          
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id==id);

                if(product!=null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
           
            return View("Index", _context.Products.Include(c => c.ProductTypes).ToList());

        }

 
        [ActionName("Message")]
        public  IActionResult Message( )
        {
            Message msg = new Message();
           
                int Id = _context.Messages.ToList().Count() + 1;
                msg.Id = Id.ToString("0000");
                msg.Nom = Request.Form["name"];
                msg.Email = Request.Form["email"];
                msg.Sujet = Request.Form["subject"];
                msg.Msg = Request.Form["message"];
                _context.Messages.Add(msg);
                    _context.SaveChangesAsync();
                    TempData["save"] = "Message est bien envoyé.";

                    return RedirectToAction(nameof(RecuMsg));
               
               
        }

        //Get
        [ActionName("RecuMsg")]
        public IActionResult RecuMsg()
        {

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
