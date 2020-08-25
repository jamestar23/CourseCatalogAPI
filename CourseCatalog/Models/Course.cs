using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CourseCatalog.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("logo")]
        public string  LogoUrl { get; set; }
        public string Url { get; set; }
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Course>(this);
    }
}
