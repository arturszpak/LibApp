using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		public string AuthorName { get; set; }
		[Required]
		public Genre Genre { get; set; }
		[Required]
		[Display(Name="Genre")]
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name="Release Date")]
		[Required(ErrorMessage = "ReleaseDate is required.")]
		public DateTime ReleaseDate { get; set; }
		[Display(Name = "Number in Stock")]
		[Required(ErrorMessage = "NumberInStock is required.")]
		[Range(1, 20, ErrorMessage = "Range must be between 1 and 20.")]
		public int NumberInStock { get; set; }
		[Required(ErrorMessage = "NumberAvailable is required.")]
		public int NumberAvailable { get; set; }
	}
      
}
