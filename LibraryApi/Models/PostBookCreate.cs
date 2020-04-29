using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LibraryApi.Models
{
    public class PostBookCreate
    {
        [Required][MaxLength(200)]
        //title author genre numberofpages
        public string Title { get; set; }
        [Required][MaxLength(200)]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfPages { get; set; }
    }
}
