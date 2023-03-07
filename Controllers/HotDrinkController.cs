using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Data;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class HotDrinkController : Controller
    {
        private readonly AppDbContext _context;

        public HotDrinkController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HotDrink
        public async Task<IActionResult> Index()
        {
              return View(await _context.HotDrink.ToListAsync());
        }

        // GET: HotDrink
        public async Task<IActionResult> OrderHotDrink()
        {
            var result = await _context.HotDrink.ToListAsync();

            OrderModel<HotDrink> orderModel = new OrderModel<HotDrink>();
            orderModel.OrderItem = new List<Order>();

            foreach (var item in result)
            {
                Order order = new Order();
                order.OrderItemId = item.HotDrinkId;
                order.OrderItem = item.HotDrinkName;
                order.Count = 0;
                orderModel.OrderItem.Add(order);
            }


            return View(orderModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OrderHotDrink(OrderModel<HotDrink> orderModel)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(hotDrink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // GET: HotDrink/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotDrink == null)
            {
                return NotFound();
            }

            var hotDrink = await _context.HotDrink
                .FirstOrDefaultAsync(m => m.HotDrinkId == id);
            if (hotDrink == null)
            {
                return NotFound();
            }

            return View(hotDrink);
        }

        // GET: HotDrink/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotDrink/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotDrinkId,HotDrinkName")] HotDrink hotDrink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotDrink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotDrink);
        }

        // GET: HotDrink/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotDrink == null)
            {
                return NotFound();
            }

            var hotDrink = await _context.HotDrink.FindAsync(id);
            if (hotDrink == null)
            {
                return NotFound();
            }
            return View(hotDrink);
        }

        // POST: HotDrink/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotDrinkId,HotDrinkName")] HotDrink hotDrink)
        {
            if (id != hotDrink.HotDrinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotDrink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotDrinkExists(hotDrink.HotDrinkId))
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
            return View(hotDrink);
        }

        // GET: HotDrink/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotDrink == null)
            {
                return NotFound();
            }

            var hotDrink = await _context.HotDrink
                .FirstOrDefaultAsync(m => m.HotDrinkId == id);
            if (hotDrink == null)
            {
                return NotFound();
            }

            return View(hotDrink);
        }

        // POST: HotDrink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotDrink == null)
            {
                return Problem("Entity set 'AppDbContext.HotDrink'  is null.");
            }
            var hotDrink = await _context.HotDrink.FindAsync(id);
            if (hotDrink != null)
            {
                _context.HotDrink.Remove(hotDrink);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotDrinkExists(int id)
        {
          return _context.HotDrink.Any(e => e.HotDrinkId == id);
        }
    }
}
