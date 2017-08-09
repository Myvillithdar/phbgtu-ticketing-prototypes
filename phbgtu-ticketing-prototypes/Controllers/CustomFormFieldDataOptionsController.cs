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
    public class CustomFormFieldDataOptionsController : Controller
    {
        private readonly TicketContext _context;

        public CustomFormFieldDataOptionsController(TicketContext context)
        {
            _context = context;    
        }

        // GET: CustomFormFieldDataOptions
        public async Task<IActionResult> Index()
        {
            var ticketContext = _context.CustomFormFieldDataOptions.Include(c => c.CustomFormFieldQuestion);
            return View(await ticketContext.ToListAsync());
        }

        // GET: CustomFormFieldDataOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldDataOption = await _context.CustomFormFieldDataOptions
                .Include(c => c.CustomFormFieldQuestion)
                .SingleOrDefaultAsync(m => m.CustomFormFieldDataOptionID == id);
            if (customFormFieldDataOption == null)
            {
                return NotFound();
            }

            return View(customFormFieldDataOption);
        }

        // GET: CustomFormFieldDataOptions/Create
        public IActionResult Create(int? ID)
        {
            ViewData["CustomFormFieldQuestionID"] = new SelectList(_context.CustomFormFieldQuestions, "CustomFormFieldQuestionID", "FormFieldLabel", 
                _context.CustomFormFieldQuestions.Where(m => m.CustomFormFieldQuestionID == ID).SingleOrDefault());
            return View();
        }

        // POST: CustomFormFieldDataOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomFormFieldDataOptionID,CustomFormFieldQuestionID,DataOptionValue")] CustomFormFieldDataOption customFormFieldDataOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customFormFieldDataOption);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomFormFieldQuestionID"] = new SelectList(_context.CustomFormFieldQuestions, "CustomFormFieldQuestionID", "CustomFormFieldQuestionID", customFormFieldDataOption.CustomFormFieldQuestionID);
            return View(customFormFieldDataOption);
        }

        // GET: CustomFormFieldDataOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldDataOption = await _context.CustomFormFieldDataOptions.SingleOrDefaultAsync(m => m.CustomFormFieldDataOptionID == id);
            if (customFormFieldDataOption == null)
            {
                return NotFound();
            }
            ViewData["CustomFormFieldQuestionID"] = new SelectList(_context.CustomFormFieldQuestions, "CustomFormFieldQuestionID", "CustomFormFieldQuestionID", customFormFieldDataOption.CustomFormFieldQuestionID);
            return View(customFormFieldDataOption);
        }

        // POST: CustomFormFieldDataOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFormFieldDataOptionID,CustomFormFieldQuestionID,DataOptionValue")] CustomFormFieldDataOption customFormFieldDataOption)
        {
            if (id != customFormFieldDataOption.CustomFormFieldDataOptionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customFormFieldDataOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFormFieldDataOptionExists(customFormFieldDataOption.CustomFormFieldDataOptionID))
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
            ViewData["CustomFormFieldQuestionID"] = new SelectList(_context.CustomFormFieldQuestions, "CustomFormFieldQuestionID", "CustomFormFieldQuestionID", customFormFieldDataOption.CustomFormFieldQuestionID);
            return View(customFormFieldDataOption);
        }

        // GET: CustomFormFieldDataOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldDataOption = await _context.CustomFormFieldDataOptions
                .Include(c => c.CustomFormFieldQuestion)
                .SingleOrDefaultAsync(m => m.CustomFormFieldDataOptionID == id);
            if (customFormFieldDataOption == null)
            {
                return NotFound();
            }

            return View(customFormFieldDataOption);
        }

        // POST: CustomFormFieldDataOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customFormFieldDataOption = await _context.CustomFormFieldDataOptions.SingleOrDefaultAsync(m => m.CustomFormFieldDataOptionID == id);
            _context.CustomFormFieldDataOptions.Remove(customFormFieldDataOption);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFormFieldDataOptionExists(int id)
        {
            return _context.CustomFormFieldDataOptions.Any(e => e.CustomFormFieldDataOptionID == id);
        }
    }
}
