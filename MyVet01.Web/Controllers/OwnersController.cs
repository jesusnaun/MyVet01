using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyVet01.Web.Data;
using MyVet01.Web.Data.Entities;
using MyVet01.Web.Helpers;
using MyVet01.Web.Models;

namespace MyVet01.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OwnersController : Controller
    {
        private readonly DataContext _context;

        private readonly IUserHelper _userHelper; //PARA PODER USAR USER AL CREAR OWNER


        //public OwnersController(DataContext context)
        public OwnersController(DataContext context, IUserHelper userHelper) //ESTO PARA PODER USAR USER EN EL OWNER
        {
            _context = context;
            _userHelper = userHelper;  // PARA PODER USAR USER 
        }

        //// GET: Owners
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Owners.ToListAsync());
        //}
        // GET: Owners
        public IActionResult Index()
        {
            return View(_context.Owners
                .Include(o => o.User)
                .Include(p => p.Pets) //incluir tantos modelos como yo desee
                )
                ;
        }



        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var owner = await _context.Owners
            //    .FirstOrDefaultAsync(m => m.Id == id);

            var owner = await _context.Owners
                  .Include(o => o.User)
                .Include(p => p.Pets)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id")] Owner owner)
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(owner);
                //await _context.SaveChangesAsync();

                var user = new User
                {
                    Address = model.Address,
                    Document = model.Document,
                    Email = model.Username, 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Username
                };

                var response = await _userHelper.AddUserAsync(user, model.Password);

                if (response.Succeeded)
                {
                    var userInDb = await _userHelper.GetUserByEmailAsync(model.Username);
                        await _userHelper.AddUserToRoleAsync(userInDb, "User");

                    //SI TODO FUNCIONA OK, PASAMOS A CREAR EL OWNER
                    var owner = new Owner
                    {
                        Agendas = new List<Agenda>(),
                        Pets = new List<Pet>(),
                        User = userInDb
                    };


                    //PARA GRABAR EN LA BD
                    _context.Owners.Add(owner);
                    //TRY CATCH ANTES DE GRABAR
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {

                       ModelState.AddModelError(String.Empty, ex.ToString());  //EN CASO FALLE
                        return View(model);
                    }


                }
                ModelState.AddModelError(String.Empty, response.Errors.FirstOrDefault().Description);  //EN CASO FALLE
                //ModelState.AddModelError(String.Empty, "Usuario ya registrado");  

                
            }
            //return View(owner);
            return View(model);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(owner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _context.Owners.FindAsync(id);
            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
