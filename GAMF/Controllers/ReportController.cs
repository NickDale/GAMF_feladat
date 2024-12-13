using GAMF.Data;
using GAMF.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GAMF.Controllers
{
    public class ReportController : Controller
    {

        private readonly GAMFDbContext _context;

        public ReportController(GAMFDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IActionResult EnrollmentDateReport()
        {
            var result = _context.Students.GroupBy(s => s.EnrollmentDate)
                .Select(s => new EnrollmentDateVM
                { 
                    EnrollmentDate = s.Key,
                    StudentCount = s.Count()
                });
            return View(result.ToList());
        }


        public IActionResult StudentCreditReport()
        {
            var result = _context.Students
                .Include(x => x.Enrollments).ThenInclude(e => e.Course)
                .Select(s => new StudentCredits
                {
                    StudentName = s.FirstMidName + " " + s.LastName,
                    Credits = s.Enrollments.Sum(e => e.Course.Credits)
                });
            return View(result.ToList());
        }
    }
}
