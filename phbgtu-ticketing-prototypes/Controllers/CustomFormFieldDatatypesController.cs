using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using phbgtu_ticketing_prototypes.Data;
using phbgtu_ticketing_prototypes.Models;

namespace phbgtu_ticketing_prototypes.Controllers
{
    public class CustomFormFieldDatatypesController : Controller
    {
        private readonly TicketContext _context;

        public CustomFormFieldDatatypesController(TicketContext context)
        {
            _context = context;    
        }

        // GET: CustomFormFieldDatatypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomFormFieldDatatypes.ToListAsync());
        }

        // GET: CustomFormFieldDatatypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldDatatype = await _context.CustomFormFieldDatatypes
                .SingleOrDefaultAsync(m => m.CustomFormFieldDatatypeID == id);
            if (customFormFieldDatatype == null)
            {
                return NotFound();
            }

            return View(customFormFieldDatatype);
        }

        // GET: CustomFormFieldDatatypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomFormFieldDatatypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomFormFieldDatatypeID,DatatypeName")] CustomFormFieldDatatype customFormFieldDatatype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customFormFieldDatatype);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customFormFieldDatatype);
        }

        // GET: CustomFormFieldDatatypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldDatatype = await _context.CustomFormFieldDatatypes.SingleOrDefaultAsync(m => m.CustomFormFieldDatatypeID == id);
            if (customFormFieldDatatype == null)
            {
                return NotFound();
            }
            return View(customFormFieldDatatype);
        }

        // POST: CustomFormFieldDatatypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFormFieldDatatypeID,DatatypeName")] CustomFormFieldDatatype customFormFieldDatatype)
        {
            if (id != customFormFieldDatatype.CustomFormFieldDatatypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customFormFieldDatatype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFormFieldDatatypeExists(customFormFieldDatatype.CustomFormFieldDatatypeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(customFormFieldDatatype);
        }

        // GET: CustomFormFieldDatatypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldDatatype = await _context.CustomFormFieldDatatypes
                .SingleOrDefaultAsync(m => m.CustomFormFieldDatatypeID == id);
            if (customFormFieldDatatype == null)
            {
                return NotFound();
            }

            return View(customFormFieldDatatype);
        }

        // POST: CustomFormFieldDatatypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customFormFieldDatatype = await _context.CustomFormFieldDatatypes.SingleOrDefaultAsync(m => m.CustomFormFieldDatatypeID == id);
            _context.CustomFormFieldDatatypes.Remove(customFormFieldDatatype);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFormFieldDatatypeExists(int id)
        {
            return _context.CustomFormFieldDatatypes.Any(e => e.CustomFormFieldDatatypeID == id);
        }
    }
}
