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
    public class TicketDesignsController : Controller
    {
        private readonly TicketContext _context;

        public TicketDesignsController(TicketContext context)
        {
            _context = context;    
        }

        // GET: TicketDesigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketDesigns.ToListAsync());
        }

        // GET: TicketDesigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketDesign = await _context.TicketDesigns
                .SingleOrDefaultAsync(m => m.TicketDesignID == id);
            if (ticketDesign == null)
            {
                return NotFound();
            }

            // Load the custom form field questions into the object
            try
            {
                ticketDesign.CustomFormFields = _context.CustomFormFieldQuestions
                    .Where(m => m.TicketDesignID == id);
                for (int i = 0; i < ticketDesign.CustomFormFields.Count(); i++ )
                {
                    ticketDesign.CustomFormFields.ElementAt(i).FormFieldDataOptions = _context.CustomFormFieldDataOptions
                        .Where(m => m.CustomFormFieldQuestionID == ticketDesign.CustomFormFields.ElementAt(i).CustomFormFieldQuestionID);
                    ticketDesign.CustomFormFields.ElementAt(i).FormFieldDatatype = _context.CustomFormFieldDatatypes
                        .Where(m => m.CustomFormFieldDatatypeID == ticketDesign.CustomFormFields.ElementAt(i).CustomFormFieldQuestionID).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

            }

            return View(ticketDesign);
        }

        // GET: TicketDesigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketDesigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketDesignID,DesignName,DesignDescription,EventTicketCode")] TicketDesign ticketDesign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketDesign);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticketDesign);
        }

        // GET: TicketDesigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketDesign = await _context.TicketDesigns.SingleOrDefaultAsync(m => m.TicketDesignID == id);
            if (ticketDesign == null)
            {
                return NotFound();
            }
            return View(ticketDesign);
        }

        // POST: TicketDesigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketDesignID,DesignName,DesignDescription,EventTicketCode")] TicketDesign ticketDesign)
        {
            if (id != ticketDesign.TicketDesignID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketDesign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketDesignExists(ticketDesign.TicketDesignID))
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
            return View(ticketDesign);
        }

        // GET: TicketDesigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketDesign = await _context.TicketDesigns
                .SingleOrDefaultAsync(m => m.TicketDesignID == id);
            if (ticketDesign == null)
            {
                return NotFound();
            }

            return View(ticketDesign);
        }

        // POST: TicketDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketDesign = await _context.TicketDesigns.SingleOrDefaultAsync(m => m.TicketDesignID == id);
            _context.TicketDesigns.Remove(ticketDesign);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketDesignExists(int id)
        {
            return _context.TicketDesigns.Any(e => e.TicketDesignID == id);
        }
    }
}
