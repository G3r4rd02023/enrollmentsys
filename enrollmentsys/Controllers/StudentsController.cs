using enrollmentsys.Data.Entities;
using enrollmentsys.Helpers;
using enrollmentsys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IImageHelper _imageHelper;

        public StudentsController(DataContext context, IUserHelper userHelper, IImageHelper imageHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _imageHelper = imageHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Students
                .Include(o => o.User)
                .ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        public IActionResult Create()
        {
            var view = new AddUserViewModel { RoleId = 1 };
            return View(view);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel view)
        {
            if (ModelState.IsValid)
            {

                string path = string.Empty;

                if (view.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(view.ImageFile, "Users");
                }

                var user = await _userHelper.AddUser(view, "Student", path);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Este email ya está en uso.");
                    return View(view);
                }
                var student = new Student
                {
                    User = user
                };

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                 .Include(o => o.User)
                 .FirstOrDefaultAsync(o => o.Id == id.Value);

            if (student == null)
            {
                return NotFound();
            }

            var view = new EditUserViewModel
            {
                Address = student.User.Address,
                Document = student.User.Document,
                FirstName = student.User.FirstName,
                Id = student.Id,
                LastName = student.User.LastName,
                PhoneNumber = student.User.PhoneNumber
            };
            return View(view);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel view)
        {           
            if (ModelState.IsValid)
            {
                var student = await _context.Students
                     .Include(o => o.User)
                     .FirstOrDefaultAsync(o => o.Id == view.Id);

                student.User.Document = view.Document;
                student.User.FirstName = view.FirstName;
                student.User.LastName = view.LastName;
                student.User.Address = view.Address;
                student.User.PhoneNumber = view.PhoneNumber;

                await _userHelper.UpdateUserAsync(student.User);
                return RedirectToAction(nameof(Index));
                
            }
            return View(view);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            await _userHelper.DeleteUserAsync(student.User.Email);
            return RedirectToAction(nameof(Index));
        }        
    }
}
