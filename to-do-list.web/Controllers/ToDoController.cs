//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using to_do_list.web.Data;
//using to_do_list.web.Models;

//namespace to_do_list.web.Controllers
//{
//    public class ToDoController : Controller
//    {
//        private readonly ToDoListDbContext _context;

//        public ToDoController(ToDoListDbContext context)
//        {
//            _context = context;
//        }

//        // GET: ToDoItemModels
//        public async Task<IActionResult> Index()
//        {
//              return _context.ToDoItemModel != null ? 
//                          View(await _context.ToDoItemModel.ToListAsync()) :
//                          Problem("Entity set 'to_do_listwebContext.ToDoItemModel'  is null.");
//        }

//        // GET: ToDoItemModels/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.ToDoItemModel == null)
//            {
//                return NotFound();
//            }

//            var toDoItemModel = await _context.ToDoItemModel
//                .FirstOrDefaultAsync(m => m.ItemId == id);
//            if (toDoItemModel == null)
//            {
//                return NotFound();
//            }

//            return View(toDoItemModel);
//        }

//        // GET: ToDoItemModels/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ToDoItemModels/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(ToDoItemModel toDoItemModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(toDoItemModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(toDoItemModel);
//        }

//        // GET: ToDoItemModels/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.ToDoItemModel == null)
//            {
//                return NotFound();
//            }

//            var toDoItemModel = await _context.ToDoItemModel.FindAsync(id);
//            if (toDoItemModel == null)
//            {
//                return NotFound();
//            }
//            return View(toDoItemModel);
//        }

//        // POST: ToDoItemModels/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ToDoItemModel toDoItemModel)
//        {
//            if (id != toDoItemModel.ItemId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(toDoItemModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ToDoItemModelExists(toDoItemModel.ItemId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(toDoItemModel);
//        }

//        // GET: ToDoItemModels/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.ToDoItemModel == null)
//            {
//                return NotFound();
//            }

//            var toDoItemModel = await _context.ToDoItemModel
//                .FirstOrDefaultAsync(m => m.ItemId == id);
//            if (toDoItemModel == null)
//            {
//                return NotFound();
//            }

//            return View(toDoItemModel);
//        }

//        // POST: ToDoItemModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.ToDoItemModel == null)
//            {
//                return Problem("Entity set 'to_do_listwebContext.ToDoItemModel'  is null.");
//            }
//            var toDoItemModel = await _context.ToDoItemModel.FindAsync(id);
//            if (toDoItemModel != null)
//            {
//                _context.ToDoItemModel.Remove(toDoItemModel);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ToDoItemModelExists(int id)
//        {
//          return (_context.ToDoItemModel?.Any(e => e.ItemId == id)).GetValueOrDefault();
//        }
//    }
//}
