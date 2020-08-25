using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CourseCatalog.Models;
using CourseCatalog.Services;

namespace CourseCatalog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly CourseServiceJson _courseServiceJson;
        public IEnumerable<Course> Courses { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, CourseServiceJson courseServiceJson)
        {
            _logger = logger;
            _courseServiceJson = courseServiceJson;
        }

        public void OnGet()
        {
            Courses = _courseServiceJson.GetCourses();
        }
    }
}
