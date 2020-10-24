using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tp_Comerce.Data;
using Tp_Comerce.Models;


namespace Tp_Comerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        UserManager<IdentityUser> _UserManager;
        ApplicationDbContext _context;

        public UsersController(UserManager<IdentityUser> usermanger,ApplicationDbContext context)
        {
            _UserManager = usermanger;
            _context = context;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            return View(_context.ApplicationUsers.ToList());
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUser user)
        {

            var userInfo = await _context.ApplicationUsers.FindAsync(user.Id);
            if (userInfo==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    userInfo.FirstName = user.FirstName;
                    userInfo.LastName = user.LastName;
                    var result =await _UserManager.UpdateAsync(userInfo);

                    if(result.Succeeded)
                    {
                    TempData["modification"] = "Utilisateur Est Bien Modifié.";
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(userInfo);

        }
        // GET: UsersController/Delete/5
        public async Task<ActionResult> LockOut(string id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var user =await _context.ApplicationUsers.FindAsync(id);
            if(user==null)
            {
                return NotFound();

            }
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LockOut(ApplicationUser user)
        {

            var userInfo =  _context.ApplicationUsers.FirstOrDefault(c => c.Id == user.Id);
           if(userInfo==null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = DateTime.Now.AddYears(100);
            int row =  _context.SaveChanges();
            if(row>0)
            {
                TempData["modification"] = "Utilisateur Est Bien Verrouillé.";
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.ApplicationUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();

            }
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UnLock(ApplicationUser user)
        {

            var userInfo = _context.ApplicationUsers.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = null;
            
            int row = _context.SaveChanges();
            if (row > 0)
            {
                TempData["activation"] = "Utilisateur Est Bien Déverrouillé.";
             
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }


    }
}
