using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseCatalog.Services;
using CourseCatalog.Models;

namespace CourseCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Courses : ControllerBase
    {
        public CourseServiceJson CourseServiceJson { get; }
        public Courses(CourseServiceJson courseServiceJson)
        {
            this.CourseServiceJson = courseServiceJson;
        }

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return CourseServiceJson.GetCourses();
        }

        [Route("Rate")]
        public ActionResult Get (int CourseId, int Rating)
        {
            CourseServiceJson.AddRating(CourseId, Rating);
            return Ok();
        }
    }
}
