using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseCatalog.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CourseCatalog.Services
{
    public class CourseServiceJson
    {
        private IWebHostEnvironment _WebHostEnvironment;

        public CourseServiceJson(IWebHostEnvironment webHostEnvironment)
        {
            _WebHostEnvironment = webHostEnvironment;
        }

        private string JsonDataFile
        {
            get
            {
                return Path.Combine(_WebHostEnvironment.ContentRootPath, "Data", "courses.json");
            }
        }

        public IEnumerable<Course> GetCourses() 
        {
            using (var jsonFileReader = File.OpenText(JsonDataFile))
            {
                var jsonData = jsonFileReader.ReadToEnd();

                return JsonSerializer.Deserialize<Course[]>(jsonData,
                    new JsonSerializerOptions{
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(int courseId, int rating)
        {
            var courses = GetCourses();

            var q = courses.First(x => x.Id == courseId);

            if (q.Ratings == null)
                q.Ratings = new int[] { rating };
            else
            {
                var ratings = q.Ratings.ToList();
                ratings.Add(rating);
                q.Ratings = ratings.ToArray();
            }

            using (var outFile = File.OpenWrite(JsonDataFile))
            {
                JsonSerializer.Serialize<IEnumerable<Course>>(
                    new Utf8JsonWriter(outFile, new JsonWriterOptions 
                    {
                        SkipValidation = true,
                        Indented = true
                    }), 
                    courses);
            }
        }
    }
}
