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
    public class CustomFormFieldQuestionsController : Controller
    {
        private readonly TicketContext _context;

        public CustomFormFieldQuestionsController(TicketContext context)
        {
            _context = context;    
        }

        // GET: CustomFormFieldQuestions
        public async Task<IActionResult> Index()
        {
            var ticketContext = _context.CustomFormFieldQuestions.Include(c => c.FormFieldDatatype);
            return View(await ticketContext.ToListAsync());
        }

        // GET: CustomFormFieldQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldQuestion = await _context.CustomFormFieldQuestions
                .Include(c => c.FormFieldDatatype)
                .SingleOrDefaultAsync(m => m.CustomFormFieldQuestionID == id);
            if (customFormFieldQuestion == null)
            {
                return NotFound();
            }

            customFormFieldQuestion.FormFieldDataOptions = await _context.CustomFormFieldDataOptions
                .Where(m => m.CustomFormFieldQuestionID == customFormFieldQuestion.CustomFormFieldQuestionID)
                .ToListAsync();

            return View(customFormFieldQuestion);
        }

        // GET: CustomFormFieldQuestions/Create
        public IActionResult Create(int? id)
        {
            CustomFormFieldQuestion customFormFieldQuestion = null;
            if (id != null)
            {
                customFormFieldQuestion = new CustomFormFieldQuestion();
                customFormFieldQuestion.TicketDesignID = (int)id;
            }

            ViewData["FormFieldDatatypeID"] = new SelectList(_context.CustomFormFieldDatatypes, "CustomFormFieldDatatypeID", "DatatypeName");
            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "DesignName",
                _context.TicketDesigns.Where(m => m.TicketDesignID == id).SingleOrDefault());
            return View(customFormFieldQuestion);
        }

        // POST: CustomFormFieldQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("TicketDesignID,FormFieldLabel,FormFieldDatatypeID,FormFieldRequired")] CustomFormFieldQuestion customFormFieldQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customFormFieldQuestion);
                await _context.SaveChangesAsync();
                customFormFieldQuestion.FormFieldDatatype = await _context.CustomFormFieldDatatypes
                    .Where(m => m.CustomFormFieldDatatypeID == customFormFieldQuestion.FormFieldDatatypeID).SingleAsync();
                if (customFormFieldQuestion.FormFieldDatatype.DatatypeName == "Select")
                {
                    return RedirectToAction("Details", new { id = customFormFieldQuestion.CustomFormFieldQuestionID });
                }
                else if (id != null)
                {
                    return RedirectToAction("Details", "TicketDesigns", new { id = customFormFieldQuestion.TicketDesignID });
                }
                // return RedirectToAction("Index");
            }

            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "TicketDesignName");
            ViewData["FormFieldDatatypeID"] = new SelectList(_context.CustomFormFieldDatatypes, "CustomFormFieldDatatypeID", "CustomFormFieldDatatypeID", customFormFieldQuestion.FormFieldDatatypeID);
            return View(customFormFieldQuestion);
        }

        // GET: CustomFormFieldQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldQuestion = await _context.CustomFormFieldQuestions.SingleOrDefaultAsync(m => m.CustomFormFieldQuestionID == id);
            if (customFormFieldQuestion == null)
            {
                return NotFound();
            }
            ViewData["FormFieldDatatypeID"] = new SelectList(_context.CustomFormFieldDatatypes, "CustomFormFieldDatatypeID", "DatatypeName", customFormFieldQuestion.FormFieldDatatypeID);
            ViewData["TicketDesignID"] = new SelectList(_context.TicketDesigns, "TicketDesignID", "DesignName", customFormFieldQuestion.TicketDesignID);
            return View(customFormFieldQuestion);
        }

        // POST: CustomFormFieldQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFormFieldQuestionID,TicketDesignID,FormFieldLabel,FormFieldDatatypeID,FormFieldRequired")] CustomFormFieldQuestion customFormFieldQuestion)
        {
            if (id != customFormFieldQuestion.CustomFormFieldQuestionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customFormFieldQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFormFieldQuestionExists(customFormFieldQuestion.CustomFormFieldQuestionID))
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
            ViewData["FormFieldDatatypeID"] = new SelectList(_context.CustomFormFieldDatatypes, "CustomFormFieldDatatypeID", "CustomFormFieldDatatypeID", customFormFieldQuestion.FormFieldDatatypeID);
            return View(customFormFieldQuestion);
        }

        // GET: CustomFormFieldQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFormFieldQuestion = await _context.CustomFormFieldQuestions
                .Include(c => c.FormFieldDatatype)
                .SingleOrDefaultAsync(m => m.CustomFormFieldQuestionID == id);
            if (customFormFieldQuestion == null)
            {
                return NotFound();
            }

            return View(customFormFieldQuestion);
        }

        // POST: CustomFormFieldQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customFormFieldQuestion = await _context.CustomFormFieldQuestions.SingleOrDefaultAsync(m => m.CustomFormFieldQuestionID == id);
            _context.CustomFormFieldQuestions.Remove(customFormFieldQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFormFieldQuestionExists(int id)
        {
            return _context.CustomFormFieldQuestions.Any(e => e.CustomFormFieldQuestionID == id);
        }
    }
}
